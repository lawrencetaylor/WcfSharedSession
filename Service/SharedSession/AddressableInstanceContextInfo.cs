using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace Service.SharedSession
{
    public class AddressableInstanceContextInfo : IExtension<InstanceContext>, IExtension<IContextChannel>
    {
        // The id of the instance that the client sends in a header.
        readonly string id;

        // We only want to appear idle to WCF when we hold the lock and guarantee that no other
        // threads are using  this entry.  This tracks when we can allow WCF to think we are idle.
        bool isIdle;

        // The object that created us, used for calling callbacks.
        readonly SharedInstanceContextExtension parent;

        // Keep track of whether anyone is still using this object.
        int busyCount;

        // Keep track of whether someone wants us to call us back when idle.
        InstanceContextIdleCallback idleCallback;

        // The InstanceContext that lives at this id.
        InstanceContext instanceContext;

        // Created if two messages both want the same InstanceContext that does not exist yet, and
        // one of the messages has to wait for the other message to finish initializing the
        // InstanceContext.
        ManualResetEvent waitHandle;

        internal AddressableInstanceContextInfo(SharedInstanceContextExtension parent, string id)
        {
            this.parent = parent;

            if (String.IsNullOrEmpty(id))
            {
                this.id = Guid.NewGuid().ToString();
            }
            else
            {
                this.id = id;
            }
        }

        public string InstanceId
        {
            get { return this.id; }
        }

        public InstanceContext InstanceContext
        {
            get { return this.instanceContext; }
        }

        internal bool IsIdle
        {
            get { return this.isIdle; }
        }

        // Locking this object guards access to all the member fields.
        internal object ThisLock
        {
            get { return this; }
        }

        // --------------------------------------------------------------------
        // The next 4 methods manage whether we know of anyone who is trying to use this
        // InstanceContext.

        // This calls the callback when the SetIdleCallback call and all DecrementBusyCount calls
        // have run.  It ensures that the callback is called exactly once after a SetIdleCallback.
        // It assumes that we have locked ThisLock.
        void CheckIdle()
        {
            if ((this.busyCount == 0) && (this.idleCallback != null))
            {
                InstanceContextIdleCallback callback = this.idleCallback;
                this.idleCallback = null;
                try
                {
                    this.isIdle = true;
                    this.parent.CallIdleCallback(callback, this.instanceContext);
                }
                finally
                {
                    this.isIdle = false;
                }
            }
        }

        internal void DecrementBusyCount()
        {
            lock (this.ThisLock)
            {
                this.busyCount--;
                this.CheckIdle();
            }
        }

        internal void IncrementBusyCount()
        {
            lock (this.ThisLock)
            {
                this.busyCount++;
            }
        }

        internal void SetIdleCallback(InstanceContextIdleCallback callback)
        {
            lock (this.ThisLock)
            {
                this.idleCallback = callback;
                this.CheckIdle();
            }
        }

        // --------------------------------------------------------------------
        // The next 2 methods coordinate between the first message initializing an InstanceContext
        // and subsequent messages that need to wait for that initialization to complete.

        // This is called from InitializeInstanceContext once we are done initializing the
        // InstanceContext and are ready for business.  It records the InstanceContext and unblocks
        // anyone waiting for it.
        internal void SetInstanceContext(InstanceContext instanceContext)
        {
            lock (this.ThisLock)
            {
                this.instanceContext = instanceContext;
                if (this.waitHandle != null)
                {
                    this.waitHandle.Set();
                }
            }
        }

        // This is called by anyone who finds an AddressableInstanceContextInfo that matches their
        // instance id.  If the InstanceContext is already there, this just returns it.  Otherwise
        // it ensures that there is a WaitHandle and blocks on it.
        internal InstanceContext WaitForInstanceContext()
        {
            bool wait = false;

            if (this.InstanceContext == null)
            {
                lock (this.ThisLock)
                {
                    if (this.InstanceContext == null)
                    {
                        if (this.waitHandle == null)
                        {
                            this.waitHandle = new ManualResetEvent(false);
                        }
                        wait = true;
                    }
                }
            }

            if (wait)
            {
                this.waitHandle.WaitOne();
                this.waitHandle.Close();
            }

            return this.instanceContext;
        }

        // --------------------------------------------------------------------
        // Not used for this scenario
        void IExtension<InstanceContext>.Attach(InstanceContext channel) { }
        void IExtension<InstanceContext>.Detach(InstanceContext channel) { }
        void IExtension<IContextChannel>.Attach(IContextChannel channel) { }
        void IExtension<IContextChannel>.Detach(IContextChannel channel) { }
    }
}
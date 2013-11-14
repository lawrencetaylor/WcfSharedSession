using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private IStatefulService _sessionOne;
        private IStatefulService _sessionTwo;
        private IStatefulService _sessionThree;

        public Form1()
        {
            InitializeComponent();
            _sessionOne = CreateSessionfulProxy();
            _sessionTwo = CreateSessionfulProxy();
            _sessionThree = CreateSessionfulProxy();
        }

        private void _sessionButtonOne_Click(object sender, EventArgs e)
        {
            Display(_sessionOne.IncrementAndReturn());
        }

        private void _sessionButtonTwo_Click(object sender, EventArgs e)
        {
            Display(_sessionTwo.IncrementAndReturn());
        }

        private void _sessionButtonThree_Click(object sender, EventArgs e)
        {
            Display(_sessionThree.IncrementAndReturn());
        }

        private void _sharedButtonOne_Click(object sender, EventArgs e)
        {
            Display(CreateSharedSessionfulProxy().IncrementAndReturn());
        }

        private void _sharedButtonTwo_Click(object sender, EventArgs e)
        {
            Display(CreateSharedSessionfulProxy().IncrementAndReturn());
        }

        private void _sharedButtonThree_Click(object sender, EventArgs e)
        {
            Display(CreateSharedSessionfulProxy().IncrementAndReturn());
        }

        private static void Display(int counter)
        {
            MessageBox.Show(string.Format("Counter value: {0}", counter));
        }

        IStatefulService CreateSessionfulProxy()
        {
            return ChannelFactory<IStatefulService>.CreateChannel(new NetTcpBinding(),
                                                                  new EndpointAddress("net.tcp://localhost:8013/Session"));
        }

        IStatefulService CreateSharedSessionfulProxy()
        {
            IStatefulService sessionfulProxy = ChannelFactory<IStatefulService>.CreateChannel(new NetTcpBinding(),
                                                                  new EndpointAddress("net.tcp://localhost:8012/SharedSession"));
            return new StatefulServiceContext(sessionfulProxy,"sessionId");
        }

        private class StatefulServiceContext: IStatefulService, IDisposable
        {
            private readonly IStatefulService _proxy;
            private readonly OperationContextScope _scope;

            public StatefulServiceContext(IStatefulService proxy, string sessionId)
            {
                _proxy = proxy;
                _scope = new OperationContextScope((IContextChannel)_proxy);
                OperationContext.Current.OutgoingMessageHeaders.Add(CreateHeader(sessionId));
            }

            public int IncrementAndReturn()
            {
                return _proxy.IncrementAndReturn();
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }


        public static readonly String HeaderName = "InstanceId";
        public static readonly String HeaderNamespace = "http://www.algebraiccode.com/InstanceSharing";

        public static MessageHeader CreateHeader(string instanceId)
        {
            return MessageHeader.CreateHeader(HeaderName, HeaderNamespace, instanceId);
        }
    }

    [ServiceContract]
    public interface IStatefulService
    {
        [OperationContract]
        int IncrementAndReturn();
    }


}

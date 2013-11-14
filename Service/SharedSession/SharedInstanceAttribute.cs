using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Service.SharedSession
{
    public sealed class SharedInstanceAttribute : Attribute, IServiceBehavior
    {

        #region Implementation of IServiceBehavior

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            SharedInstanceContextExtension extension = new SharedInstanceContextExtension();
            foreach (ChannelDispatcherBase dispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher dispatcher = dispatcherBase as ChannelDispatcher;
                foreach (EndpointDispatcher endpointDispatcher in dispatcher.Endpoints)
                {
                    endpointDispatcher.DispatchRuntime.InstanceContextProvider = extension;
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(extension);
                }
            }
        }

        #endregion
    }
}
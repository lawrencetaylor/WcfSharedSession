using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Service.SharedSession
{
    /// <summary>
    /// Used to pass the instance/session Id from the client to the server
    /// </summary>
    public static class SharedInstanceHeader
    {
        public static readonly String HeaderName = "InstanceId";
        public static readonly String HeaderNamespace = "http://www.algebraiccode.com/InstanceSharing";

        public static MessageHeader CreateHeader(string instanceId)
        {
            return MessageHeader.CreateHeader(HeaderName, HeaderNamespace, instanceId);
        }

        public static string GetInstanceId()
        {
            var messageHeader = OperationContext.Current.IncomingMessageHeaders;
            if (messageHeader != null)
            {
                var index = messageHeader.FindHeader(HeaderName, HeaderNamespace);
                if (index != -1)
                {
                    return messageHeader.GetHeader<string>(index);
                }
            }
            return null;
        }
    }
}
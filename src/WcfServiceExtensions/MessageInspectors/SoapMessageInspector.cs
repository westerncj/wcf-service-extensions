using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using WcfServiceExtensions.Interfaces;

namespace WcfServiceExtensions.MessageInspectors
{
    public class SoapMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        private readonly IMessageLogger _logger;
        private readonly bool _logOnFaultOnly;

        public SoapMessageInspector(IMessageLogger logger, bool logOnFaultOnly = true)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logOnFaultOnly = logOnFaultOnly;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (!_logOnFaultOnly || reply.IsFault)
            {
                // Log the message
                string message = $"SOAP Message:{Environment.NewLine}{reply.ToString()}";
                _logger.LogMessage(message);
            }
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (!_logOnFaultOnly || reply.IsFault)
            {
                // Log the message
                string message = $"SOAP Message:{Environment.NewLine}{reply.ToString()}";
                _logger.LogMessage(message);
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
    }
}

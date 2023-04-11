using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using Moq;
using WcfServiceExtensions.Interfaces;
using WcfServiceExtensions.MessageInspectors;

namespace WcfServiceExtensions.Tests
{
    public class SoapMessageInspectorTests
    {
        [Fact]
        public void BeforeSendReply_LogOnFaultOnlyFalse_LogsMessage()
        {
            var logger = new Mock<IMessageLogger>();
            var inspector = new SoapMessageInspector(logger.Object, false);
            var reply = Message.CreateMessage(MessageVersion.Soap11, "Action");

            inspector.BeforeSendReply(ref reply, null);

            logger.Verify(x => x.LogMessage(It.IsAny<string>()), Times.Once);
        }

    }
}
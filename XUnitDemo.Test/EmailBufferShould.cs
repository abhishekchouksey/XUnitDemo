using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace XUnitDemo.Test
{
    public class EmailBufferShould
    {
        [Fact]
        public void SendEmailToSender_Manual_With_Moq()
        {
            var fixture = new Fixture();

            var mockSender = new Mock<IEmailSender>();

            var emailBuffer = new EmailBuffer(mockSender.Object);

            emailBuffer.Add(fixture.Create<EmailMessage>());

            emailBuffer.SendAll();

            mockSender.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }


        [Fact]
        public void SendEmailToSender_Auto_Moq()
        {
            // arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var mockEmailSender = fixture.Freeze<Mock<IEmailSender>>();

            var sut = fixture.Create<EmailBuffer>();

            sut.Add(fixture.Create<EmailMessage>());

            // act
            sut.SendAll();

            // assert
            mockEmailSender.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

        // syntax magic, all Arrange were done by the framework.
        [Theory]
        [AutoMoq]
        public void SendEmailToSender_AutoMoq(EmailMessage message,
            [Frozen] Mock<IEmailSender> mockEmailSender,
            EmailBuffer bufferTest)
        {
            bufferTest.Add(message);

            bufferTest.SendAll();

            mockEmailSender.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

    }


    public sealed class AutoMoqAttribute : AutoDataAttribute
    {
        public AutoMoqAttribute() : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {

        }
    }
}

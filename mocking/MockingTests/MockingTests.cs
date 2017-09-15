using System;
using Xunit;
using Mocking;
using Moq;

namespace MockingTests
{
    public class PaymentServiceShould
    {
        [Fact]
        public void FailIfUserDoesNotExist()
        {
            var paymentGateway = new Mock<PaymentGateway>();
            paymentGateway.Setup(x => x.SendPayment(It.IsAny<User>()))
                .Throws(new Exception("failure"));
            var paymentService = new PaymentService(paymentGateway.Object);
            var user = new User();
            Assert.Throws<Exception>(() => paymentService.ProcessPayment(user));
        }
  
        [Fact]
        public void SendPaymentToGatewayIfUserDoesExist()
        {
            var paymentGateway = new Mock<PaymentGateway>();

            var paymentService = new PaymentService(paymentGateway.Object);

            var user = new User();
            paymentService.ProcessPayment(user);

           paymentGateway.Verify(x => x.SendPayment(user), Times.Once);
        }
    }
}

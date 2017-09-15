using System;

namespace Mocking
{
    public class PaymentService
    {
        private readonly PaymentGateway _paymentGateway;

        public PaymentService(PaymentGateway paymentGateway){
            _paymentGateway = paymentGateway;
        }

        public void ProcessPayment(User user){
            _paymentGateway.SendPayment(user);
        }
    }

    public interface PaymentGateway{
        void SendPayment(User user);
    }

    public class User{}
}

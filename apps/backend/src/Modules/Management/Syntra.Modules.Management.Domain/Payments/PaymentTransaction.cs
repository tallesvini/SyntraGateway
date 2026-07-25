using Syntra.SharedKernel.Domain;

namespace Syntra.Modules.Management.Domain.Payments
{
    public sealed class PaymentTransaction : AuditableEntity
    {
        public Guid InvoiceId { get; private set; }
        public Guid PaymentMethodId { get; private set; }
        public decimal Amount { get; private set; }
        public string FailureReason { get; private set; }

        private PaymentTransaction() { }

        public PaymentTransaction(Guid invoiceId, Guid paymentMethodId, decimal amount, string failureReason)
        {
            InvoiceId = invoiceId;
            PaymentMethodId = paymentMethodId;
            Amount = amount;
            FailureReason = failureReason;
        }
    }
}

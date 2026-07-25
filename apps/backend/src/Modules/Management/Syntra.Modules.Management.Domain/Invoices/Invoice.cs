using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.Invoices
{
    public sealed class Invoice : AuditableEntity, ITenantEntity
    {
        public Guid TenantId { get; private set; }
        public Guid SubscriptionId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTimeOffset BillingDate { get; private set; }

        private Invoice() { }

        public Invoice(Guid tenantId, Guid subscriptionId, decimal amount, DateTimeOffset billingDate)
        {
            TenantId = tenantId;
            SubscriptionId = subscriptionId;
            Amount = amount;
            BillingDate = billingDate;
        }
    }
}

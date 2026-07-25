using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.Tenants
{
    public sealed class TenantSubscription : AuditableEntity, ITenantEntity
    {
        public Guid TenantId { get; private set; }
        public Guid PlanId { get; private set; }
        public DateTimeOffset StartedAt { get; private set; }
        public DateTimeOffset ExpiresAt { get; private set; }
        public DateTimeOffset NextBillingDate { get; private set; }
        public bool AutoRenew { get; private set; }

        private TenantSubscription() { }

        public TenantSubscription(Guid tenantId, Guid planId, DateTimeOffset expiresAt, DateTimeOffset nextBillingDate, bool autoRenew)
        {
            TenantId = tenantId;
            PlanId = planId;
            StartedAt = DateTime.UtcNow;
            ExpiresAt = expiresAt;
            NextBillingDate = nextBillingDate;
            AutoRenew = autoRenew;
        }
    }
}

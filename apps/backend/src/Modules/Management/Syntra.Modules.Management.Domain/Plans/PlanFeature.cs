using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.Plans
{
    public sealed class PlanFeature : AuditableEntity, ITenantEntity
    {
        public Guid TenantId { get; private set; }
        public Guid PlanId { get; private set; }
        public string FeatureKey { get; private set; }
        public string FeatureValue { get; private set; }

        private PlanFeature() { }

        public PlanFeature(Guid tenantId, Guid planId, string featureKey, string featureValue)
        {
            TenantId = tenantId;
            PlanId = planId;
            FeatureKey = featureKey;
            FeatureValue = featureValue;
        }
    }
}

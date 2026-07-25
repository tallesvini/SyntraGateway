using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.Tenants
{
    public sealed class Tenant : AuditableEntity, ISoftDeleted
    {
        public string Name { get; private set; }
        public string TaxId { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }

        private Tenant() { }

        public Tenant(string name, string taxId)
        {
            Name = name;
            TaxId = taxId;
            IsDeleted = false;
        }
    }
}

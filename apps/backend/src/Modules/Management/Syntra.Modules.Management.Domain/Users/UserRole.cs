using Syntra.SharedKernel.Domain;

namespace Syntra.Modules.Management.Domain.Users
{
    public sealed class UserRole : StatusEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private UserRole() { }

        public UserRole(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}

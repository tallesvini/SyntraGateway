using Syntra.SharedKernel.Domain;

namespace Syntra.Modules.Management.Domain.Plans
{
    public sealed class Plan : StatusEntity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        private Plan() { }

        public Plan(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}

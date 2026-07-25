using Syntra.SharedKernel.Domain;

namespace Syntra.Modules.Management.Domain.Payments
{
    public sealed class PaymentMethod : StatusEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        private PaymentMethod() { }

        public PaymentMethod(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}

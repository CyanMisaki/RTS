using Abstractions.Commands.CommandsInterfaces;

namespace Abstractions
{
    public interface IAttackable : IHealthHolder
    {
        void ReceiveDamage(int amount);
    }
}
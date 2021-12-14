namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IHealthHolder
    {
        float Health { get; }
        float MaxHealth { get; }
    }
}
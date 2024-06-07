namespace Application.Commands.Abstraction;

/// <summary>
/// Command handler interface
/// </summary>
/// <typeparam name="TCommand">Command instance <see cref="ICommand"/></typeparam>
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}
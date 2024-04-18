using MediatR;

namespace PopularLibraries.MediatRExample.Items.Commands.UpdateItem;
                                  //IRequest es una interfaz que indica a MediatR
                                  //Si el handler va a devolver algo o no
public record UpdateItemCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required decimal Price { get; init; }
    public required string Title { get; init; }
}

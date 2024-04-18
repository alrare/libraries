using MediatR;
using PopularLibraries.MediatRExample.Data;
using PopularLibraries.MediatRExample.Dtos;
using PopularLibraries.MediatRExample.Events;

namespace PopularLibraries.MediatRExample.Items.Commands.UpdateItem;
                                        //IRequestHandler<T><bool>
public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
{
    private readonly IDatabaseRepository _databaseRepository;
    private readonly IMediator _mediator;

    //Se inyecta IDatabaseRepository, IMediator 
    public UpdateItemCommandHandler(IDatabaseRepository databaseRepository, IMediator mediator)
    {
        _databaseRepository = databaseRepository;
        _mediator = mediator;
    }
    
    //Se hacen validaciones 
    public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        if (request.Title.Length > 200)
            throw new Exception("Title must be less than 200 characters");
        if (request.Price <= 0)
            throw new Exception("It can't be free");
    
    //Se actualiza el registro
        ItemDto existingItem = await _databaseRepository.GetItemById(request.Id);
        await _databaseRepository.UpdateItem(request.Id, request.Price, request.Title);

    //Se publica evento se notifia a mediator
        await _mediator.Publish(new ItemUpdated()
        {
            Id = request.Id,
            NewPrice = request.Price,         //Nuevo precio
            NewTitle = request.Title,         //Nuevo titulo  
            OldPrice = existingItem.Price,    //Anterior precio 
            OldTitle = existingItem.Title     //Anterior titulo
        }, cancellationToken);

        return true;
    }
}

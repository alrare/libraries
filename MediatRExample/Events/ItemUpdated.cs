using MediatR;

namespace PopularLibraries.MediatRExample.Events;
                            //Hereda de INotification porque MediatR se encarga de investigar que clases heredan de la clase 
                            //INotificationHandler y comprueba si alguna implementa ItemUpdated
                            //Si implementa lo que hace es ejecutar el ItemUpdatedEventHandler
public record ItemUpdated : INotification
{
    public required int Id { get; init; }
    public required decimal NewPrice { get; init; }
    public required decimal OldPrice { get; init; }
    public required string NewTitle { get; init; }
    public required string OldTitle { get; init; }
}

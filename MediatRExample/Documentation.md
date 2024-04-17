## MEDIATR

#### PROYECTO
Tipo: Web Api
Version: Net 8.0

#### INSTALACIÓN
[dotnet add package MediatR --version 12.2.0](https://www.nuget.org/packages/MediatR/#supportedframeworks-body-tab)

#### OBJETIVO
Crear aplicaciones con codigo limpio y componentes desacoplados con patrón MediatR 

#### CASO DE USO
1. Actualizar un item propieddes del producto si el precio ha disminuido 30% enviar correo de notificación al cliente del producto con descuento. 
   
#### CONFIGURACIÓN

DefaultExampleControllers.cs
```csharp
sing Microsoft.AspNetCore.Mvc;
using PopularLibraries.MediatRExample.Dtos;
using PopularLibraries.MediatRExample.UseCases;

namespace PopularLibraries.MediatRExample.Controllers;

[ApiController]
[Route("[controller]")]

public class DefaultExampleController : ControllerBase
{
    public readonly UpdateItem _UpdateItem;

    public DefaultExampleController(UpdateItem updateItem)
    {
        _UpdateItem = updateItem;
    }

    [HttpPut("item")]
    public async Task<bool> UpdateItem(ItemDto itemDto)
        => await _UpdateItem.Execute(itemDto);
}

```

MediatRExampleController.cs
```csharp
[ApiController]
[Route("[controller]")]
public class MediatRExampleController : ControllerBase
{
    //En lugar de inyectar el caso de uso se utiliza MediatR
    //ISender es interfaz de MediatR
    private readonly ISender _sender;

    public MediatRExampleController(ISender sender)
    {
        _sender = sender;
    }

    //Enviar del controlador a MediatR
    [HttpPut("item")]
    public async Task<bool> UpdateItem(ItemDto itemDto)
        => await _sender.Send(new UpdateItemCommand()
        {
            Id = itemDto.Id,
            Price = itemDto.Price,
            Title = itemDto.Title
        });
}

```

#### REFERENCIAS
[Mediator Pattern](https://refactoring.guru/es/design-patterns/mediator)

Notas:
a) MediatR por su naturaleza puede implementar facilmente CQRS

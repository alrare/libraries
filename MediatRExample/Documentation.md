## MEDIATR

#### PROYECTO
Tipo: Web Api
Version: Net 8.0

#### INSTALACIÓN
[dotnet add package MediatR --version 12.2.0](https://www.nuget.org/packages/MediatR/#supportedframeworks-body-tab)

### OBJETIVO
Crear aplicaciones con codigo limpio y componentes desacoplados con patrón MediatR 

### CASO DE USO
1. Actualizar un item propieddes del producto si el precio ha disminuido 30% enviar correo de notificación al cliente del producto con descuento. 
   
#### CONFIGURACIÓN

Controllers.cs
| DefaultExample  | MediatRExample |
| ------------------------------------------------------------------- | ------------- |
| ```csharp                                                           |               |
| sing Microsoft.AspNetCore.Mvc;                                      |               |
| using PopularLibraries.MediatRExample.Dtos;                         |               |
| ```                                                                 |               |

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


```csharp


```


```csharp


```



#### REFERENCIAS
[Mediator Pattern](https://refactoring.guru/es/design-patterns/mediator)

Notas:
a) MediatR por su naturaleza puede implementar facilmente CQRS

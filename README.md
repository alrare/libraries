## FLUENT VALIDATIONS

#### PROYECTO
Tipo: Minimal Api
Version: Net 8.0

#### INSTALACIÓN
[dotnet add package FluentValidation --version 11.9.0](https://www.nuget.org/packages/FluentValidation/)

### CASO DE USO
1. Validar por medio de _fluent validations_ usuarios mayores de 18 años 
2. Validar por medio de _fluent validations_ correo del usuario con domminio _gmail.com_
3. Validar por medio de _fluent validations_ usuarios mayores a 65 años
   
#### CONFIGURACIÓN

```csharp

public record User(string Name, string Email, int Age, int? AgeOfRetirement);

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(a => a.Age).GreaterThanOrEqualTo(18);
        RuleFor(a => a.Name).NotEmpty();
        RuleFor(a => a.Email).EmailAddress()
            .Must(e => e.EndsWith("@gmail.com"))
            .WithMessage("Debes utilizar un correo de gmail.");

        When(a => a.Age >= 65, () =>
                RuleFor(user => user.AgeOfRetirement).NotEmpty().GreaterThanOrEqualTo(65)
            )
            .Otherwise(() => RuleFor(user => user.AgeOfRetirement).Null());
    }
}

```



```csharp
builder.Services.AddScoped<IValidator<User>, UserValidator>();


var app = builder.Build();

app.MapPost("/user", async (User user, IValidator<User> validator) =>
    {
        var validationResult = await validator.ValidateAsync(user);

        if (!validationResult.IsValid)
        {
            return string.Join(',', validationResult.Errors.Select(a => a.ErrorMessage));
        }

        return $"User created (simulated) {user.Name}";
    })
    .WithOpenApi();
```


#### REFERENCIAS
[Fluent Validations](https://docs.fluentvalidation.net/en/latest/)


Notas:

a) Existen _Fluent Assertions_ para proyectos de pruebas unitarias en C#

b) Microsoft ha estado integrando estas validaciones en sus versiones más recientes


### MEDIATR


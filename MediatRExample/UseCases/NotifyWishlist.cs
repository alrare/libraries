namespace PopularLibraries.MediatRExample.UseCases;

public class NotifyWishlist
{
    public Task Execute(int id)
    {
        //No necesitamos que esto funcione para el ejemplo
        Console.WriteLine("Lógica para saber quién incluye esa identificación en la lista de deseos y enviar los correos electrónicos");
        
        return Task.FromResult(true);
    }
}

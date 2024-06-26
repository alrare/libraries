﻿using MediatR;
using PopularLibraries.MediatRExample.Events;

namespace PopularLibraries.MediatRExample.Items.EventHandlers;

public class ItemUpdatedEventHandler : INotificationHandler<ItemUpdated>
{
    //No necesitamos que esto funcione para el ejemplo
    public async Task Handle(ItemUpdated notification, CancellationToken cancellationToken)
    {
        decimal percentageDifference = ((notification.NewPrice - notification.OldPrice) / notification.NewPrice) * 100;

        if (percentageDifference <= -30)
        {
            Console.WriteLine("Logic to get who is wishlisting that ID and send the emails");
        }
    }
}

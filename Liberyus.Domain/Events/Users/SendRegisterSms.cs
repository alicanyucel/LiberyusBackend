using MediatR;


namespace Liberyus.Domain.Events.Users
{
    public sealed class SendRegisterSms : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            //notification.AppUser.Id;
            //Sms Gönderme İşlemi

            return Task.CompletedTask;
        }
    }
}
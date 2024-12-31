using Liberyus.Domain.Entities;
using MediatR;


namespace Liberyus.Domain.Events.Users
{
    public sealed class UserDomainEvent : INotification
    {
        public AppUser AppUser { get; }

        public UserDomainEvent(AppUser appUser)
        {
            AppUser = appUser;
        }
    }
}
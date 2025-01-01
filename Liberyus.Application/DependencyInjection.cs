using FluentValidation;
using Liberyus.Application.Behaviors;
using Liberyus.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;


namespace Liberyus.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssemblies(
                    typeof(DependencyInjection).Assembly,
                    typeof(AppUser).Assembly);
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            object value = services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;

        }
    }
}

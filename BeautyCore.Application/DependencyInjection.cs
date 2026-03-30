using BeautyCore.Application.Command.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application
{
    public static class DependencyInjection
    {
        //Application katmanındaki tüm Handler'ları (iş mantığı sınıfları) tek tek kaydetmek yerine, otomatik tarayacak bir yapı kuruyoruz
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //Application projesindeki tüm class’ları tarıyor
            //MediatR’a ait olanları buluyor
            //Otomatik olarak DI container’a ekliyor
            services.AddMediatR(cfg =>
            {                                    //Burası “Şu an çalıştığım proje” demek
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });
            // Tüm Validator'ları otomatik tara ve kaydet:
            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}

using Casus.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Net.Mime;

namespace Casus.Extensions
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Registers services for file upload and modification support.
        /// </summary>
        public static IServiceCollection AddUploadFileModifier(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IRandomTextService, RandomTextService>();
            services.AddScoped<ITimeStampService, TimeStampService>();
            return services;
        }
    }
}

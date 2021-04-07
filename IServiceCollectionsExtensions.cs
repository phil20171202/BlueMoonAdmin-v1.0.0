using BlueMoonAdmin;
using BlueMoonAdmin.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Extensions.DependencyInjection
{
    static class IServiceCollectionsExtensions
    {
        public static IServiceCollection AddLocalizationConfigurations(this IServiceCollection services)
        {
            services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("es-MX") };
                    options.DefaultRequestCulture = new RequestCulture(culture: "es-MX", uiCulture: "es-MX");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    var providerQuery = new LocalizationQueryProvider { QueryParameterName = "ui_locales" };
                    options.RequestCultureProviders.Insert(0, providerQuery);
                });
            return services;
        }
    }
}

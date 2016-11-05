using gasl.Mvc.Core;
using Microsoft.Extensions.DependencyInjection;

namespace gasl.Mvc
{
    public static class Features 
    {
        public static void AddMvcWithFeatureRouting(this IServiceCollection services)
        {
            services.AddMvc(options => options.Conventions.Add(new FeatureConvention()))
                .AddTagHelpersAsServices()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Clear();
                    options.ViewLocationFormats.Add("/Features/{3}/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Features/{3}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
                    options.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
                });
        }
    }
}
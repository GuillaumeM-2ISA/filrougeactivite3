using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Reflection;

namespace DocFx
{
    public class ConfigDocFxUI
    {
        public string Path { get; set; }
    }

    public static class DocFxExtension
    {
        public static void UseDocFxUI(this IApplicationBuilder app, Action<ConfigDocFxUI> settings)
        {
            ConfigDocFxUI configDocFxUI = new ConfigDocFxUI();

            settings?.Invoke(configDocFxUI);

            if (configDocFxUI.Path is null)
            {
                configDocFxUI.Path = "/doc";
            }

            app.UseFileServer(new FileServerOptions()
            {
                RequestPath = configDocFxUI.Path,
                FileProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "DocFx._site")
            });
        }
    }
}

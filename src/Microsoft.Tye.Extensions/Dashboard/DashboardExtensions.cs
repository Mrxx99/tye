using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Tye.Extensions.Dashboard
{
    public class DashboardExtensions : Extension
    {
        public Dictionary<string, Uri> Extensions { get; } = new Dictionary<string, Uri>();

        public override Task ProcessAsync(ExtensionContext context, ExtensionConfiguration config)
        {
            if (config.Data.TryGetValue("pages", out var pages) && pages is Dictionary<string, object> pagesConfig)
            {
                foreach (var pageConfig in pagesConfig)
                {
                    var name = pagesConfig["name"] as string;
                    var service = pagesConfig["service"] as string;
                    var servicePath = pagesConfig["servicePath"] as string;

                    var extensionService = context.Application.Services.FirstOrDefault(s => s.Name == name);

                    var httpBinding = extensionService.Bindings.FirstOrDefault(x => x.Protocol == "http");
                    var host = httpBinding.Host ?? "http://localhost";
                    var uri = new Uri($"{httpBinding.Host}/{httpBinding.Port}/{servicePath}");

                    Extensions.Add(name, uri);
                }
            }

            return Task.CompletedTask;
        }
    }
}

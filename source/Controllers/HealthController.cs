using RazorEngine;
using RazorEngine.Templating; // For extension methods.
using System;
using System.Linq;
using System.Web.Mvc;
using WebAppStatus.Contracts;
using WebAppStatus.Models;
using WebAppStatus.Services;

namespace WebAppStatus.Controllers
{
    [Route("health")]
    public class HealthController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public string Index()
        {
            var tests = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IHealthTest).IsAssignableFrom(p))
                .Where(x => !x.IsInterface);

            var model = new IndexPageModel();

            model.OwnerName = ConfigurationProvider.GetOwnerName();
            model.PageTitle = ConfigurationProvider.GetPageTitle();

            foreach (var item in tests)
            {
                var instance = Activator.CreateInstance(item) as IHealthTest;
                model.TestResults.Add(instance.Run());
            }

            var template = EmbeddedResourceProvider.Read("WebHealthPage.Views.Health.Index.html");
            var templateKey = Guid.NewGuid().ToString();
            var result = Engine.Razor.RunCompile(template, templateKey, null, model);

            return result;
        }
    }
}

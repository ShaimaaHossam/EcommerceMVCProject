using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Ecommerce.Data.Context;
using Ecommerce.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace Ecommerce.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ProductData>()
                .As<IProductData>()
                .InstancePerRequest();
            builder.RegisterType<CategoryData>()
               .As<ICategoryData>()
               .InstancePerRequest();
            builder.RegisterType<ShopContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
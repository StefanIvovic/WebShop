using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Logging;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WebShop.BusinessServices;

namespace Manager.DependecyResolver
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IProductServices, ProductServices>();
            MvcUnityContainer.Container = container;
            return container;
        }
    }
}
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Service;

namespace ShoppingMall.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICity>().To<CityService>();
            kernel.Bind<AutoMapperConfigaration>().To<AutoMapperConfigaration>();
        }
    }
}
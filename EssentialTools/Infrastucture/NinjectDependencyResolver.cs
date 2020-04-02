namespace EssentialTools.Infrastucture
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using EssentialTools.Models;
    using Ninject;
    using Ninject.Web.Common;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            Addbindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void Addbindings()
        {
            kernel.Bind<IvalueCalculator>().To<LinqValueCalculator>().InRequestScope();
            //kernel.Bind<IDiscounterHelper>().To<DefaultDiscounterHelper>().WithPropertyValue("DiscountSize", 50m);
            kernel.Bind<IDiscounterHelper>().To<DefaultDiscounterHelper>().WithConstructorArgument("discountParam", 50m);
            kernel.Bind<IDiscounterHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
    }
}
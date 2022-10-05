using CommonServiceLocator;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
   public class SimpleInjectorServiceLocator : ServiceLocatorImplBase
    {
        private readonly Container _container;
        public SimpleInjectorServiceLocator(Container container) 
        {
            _container = container;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType);
        }
    }
}

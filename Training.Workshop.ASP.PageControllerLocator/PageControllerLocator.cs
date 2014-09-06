using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.ASP.PageControllerLocator
{
    public static class PageControllerLocator
    {
        public static readonly Dictionary<Type, Type> pagecontrollers = new Dictionary<Type, Type>();

        public static void RegisterPageController<T>(Type pagecontroller)
        {
            pagecontrollers[typeof(T)] = pagecontroller;
        }

        public static T Resolve<T>()
        {
            return (T)Activator.CreateInstance(pagecontrollers[typeof(T)]);
        }
    }
}

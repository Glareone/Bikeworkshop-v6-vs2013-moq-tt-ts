using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Training.Workshop.ASP.Client
{
    public abstract class PageView<T> : Page where T : class
    {
        private T _controller;

        public T Controller
        {
            get { return _controller ?? (_controller = GetController()); }
        }

        protected abstract T GetController();
    }

    public class UserControlView<T> : UserControl
    {
        public T Controller { get; set; }
    }
}
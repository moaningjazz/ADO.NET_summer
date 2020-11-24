using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Ioc
{
    public class DependencyResolver
    {
        private static NinjectBindings _bindings = new NinjectBindings();
        public static StandardKernel Kernel = new StandardKernel(_bindings);
    }
}

using Auction.BLL;
using Auction.BLL.Interfaces;
using Auction.DAL;
using Auction.DAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Ioc
{
    public static class NinjectConfig
    {
        public static class Config
        {
            /// <summary>
            /// Load your modules or register your services here!
            /// </summary>
            /// <param name="kernel">The kernel.</param>
            public static void RegisterServices(IKernel kernel)
            {
                kernel
                    .Bind<ILotLogic>()
                    .To<LotLogic>()
                    .InSingletonScope();

                kernel
                    .Bind<IUserLogic>()
                    .To<UserLogic>()
                    .InSingletonScope();

                kernel
                    .Bind<ILotDao>()
                    .To<LotDao>()
                    .InSingletonScope();

                kernel
                    .Bind<IUserDao>()
                    .To<UserDao>()
                    .InSingletonScope();
            }
        }
    }
}

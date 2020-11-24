using Auction.BLL;
using Auction.BLL.Interfaces;
using Auction.DAL;
using Auction.DAL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Ioc
{
    class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDao>().To<UserDao>();
            Bind<IUserLogic>().To<UserLogic>();

            Bind<ILotDao>().To<LotDao>();
            Bind<ILotLogic>().To<LotLogic>();
        }
    }
}

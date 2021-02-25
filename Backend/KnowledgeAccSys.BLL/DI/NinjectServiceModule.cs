using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Data;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeAccSys.BLL.DI
{
    public class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<IDataContext>().To<KnowledgeContext>().InSingletonScope();
        }
    }
}

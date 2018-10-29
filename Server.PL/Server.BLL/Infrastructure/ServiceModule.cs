using Ninject;
using Server.DAL;
using Server.DAL.Interfaces;
using Server.DAL.Repositories;

namespace Server.BLL.Infrastructure
{
    public class ServiceModule
    {
        private static IKernel _ninjectKernel;

        public static void InitializeIoc(string connectionString)
        {
            _ninjectKernel = new StandardKernel();
            _ninjectKernel.Bind<IRepository<Workers>>().To<WorkersRepository>().WithConstructorArgument(connectionString);
            _ninjectKernel.Bind<IRepository<Letter>>().To<LetterRepository>().WithConstructorArgument(connectionString);
        }

        public static IRepository<Workers> Workers  => _ninjectKernel.Get<IRepository<Workers>>();
        public static IRepository<Letter> Letter  => _ninjectKernel.Get<IRepository<Letter>>();

    }
}
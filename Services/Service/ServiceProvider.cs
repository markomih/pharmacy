using Data;
using Ninject;

namespace Services
{
    public class ServiceProvider
    {
        private static readonly IKernel Kernel;
        private static readonly object ObjLock = new object();

        static ServiceProvider()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<INewDataLayer>().To<NewDataLayer>();
        }

        public static T Get<T>()
        {
            lock (ObjLock)
            {
               return Kernel.Get<T>();
            }
        }
    }
}
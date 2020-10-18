using Unity;
using Api.Interfaces;
using Api.Utils;
using Unity.Injection;

namespace Api
{
    public class IOC
    {
        // Register types
        public static void RegisterElements(IUnityContainer container)
        {
            // LogHelper
            container.RegisterType<ILogHelper, LogHelper>();

            // Mapper
            container.RegisterType<IMapper, Mapper>();

            // FundsHelper
            container.RegisterType<IFundsHelper, FundsHelper>(
                new InjectionConstructor(
                    typeof(ILogHelper),
                    typeof(Mapper)
                )
            );
        }
    }
}
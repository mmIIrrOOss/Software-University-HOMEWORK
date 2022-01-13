namespace Dependency_Injection
{
    using Injectors;
    using Modules;

    public class DInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}

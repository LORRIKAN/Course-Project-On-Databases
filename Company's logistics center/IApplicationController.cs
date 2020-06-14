using Autofac;

namespace LogisticsCenter
{
    public interface IApplicationController
    {
        bool Run(ILifetimeScope scope);
    }
}
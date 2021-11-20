using System;
using System.Collections.Generic;

namespace CrossInteractionService.Service
{
    //This is just a cheap throw-together implementation of a DI framework that definitely should not be final and should be iterated on
    //The problem this solves is that I will need to add services which will be injected *after* it would have been built, nullifying
    //Microsoft's DI implementations because once a provider is built, you cannot do anything else with that provider. This allows nesting
    //service providers within itself and achieves the effect of adding services during runtime.

    public class DependencyProvider : IServiceProvider
    {
        private readonly Dictionary<Type, object> services;
        private readonly IServiceProvider rootProvider;
        private readonly bool hasRootProvider = false;

        DependencyProvider(IServiceProvider rootProvider)
        {
            this.rootProvider = rootProvider;
            hasRootProvider = this.rootProvider is not null;
        }
        public DependencyProvider(IServiceProvider rootProvider,  Dictionary<Type, object> services) : this(rootProvider)
        {
            this.services = new(services);
        }

        public object GetService(Type serviceType)
        {
            object serviceInstance = null;

            if (hasRootProvider) serviceInstance = rootProvider.GetService(serviceType);
            if (serviceInstance is null) services.TryGetValue(serviceType, out serviceInstance);

            return serviceInstance;
        }
    }

    public class DependencyProviderBuilder
    {
        private readonly Dictionary<Type, object> services = new();
        IServiceProvider rootProvider = null;

        public DependencyProviderBuilder AddRootProvider(IServiceProvider rootProvider)
        {
            this.rootProvider = rootProvider;
            return this;
        }
        public DependencyProviderBuilder AddSingleService<T>()
        {
            services.TryAdd(typeof(T), default);
            return this;
        }
        public DependencyProviderBuilder AddInstanceService<T>(T instance)
        {
            services.TryAdd(typeof(T), instance ?? default);
            return this;
        }

        public IServiceProvider Build()
        {
            return new DependencyProvider(rootProvider, services);
        }
    }
}

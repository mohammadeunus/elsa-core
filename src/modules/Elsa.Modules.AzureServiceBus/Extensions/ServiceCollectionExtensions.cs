﻿using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Elsa.Modules.AzureServiceBus.Contracts;
using Elsa.Modules.AzureServiceBus.HostedServices;
using Elsa.Modules.AzureServiceBus.Options;
using Elsa.Modules.AzureServiceBus.Providers;
using Elsa.Modules.AzureServiceBus.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Elsa.Modules.AzureServiceBus.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register required services for the Azure Service Bus module. 
    /// </summary>
    /// <param name="autoCreateQueuesTopicsAndSubscriptions">A value indicating whether or not queues, topics and subscriptions should be created at application startup.</param>
    public static IServiceCollection AddAzureServiceBusServices(this IServiceCollection services, Action<AzureServiceBusOptions> configure, bool autoCreateQueuesTopicsAndSubscriptions = true)
    {
        services.Configure(configure);

        services
            .AddSingleton(CreateServiceBusManagementClient)
            .AddSingleton(CreateServiceBusClient)
            .AddSingleton<ConfigurationQueueTopicAndSubscriptionProvider>()
            .AddTransient<IServiceBusInitializer, ServiceBusInitializer>()
            .AddSingleton<IQueueProvider>(sp => sp.GetRequiredService<ConfigurationQueueTopicAndSubscriptionProvider>())
            .AddSingleton<ITopicProvider>(sp => sp.GetRequiredService<ConfigurationQueueTopicAndSubscriptionProvider>())
            .AddSingleton<ISubscriptionProvider>(sp => sp.GetRequiredService<ConfigurationQueueTopicAndSubscriptionProvider>());

        if (autoCreateQueuesTopicsAndSubscriptions)
            services.AddHostedService<CreateQueuesTopicsAndSubscriptions>();

        return services;
    }

    private static ServiceBusClient CreateServiceBusClient(IServiceProvider serviceProvider) => new(GetConnectionString(serviceProvider));
    private static ServiceBusAdministrationClient CreateServiceBusManagementClient(IServiceProvider serviceProvider) => new(GetConnectionString(serviceProvider));

    private static string GetConnectionString(IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<IOptions<AzureServiceBusOptions>>().Value;
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetConnectionString(options.ConnectionStringOrName) ?? options.ConnectionStringOrName;
    }
}
﻿// Copyright (c) TotalSoft.
// This source code is licensed under the MIT license.

using MediatR;
using NBB.Core.Effects;
using NBB.ProcessManager.Definition.SideEffects;
using NBB.ProcessManager.Runtime.Persistence;
using NBB.ProcessManager.Runtime.SideEffectHandlers;
using NBB.ProcessManager.Runtime.Timeouts;
using System;
using System.Reflection;
using NBB.ProcessManager.Runtime;
using Unit = NBB.Core.Effects.Unit;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddProcessManager(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddProcessManagerDefinition(assemblies);
            services.AddScoped<ProcessExecutionCoordinator>();
            services.AddScoped<IInstanceDataRepository, InstanceDataRepository>();
            services.AddEffects();
            services.AddTimeoutEffects();
            services.AddMessagingEffects();
            services.AddHttpEffects();
            services.AddMediatorEffects();
            services.AddScoped<INotificationHandler<TimeoutOccured>, TimeoutOccuredHandler>();
            services.AddNotificationHandlers(typeof(ProcessManagerNotificationHandler<,,>));
        }

        private static void AddTimeoutEffects(this IServiceCollection services)
        {
            services.AddHostedService<TimeoutsService>();
            services.AddSingleton<TimeoutsManager>();
            services.AddSingleton<ITimeoutsRepository, InMemoryTimeoutRepository>();
            services.AddSingleton<Func<DateTime>>(provider => () => DateTime.UtcNow);
            services.AddSingleton<ISideEffectHandler<CancelTimeouts, Unit>, CancelTimeoutsHandler>();
            services.AddSingleton(typeof(IRequestTimeoutHandler<>), typeof(RequestTimeoutHandler<>));
        }
    }
}
using System;
using System.Collections.Generic;

public static class Services
{
    private static readonly Dictionary<Type, object> services = new();

    public static void Register<T>(T service) where T : class
    {
        var type = typeof(T);

        if (services.ContainsKey(type))
            throw new Exception($"Service {type.Name} already registered");

        services[type] = service;
    }

    public static T Get<T>() where T : class
    {
        var type = typeof(T);

        if (!services.TryGetValue(type, out var service))
            throw new Exception($"Service {type.Name} not registered");

        return (T)service;
    }

    public static void Clear()
    {
        services.Clear();
    }
}

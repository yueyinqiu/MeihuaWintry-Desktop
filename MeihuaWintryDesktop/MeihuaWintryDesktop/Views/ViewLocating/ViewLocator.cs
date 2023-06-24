using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace MeihuaWintryDesktop.Views.ViewLocating;
public sealed class ViewLocator : IDataTemplate
{
    private readonly Dictionary<Type, Type> dictionary;

    public ViewLocator()
    {
        dictionary = new();
        var interfaceType = typeof(ILocatableView);
        foreach (var viewType in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (viewType.IsClass)
            {
                var interfaceArray = viewType.GetInterfaces();
                if (Array.IndexOf(interfaceArray, interfaceType) != -1)
                {
                    var property = viewType.GetProperty(nameof(ILocatableView.TypeOfViewModel));
                    var viewModelType = (Type?)property?.GetMethod?.Invoke(null, null);
                    Debug.Assert(viewModelType is not null);
                    dictionary.Add(viewModelType, viewType);
                }
            }
        }
    }

    public Control? Build(object? param)
    {
        var type = dictionary[param?.GetType()!];
        var instance = Activator.CreateInstance(type);
        return instance as Control;
    }

    public bool Match(object? data)
    {
        if (data is null)
            return false;

        return dictionary.ContainsKey(data.GetType());
    }
}

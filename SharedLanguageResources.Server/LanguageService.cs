using Microsoft.Extensions.Localization;
using System.Reflection;

namespace SharedLanguageResources.Server;

public interface ILanguageService
{
    IEnumerable<LocalizedString> GetAllStrings();

    LocalizedString GetString(string key);
}

/// <summary>
/// Dummy class to group shared resources
/// </summary>
public class SharedResource { }

public class LanguageService : ILanguageService
{
    private readonly IStringLocalizer _localizer;
    public LanguageService(IStringLocalizerFactory factory)
    {
        var type = typeof(SharedResource);
        var fullName = type.GetTypeInfo()?.Assembly?.FullName;
        if (fullName == null)
        {
            throw new NullReferenceException("AssemblyName is null");
        }

        var assemblyName = new AssemblyName(fullName);
        if (assemblyName.Name == null)
        {
            throw new NullReferenceException("AssemblyName is null");
        }

        _localizer = factory.Create("SharedResource", assemblyName.Name);
    }

    public IEnumerable<LocalizedString> GetAllStrings()
    {
        return _localizer.GetAllStrings();
    }

    public LocalizedString GetString(string key)
    {
        return _localizer[key];
    }
}

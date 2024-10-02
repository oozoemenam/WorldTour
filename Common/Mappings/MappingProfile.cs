using System.Reflection;
using AutoMapper;

namespace WorldTour.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssemby(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssemby(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(
                t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
            ).ToList();
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            // var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
            var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom")?.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
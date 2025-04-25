using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nuta.BuildingBlocks.Domain;

namespace Nuta.BuildingBlocks.Infrastructure.ValueConverters;

public class StronglyTypedIdValueConverterSelector(ValueConverterSelectorDependencies dependencies)
    : ValueConverterSelector(dependencies)
{
    private static readonly MethodInfo Create = typeof(StronglyTypedIdValueConverterSelector)
        .GetMethod(nameof(CreateTypedIdConverter), BindingFlags.Static | BindingFlags.NonPublic)!;

    public override IEnumerable<ValueConverterInfo> Select(Type modelType, Type? providerType = null)
    {
        if (typeof(TypedIdValueBase).IsAssignableFrom(modelType))
        {
            yield return Build(modelType);
            yield break;
        }

        foreach (var valueConverterInfo in base.Select(modelType, providerType))
            yield return valueConverterInfo;
    }

    private static ValueConverterInfo Build(Type modelType)
    {
        var factory = Create.MakeGenericMethod(modelType);
        return (ValueConverterInfo)factory.Invoke(null, null)!;
    }

    private static ValueConverterInfo CreateTypedIdConverter<TId>() where TId : TypedIdValueBase
        => new(
            modelClrType: typeof(TId),
            providerClrType: typeof(Guid),
            factory: _ => new ValueConverter<TId, Guid>(
                id => id.Value,
                guid => (TId)Activator.CreateInstance(typeof(TId), guid)!));
}
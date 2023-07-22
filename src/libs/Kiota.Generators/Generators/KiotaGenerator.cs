using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

[Generator]
public class KiotaGenerator : IIncrementalGenerator
{
    #region Constants

    public const string Name = "Kiota";
    public const string Id = "KG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.AdditionalTextsProvider
            .Where(static text =>
                text.Path.EndsWith(".yml", StringComparison.InvariantCultureIgnoreCase) ||
                text.Path.EndsWith(".yaml", StringComparison.InvariantCultureIgnoreCase) ||
                text.Path.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
            .Combine(context.AnalyzerConfigOptionsProvider
                .Select(static (x, _) => (
                    ClassName: x.GetRequiredGlobalOption("ClassName", prefix: Name),
                    NamespaceName: x.GetRequiredGlobalOption("NamespaceName", prefix: Name))))
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
    }

    private static EquatableArray<FileWithName> GetSourceCode(
        (AdditionalText text, (string ClassName, string NamespaceName)) tuple,
        CancellationToken cancellationToken = default)
    {
        var (text, (className, namespaceName)) = tuple;

        var files = GetSources(
                path: text.Path,
                className: className,
                namespaceName: namespaceName)
            .Select(static x => new FileWithName(
                Name: x.Name, 
                Text: x.Content))
            .ToArray();

        return files.ToImmutableArray().AsEquatableArray();
    }

    public static IReadOnlyCollection<(string Name, string Content)> GetSources(
        string path,
        string className,
        string namespaceName)
    {
        return Array.Empty<(string Name, string Content)>();
    }

    #endregion
}
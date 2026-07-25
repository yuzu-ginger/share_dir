using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace TestAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TestAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "TestAnalyzer";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Naming";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);
        private static readonly DiagnosticDescriptor ConstRule = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "CONSTの命名規則",
            messageFormat: "定数 '{0}' は、CONST_CASE に従っていません。",
            category: Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "定数は CONST_CASE である必要があります。");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(Rule, ConstRule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Field);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var field = (IFieldSymbol)context.Symbol;

            // 変数名
            string name = field.Name;
            // アクセス修飾子
            var accessibility = field.DeclaredAccessibility;

            // private 以外は除外
            if (accessibility != Accessibility.Private) return;

            // const なら CONST_CASE になっているか？
            if (field.IsConst)
            {
                AnalyzeConst(context, field);
                return;
            }

            // "_"で始まっていて、camelCaseか？
            // 1文字目が "_" か？
            if (!name.StartsWith("_"))
            {
                var diagnostic = Diagnostic.Create(Rule, field.Locations[0], field.Name);
                context.ReportDiagnostic(diagnostic);
            }
            // 変数名の文字数が2文字未満なら "_" のみなのでNG
            if (name.Length < 2)
            {
                var diagnostic = Diagnostic.Create(Rule, field.Locations[0], field.Name);
                context.ReportDiagnostic(diagnostic);
            }

            // camelCaseになっているか？
            if (!char.IsLower(name[1]))
            {
                var diagnostic = Diagnostic.Create(Rule, field.Locations[0], field.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }

        /// <summary>
        /// CONSTの命名規則に従っているか？
        /// </summary>
        /// <param name="field"></param>
        private static void AnalyzeConst(SymbolAnalysisContext context, IFieldSymbol field)
        {
            if (field.Name != field.Name.ToUpper())
            {
                var diagnostic = Diagnostic.Create(ConstRule, field.Locations[0], field.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}

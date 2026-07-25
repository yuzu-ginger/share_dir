# Roslyn Analyzer

## Register...Actionメソッド
```csharp
Register〇〇Action(
    解析メソッド,
    対象の種類
)
```
|Registerメソッド|用途|アナライザーのメソッドの引数
|----|----|----|
|RegisterSyntaxNodeAction|構文（コードの形）（if文がある、フィールド宣言がある ...）|SyntaxNodeAnalysisContext context|
|RegisterSyntaxTree|ファイル全体|SyntaxTreeAnalysisContext context|
|RegisterSymbolAction|コードの意味（フィールドがprivate, 戻り値はint ...）|SymbolAnalysisContext context|
|RegisterCompilationAction|プロジェクト全体|CompilationAnalysisContext context|

## ルールを考える
### 命名規則
1. privateフィールドは `_camelCase` にする
    - フィールド
    - アクセス修飾子
    - 名前
    - → `FieldDeclaration` (Syntax Visualizer で確認する)
2. publicプロパティは `CamelCase` にする
    - プロパティ
    - アクセス修飾子
    - 名前
    - →
3. クラス名は `PascalCase` にする。名詞にする
    - クラス
    - 名前
    - → 
4. インターフェースは `IPascalCase` にする
    - インターフェース
    - 名前
    - →
5. メソッド名は `PascalCase` にする。動詞から始まる
    - メソッド
    - 名前
    - →
6. 定数は `CONSTANT_CASE` にする。
    - 定数
    - 名前
    - →

### コーディングルール
1. 空白行は2行以上続けてはいけない
    - → 
2. マジックナンバーを使わない
    - →
3. マジックストリングを使わない
    - →
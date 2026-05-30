QuizSettingViewからクイズへの遷移
```csharp title="ItemField.cs"
// ItemField.cs
public enum ItemField
{
    商品名,
    型名,
    事業部名
}
```
```csharp title="QuizFactory.cs"
// QuizFactory.cs
// CreateQuizView メソッド
// navi, setting, quizItems を受け取る
// view を返す
UserControl view;
switch setting.Mode
case QuizMode.FlashCard
    var session = new FlashCardQuizSession(quizItems, setting);
    view = new FlashCardQuizView(navi, session);
case QuizMode.ChoiceQuiz
    var session = new ChoiceQuizSession(quizItems, setting);
    view = new ChoiceQuizView(navi, session);
:
return view;
```


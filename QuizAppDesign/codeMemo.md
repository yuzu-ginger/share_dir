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

正解表示
```csharp
private async Task ShowResultAsync(
    bool isCorrect)
{
    resultLabel.Text =
        isCorrect ? "○" : "×";

    resultLabel.Visible = true;

    await Task.Delay(1000);

    resultLabel.Visible = false;
}

// 呼び出し側 ===========
private async void ChoiceButton_Click(
    object? sender,
    EventArgs e)
{
    bool isCorrect = CheckAnswer();

    await ShowResultAsync(isCorrect);

    nextButton.Enabled = true;
}

// 組み合わせクイズでは===================
private async void PairSelected()
{
    bool isCorrect =
        _session.CheckPair();

    if (!isCorrect)
    {
        firstButton.BackColor =
            Color.LightPink;

        secondButton.BackColor =
            Color.LightPink;

        await Task.Delay(500);

        firstButton.BackColor =
            _defaultColor;

        secondButton.BackColor =
            _defaultColor;
    }
}
```

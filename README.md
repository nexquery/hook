# C# Hook
Hook C# form components.

# Usage
```csharp
Label label = XHook.Get<Label>("Form1", "label1");
XHook.Action(label, (x) =>
{
    x.Text = "Hook!";
});

Button[] buttons = XHook.GetArray<Button>("Form1", "button1", "button2");
XHook.ActionArray(buttons, (btn) =>
{
    btn[0].Text = "Hook!";
    btn[1].Text = "Hook!";
});
```

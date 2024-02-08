# C# Hook
Hook C# form components.

# Usage
```csharp
Label label = Hook.Get<Label>("Form1", "label1");
Hook.Action(label, (x) =>
{
    x.Text = "Hook!";
});

Button[] buttons = Hook.GetArray<Button>("Form1", "button1", "button2");
Hook.ActionArray(buttons, (btn) =>
{
    btn[0].Text = "Hook!";
    btn[1].Text = "Hook!";
});
```

# Note
The current form must be active for it to work.

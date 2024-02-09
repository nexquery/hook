# C# Hook
It allows you to securely hook and modify form components.

# Usage
```csharp
/* Single Hook */
Label label = Hook.Get<Label>("Form1", "label1");
Hook.Action(label, (x) =>
{
    x.Text = "Hook!";
    x.ForeColor = Color.Black;
});

/* Multiple Hook */
Button[] buttons = Hook.GetArray<Button>("Form1", "button1", "button2");
Hook.ActionArray(buttons, (btn) =>
{
    // button1
    btn[0].Text = "Hook!";
    btn[0].ForeColor = Color.Red;

    // button2
    btn[1].Text = "Hook!";
    btn[1].ForeColor = Color.Blue;
});

/* Form Hook */
Hook.Form("Form1", (x) =>
{
    x.Text = "HAHA";
    x.BackColor = Color.YellowGreen;
});
```

# Note
The current form must be active for it to work.

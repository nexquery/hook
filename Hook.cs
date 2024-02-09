/*****************************************************
*                                                    *
*                      Hook.cs                       *
*                                                    *
*   Kodlama:                                         *
*       Burak Akat (Nexor)                           *
*                                                    *
*   Tarih:                                           *
*       08.02.2024                                   *
*                                                    *
*   Amaç:                                            *
*       Nesneler üzerinde kancalama yaparak onlara   *
*       erişmeinizi ve düzenlemenizi sağlar.         *
*                                                    *
******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class Hook
{
    public static T Get<T>(string formName, string componentName) where T : Control
    {
        Form hook = Application.OpenForms[formName];
        if (hook != null)
        {
            Control c = hook.Controls.Find(componentName, true).OfType<T>().FirstOrDefault();
            return c as T;
        }
        return null;
    }

    public static void Action<T>(T cx, Action<T> act) where T : Control
    {
        if (cx != null)
        {
            if (cx.InvokeRequired)
            {
                cx.Invoke((MethodInvoker)delegate { act(cx); });
            }
            else
            {
                act(cx);
            }
        }
    }

    public static T[] GetArray<T>(string formName, params string[] componentNames) where T : Control
    {
        Form hook = Application.OpenForms[formName];
        if (hook != null)
        {
            List<T> controls = new List<T>();
            foreach (string cName in componentNames)
            {
                Control c = hook.Controls.Find(cName, true).OfType<T>().FirstOrDefault();
                if (c != null)
                {
                    controls.Add(c as T);
                }
            }
            return controls.ToArray();
        }
        return null;
    }

    public static void ActionArray<T>(T[] controls, Action<T[]> action) where T : Control
    {
        if (controls != null && controls.Length > 0)
        {
            foreach (T control in controls)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke((MethodInvoker)delegate { action(controls); });
                }
                else
                {
                    action(controls);
                }
            }
        }
    }

    public static void Form(string formName, Action<Form> action)
    {
        Form form = Application.OpenForms[formName];
        if (form != null)
        {
            if (form.InvokeRequired)
            {
                form.Invoke((MethodInvoker)delegate { action(form); });
            }
            else
            {
                action(form);
            }
        }
    }
}

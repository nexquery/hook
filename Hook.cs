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

public class XHook
{
    public static T Get<T>(string formIsim, string isim) where T : Control
    {
        Form hook = Application.OpenForms[formIsim];
        if (hook != null)
        {
            Control nesne = hook.Controls.Find(isim, true).OfType<T>().FirstOrDefault();
            return nesne as T;
        }
        return null;
    }

    public static void Action<T>(T cx, Action<T> eylem) where T : Control
    {
        if (cx != null)
        {
            if (cx.InvokeRequired)
            {
                cx.Invoke(new Action(() => { eylem(cx); }));
            }
            else
            {
                eylem(cx);
            }
        }
    }

    public static T[] GetArray<T>(string formIsim, params string[] isimler) where T : Control
    {
        Form hook = Application.OpenForms[formIsim];
        if (hook != null)
        {
            List<T> controls = new List<T>();
            foreach (string isim in isimler)
            {
                Control nesne = hook.Controls.Find(isim, true).OfType<T>().FirstOrDefault();
                if (nesne != null)
                {
                    controls.Add(nesne as T);
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
                    control.Invoke(new Action(() => { action(controls); }));
                }
                else
                {
                    action(controls);
                }
            }
        }
    }
}
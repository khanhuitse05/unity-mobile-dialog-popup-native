using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class NativeDialog
    {
        public NativeDialog() { }

        public static void OpenDialog(string title, string message, string ok = "Ok", Action onClick = null)
        {
#if UNITY_IPHONE
            IOSDialogInfo dialog = IOSDialogInfo.Create(title, message, ok, onClick);
#endif
        }
        public static void OpenDialog(string title, string message, string yes, string no, Action<int> onClick = null)
        {
#if UNITY_IPHONE
            IOSDialogConfirm dialog = IOSDialogConfirm.Create(title, message, yes, no, onClick);
#endif
        }
        public static void OpenDialog(string title, string message, string ok, string neutral, string cancel, Action<int> onClick = null)
        {
#if UNITY_IPHONE
            IOSDialogNeutral dialog = IOSDialogNeutral.Create(title, message, ok, neutral, cancel, onClick);
#endif
        }
    }
}
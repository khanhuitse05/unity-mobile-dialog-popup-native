using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class NativeDialog
    {
        public NativeDialog() { }

        public static void OpenDialog(string title, string message, string ok = "Ok", Action okAction = null)
        {
#if UNITY_IPHONE
            IOSDialogInfo.Create(title, message, ok, okAction);
#endif
        }
        public static void OpenDialog(string title, string message, string yes, string no, Action yesAction = null, Action noAction = null)
        {
#if UNITY_IPHONE
            IOSDialogConfirm.Create(title, message, yes, no, yesAction, noAction);
#endif
        }
        public static void OpenDialog(string title, string message, string accept, string neutral, string decline, Action acceptAction = null, Action neutralAction = null, Action declineAction = null)
        {
#if UNITY_IPHONE
            IOSDialogNeutral.Create(title, message, accept, neutral, decline, acceptAction, neutralAction, declineAction);
#endif
        }
        public static void OpenDatePicker(IOSDateTimePickerMode mode, double unix = 0, Action<DateTime> onChange = null, Action<DateTime> onClose = null)
        {
#if UNITY_IPHONE
            IOSDateTimePicker.Create(mode, unix, onChange, onClose);
#endif
        }
    }
}
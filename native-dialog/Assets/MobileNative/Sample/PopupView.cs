using UnityEngine;
using System.Collections;
using pingak9;
using UnityEngine.UI;
using System;

public class PopupView : MonoBehaviour
{
    public Text txtLog;
    public void DebugLog(string log)
    {
        txtLog.text = log;
        Debug.Log(log);
    }
    

    // Dialog Button click event
    public void OnDialogInfo()
    {
        NativeDialog.OpenDialog("Info popup", "Welcome To Native Popup", "Ok", 
            ()=> {
                DebugLog("OK Button pressed");
            });
    }

    public void OnDialogConfirm()
    {
        NativeDialog.OpenDialog("Confirm popup", "Do you wants about app?", "Yes", "No",
            () => {
                DebugLog("Yes Button pressed");
            },
            () => {
                DebugLog("No Button pressed");
            });
    }
    public void OnDialogNeutral()
    {
        NativeDialog.OpenDialog("Like this game?", "Please rate to support future updates!", "Rate app", "later", "No, thanks",
            () =>
            {
                DebugLog("Rate Button pressed");
            },
            () =>
            {
                DebugLog("Later Button pressed");
            },
            () =>
            {
                DebugLog("No Button pressed");
            });
    }
    int _mode = 0;
    public void OnDatePicker()
    {
        _mode = _mode + 1;
        if (_mode == 3) _mode = 1;
        int _now = _mode == 2 ? (int)DateTime.Now.ToOADate() : 0;
        NativeDialog.OpenDatePicker((IOSDateTimePickerMode)_mode, _now,
            (DateTime _date) =>
            {
                DebugLog(_date.ToString());
            },
            (DateTime _date) =>
            {
                DebugLog(_date.ToString());
            });        
    }
}
using UnityEngine;
using System.Collections;
using pingak9;
using UnityEngine.UI;
using System;

public class PopupView : MonoBehaviour
{
    public Text txtLog;
    void DebugLog(string log)
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
        if (_mode == 5) _mode = 1;

        if (_mode == (int)IOSDateTimePickerMode.Date)
        {
            NativeDialog.OpenDatePicker((IOSDateTimePickerMode)_mode, DateTime.Now.ToOADate(),
                (DateTime _date) =>
                {
                    DebugLog(_date.ToString());
                },
                (DateTime _date) =>
                {
                    DebugLog(_date.ToString());
                });
        }
        else
        {

            NativeDialog.OpenDatePicker((IOSDateTimePickerMode)_mode, 0,
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
}
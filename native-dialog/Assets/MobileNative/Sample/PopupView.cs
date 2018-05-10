using UnityEngine;
using System.Collections;
using pingak9;
using UnityEngine.UI;

public class PopupView : MonoBehaviour
{
    #region DELEGATE_EVENT_LISTENER
    public Text txtLog;
    void DebugLog(string log)
    {
        txtLog.text = log;
        Debug.Log(log);
    }
    void OnDialogInfoComplete()
    {
        DebugLog("OK Button pressed");
    }
    void OnDialogConfigComplete(int state)
    {
        if (state == DialogState.YES)
        {
            DebugLog("YES Button pressed");
        }
        else
        {
            DebugLog("NO Button pressed");
        }
    }
    void OnDialogNeutralComplete(int state)
    {
        if (state == DialogState.ACCEPT)
        {
            DebugLog("ACCEPT Button pressed");
        }
        else if (state == DialogState.NEUTRAL)
        {
            DebugLog("NEUTRAL Button pressed");
        }
        else
        {
            DebugLog("DECLINED Button pressed");
        }
    }

    #endregion

    #region BUTTON_EVENT_LISTENER

    // Dialog Button click event
    public void OnDialogInfo()
    {
        NativeDialog.OpenDialog("Info popup", "Welcome To Native Popup", "Ok", OnDialogInfoComplete);
    }

    public void OnDialogConfirm()
    {
        NativeDialog.OpenDialog("Confirm popup", "Do you wants about app?", "Yes", "No", OnDialogConfigComplete);
    }
    public void OnDialogNeutral()
    {
        NativeDialog.OpenDialog("Like this game?", "Please rate to support future updates!", "Rate app", "later", "No, thanks", OnDialogNeutralComplete);
    }

    #endregion
}
using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class IOSDialogInfo : MonoBehaviour
    {

        #region PUBLIC_VARIABLES

        public Action onButtonClick;
        public string title;
        public string message;
        public string ok;

        #endregion

        #region PUBLIC_FUNCTIONS

        public static IOSDialogInfo Create(string title, string message, string ok, Action onclick)
        {
            IOSDialogInfo dialog;
            dialog = new GameObject("IOSDialogInfo").AddComponent<IOSDialogInfo>();
            dialog.title = title;
            dialog.message = message;
            dialog.ok = ok;
            dialog.onButtonClick = onclick;

            dialog.init();
            return dialog;
        }

        public void init()
        {
            IOSNative.showInfoPopup(title, message, ok);
        }

        #endregion

        #region IOS_EVENT_LISTENER

        public void OnDialogCallBack(string buttonIndex)
        {
            if (onButtonClick != null)
            {
                onButtonClick();
            }
            Destroy(gameObject);
        }

        #endregion
    }
}
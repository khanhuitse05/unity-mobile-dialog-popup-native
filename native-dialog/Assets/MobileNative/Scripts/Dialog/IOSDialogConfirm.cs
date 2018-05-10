using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class IOSDialogConfirm : MonoBehaviour
    {
        #region PUBLIC_VARIABLES

        public Action<int> onButtonClick;
        public string title;
        public string message;
        public string yes;
        public string no;
        public string urlString;

        #endregion

        #region PUBLIC_FUNCTIONS

        // Constructor
        public static IOSDialogConfirm Create(string title, string message, string yes, string no, Action<int> onclick)
        {
            IOSDialogConfirm dialog;
            dialog = new GameObject("IOSDialogConfirm").AddComponent<IOSDialogConfirm>();
            dialog.title = title;
            dialog.message = message;
            dialog.yes = yes;
            dialog.no = no;
            dialog.onButtonClick = onclick;
            dialog.init();
            return dialog;
        }

        public void init()
        {
            IOSNative.showDialogConfirm(title, message, yes, no);
        }

        #endregion

        #region IOS_EVENT_LISTENER

        public void OnDialogCallBack(string buttonIndex)
        {
            int index = System.Convert.ToInt16(buttonIndex);
            if (onButtonClick != null)
            {
                onButtonClick(index);
            }
            Destroy(gameObject);
        }

        #endregion
    }
}
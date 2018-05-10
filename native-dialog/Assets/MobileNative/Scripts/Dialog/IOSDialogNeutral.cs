using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class IOSDialogNeutral : MonoBehaviour
    {
        #region PUBLIC_VARIABLES

        public Action<int> onButtonClick;
        public string title;
        public string message;
        public string accept;
        public string neutral;
        public string decline;

        #endregion

        #region PUBLIC_FUNCTIONS

        public static IOSDialogNeutral Create(string title, string message, string accept, string neutral, string decline, Action<int> onclick)
        {
            IOSDialogNeutral dialog = new GameObject("IOSDialogNeutral").AddComponent<IOSDialogNeutral>();
            dialog.title = title;
            dialog.message = message;
            dialog.accept = accept;
            dialog.neutral = neutral;
            dialog.decline = decline;
            dialog.onButtonClick = onclick;

            dialog.init();
            return dialog;
        }

        public void init()
        {
            IOSNative.showDialogNeutral(title, message, accept, neutral, decline);
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
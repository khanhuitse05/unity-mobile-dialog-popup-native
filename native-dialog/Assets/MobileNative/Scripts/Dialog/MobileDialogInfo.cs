using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class MobileDialogInfo : MonoBehaviour
    {

        #region PUBLIC_VARIABLES

        public Action okAction;
        public string title;
        public string message;
        public string ok;

        #endregion

        #region PUBLIC_FUNCTIONS

        public static MobileDialogInfo Create(string title, string message, string ok, Action okAction)
        {
            MobileDialogInfo dialog;
            dialog = new GameObject("MobileDialogInfo").AddComponent<MobileDialogInfo>();
            dialog.title = title;
            dialog.message = message;
            dialog.ok = ok;
            dialog.okAction = okAction;

            dialog.init();
            return dialog;
        }

        public void init()
        {
            MobileNative.showInfoPopup(title, message, ok);
        }

        #endregion

        #region IOS_EVENT_LISTENER

        public void OnOkCallBack(string message)
        {
            if (okAction != null)
            {
                okAction();
            }
            Destroy(gameObject);
        }

        #endregion
    }
}
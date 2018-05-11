using UnityEngine;
using System.Collections;
using System;

namespace pingak9
{
    public class IOSDialogNeutral : MonoBehaviour
    {
        #region PUBLIC_VARIABLES

        public Action acceptAction;
        public Action neutralAction;
        public Action declineAction;
        public string title;
        public string message;
        public string accept;
        public string neutral;
        public string decline;

        #endregion

        #region PUBLIC_FUNCTIONS

        public static IOSDialogNeutral Create(string title, string message, string accept, string neutral, string decline, Action acceptAction, Action neutralAction, Action declineAction)
        {
            IOSDialogNeutral dialog = new GameObject("IOSDialogNeutral").AddComponent<IOSDialogNeutral>();
            dialog.title = title;
            dialog.message = message;
            dialog.accept = accept;
            dialog.neutral = neutral;
            dialog.decline = decline;
            dialog.acceptAction = acceptAction;
            dialog.neutralAction = neutralAction;
            dialog.declineAction = declineAction;

            dialog.init();
            return dialog;
        }

        public void init()
        {
            IOSNative.showDialogNeutral(title, message, accept, neutral, decline);
        }

        #endregion

        #region IOS_EVENT_LISTENER

        public void OnAcceptCallBack(string message)
        {
            if (acceptAction != null)
            {
                acceptAction();
            }
            Destroy(gameObject);
        }

        public void OnNeutralCallBack(string message)
        {
            if (acceptAction != null)
            {
                acceptAction();
            }
            Destroy(gameObject);
        }
        public void OnDeclineCallBack(string message)
        {
            if (acceptAction != null)
            {
                acceptAction();
            }
            Destroy(gameObject);
        }
        #endregion
    }
}
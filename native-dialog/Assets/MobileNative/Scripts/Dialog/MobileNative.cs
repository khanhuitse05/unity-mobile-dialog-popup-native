
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace pingak9
{

    public class MobileNative
    {

#if UNITY_IPHONE
        [DllImport("__Internal")]
        private static extern void _TAG_ShowDialogNeutral(string title, string message, string accept, string neutral, string decline);

        [DllImport("__Internal")]
        private static extern void _TAG_ShowDialogConfirm(string title, string message, string yes, string no);

        [DllImport("__Internal")]
        private static extern void _TAG_ShowDialogInfo(string title, string message, string ok);

        [DllImport("__Internal")]
        private static extern void _TAG_DismissCurrentAlert();
	
        [DllImport ("__Internal")]
        private static extern void _TAG_ShowDatePicker(int mode, double unix);

#endif

        public static void showDialogNeutral(string title, string message, string accept, string neutral, string decline)
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
            _TAG_ShowDialogNeutral(title, message, accept, neutral, decline);
#elif UNITY_ANDROID            
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
            javaUnityClass.CallStatic("ShowDialogNeutral", title, message, accept, neutral, decline);
#endif
        }

        public static void showDialogConfirm(string title, string message, string yes, string no)
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
            _TAG_ShowDialogConfirm(title, message, yes, no);
#elif UNITY_ANDROID            
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
            javaUnityClass.CallStatic("ShowDialogConfirm", title, message, yes, no);
#endif
        }

        public static void showInfoPopup(string title, string message, string ok)
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
            _TAG_ShowDialogInfo(title, message, ok);
#elif UNITY_ANDROID            
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
            javaUnityClass.CallStatic("ShowDialogInfo", title, message, ok);
#endif
        }

        public static void DismissCurrentAlert()
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
            _TAG_DismissCurrentAlert();
#elif UNITY_ANDROID
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
            javaUnityClass.CallStatic("DismissCurrentAlert");
#endif
        }

        public static void showDatePicker(int year, int month, int day)
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
            DateTime dateTime = new DateTime(year, month, day);
            double unix = (TimeZoneInfo.ConvertTimeToUtc(dateTime) - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds; 
            _TAG_ShowDatePicker(2, unix);
#elif UNITY_ANDROID
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
            javaUnityClass.CallStatic("ShowDatePicker", year, month, day);
#endif
        }
        public static void showTimePicker()
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
            _TAG_ShowDatePicker(1, 0);
#elif UNITY_ANDROID
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
            javaUnityClass.CallStatic("ShowTimePicker");
#endif
        }
    }
}
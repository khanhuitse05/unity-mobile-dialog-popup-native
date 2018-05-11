#define DEBUG_MODE


#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
using System.Runtime.InteropServices;
#endif

namespace pingak9
{
    public class DialogState
    {
        public static int OK = 0;
        public static int YES = 0;
        public static int NO = 1;
        public static int ACCEPT = 0;
        public static int NEUTRAL = 1;
        public static int DECLINED = 2;
    }

    public class IOSNative
    {

#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
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
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _TAG_ShowDialogNeutral(title, message, accept, neutral, decline);
#endif
        }

        public static void showDialogConfirm(string title, string message, string yes, string no)
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _TAG_ShowDialogConfirm(title, message, yes, no);
#endif
        }

        public static void showInfoPopup(string title, string message, string ok)
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _TAG_ShowDialogInfo(title, message, ok);
#endif
        }

        public static void DismissCurrentAlert()
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _TAG_DismissCurrentAlert();
#endif
        }

        public static void showDatePicker(int mode, double unix = 0)
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _TAG_ShowDatePicker(mode, unix);
#endif
        }
    }
}
using UnityEngine;
using System;
using System.Collections;

#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
using System.Runtime.InteropServices;
#endif

namespace pingak9
{
    public enum IOSDateTimePickerMode
    {
        Time = 1, // Displays hour, minute, and optionally AM/PM designation depending on the locale setting (e.g. 6 | 53 | PM)
        Date = 2, // Displays month, day, and year depending on the locale setting (e.g. November | 15 | 2007)
    }


    public class MobileDateTimePicker : MonoBehaviour
    {


        public Action<DateTime> OnDateChanged;
        public Action<DateTime> OnPickerClosed;
        public IOSDateTimePickerMode mode;
        public double unix = 0;



        #region PUBLIC_FUNCTIONS

        public static MobileDateTimePicker Create(IOSDateTimePickerMode mode, double unix = 0, Action<DateTime> onChange = null, Action<DateTime> onClose = null)
        {
            MobileDateTimePicker dialog;
            dialog = new GameObject("MobileDateTimePicker").AddComponent<MobileDateTimePicker>();
            dialog.mode = mode;
            dialog.unix = unix;
            dialog.OnDateChanged = onChange;
            dialog.OnPickerClosed = onClose;

            dialog.init();
            return dialog;
        }

        public void init()
        {
            MobileNative.showDatePicker((int)mode, unix);
        }

        #endregion



        //--------------------------------------
        // Events
        //--------------------------------------

        private void DateChangedEvent(string time)
        {
            DateTime dt = DateTime.Parse(time);

            if (OnDateChanged != null)
                OnDateChanged(dt);
        }

        private void PickerClosedEvent(string time)
        {
            DateTime dt = DateTime.Parse(time);

            if (OnPickerClosed != null)
                OnPickerClosed(dt);
        }
    }
}
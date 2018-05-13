using UnityEngine;
using System;
using System.Globalization;

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


        #region PUBLIC_FUNCTIONS

        public static MobileDateTimePicker CreateDate(int year, int month, int day, Action<DateTime> onChange = null, Action<DateTime> onClose = null)
        {
            MobileDateTimePicker dialog;
            dialog = new GameObject("MobileDateTimePicker").AddComponent<MobileDateTimePicker>();
            dialog.OnDateChanged = onChange;
            dialog.OnPickerClosed = onClose;

            MobileNative.showDatePicker(year, month, day);
            return dialog;
        }

        public static MobileDateTimePicker CreateTime(Action<DateTime> onChange = null, Action<DateTime> onClose = null)
        {
            MobileDateTimePicker dialog;
            dialog = new GameObject("MobileDateTimePicker").AddComponent<MobileDateTimePicker>();
            dialog.OnDateChanged = onChange;
            dialog.OnPickerClosed = onClose;

            MobileNative.showTimePicker();
            return dialog;
        }

        #endregion



        //--------------------------------------
        // Events
        //--------------------------------------

        string formatDate = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// Note avalible in android
        /// </summary>
        /// <param name="time"></param>
        public void DateChangedEvent(string time)
        {
            DateTime dt = DateTime.Parse(time);
            //DateTime dt = DateTime.ParseExact(time, formatDate, CultureInfo.InvariantCulture);
            if (OnDateChanged!= null)
                OnDateChanged(dt);
        }

        public void PickerClosedEvent(string time)
        {
            DateTime dt = DateTime.Parse(time);
            //DateTime dt = DateTime.ParseExact(time, formatDate, CultureInfo.InvariantCulture);
            if (OnPickerClosed != null)
                OnPickerClosed(dt);
        }
    }
}
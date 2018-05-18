package com.pingak9.nativepopup;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.widget.DatePicker;
import android.widget.TimePicker;

import com.unity3d.player.UnityPlayer;

import java.util.Calendar;

/**
 * Created by PingAK9
 */
public class Bridge {

    static AlertDialog alertDialog;
    public static void ShowDialogNeutral(String title, String message, String accept, String neutral, String decline) {
        DismissCurrentAlert();
        alertDialog = new AlertDialog.Builder(UnityPlayer.currentActivity).create(); //Read Update
        alertDialog.setTitle(title);
        alertDialog.setMessage(message);

        alertDialog.setButton(accept, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogNeutral", "OnAcceptCallBack", "0");
            }
        });
        alertDialog.setButton2(neutral, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogNeutral", "OnNeutralCallBack", "1");
            }
        });
        alertDialog.setButton3(decline, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogNeutral", "OnDeclineCallBack", "2");
            }
        });
        alertDialog.show();
    }

    public static void ShowDialogConfirm(String title, String message, String yes, String no) {
        DismissCurrentAlert();
        alertDialog = new AlertDialog.Builder(UnityPlayer.currentActivity).create(); //Read Update
        alertDialog.setTitle(title);
        alertDialog.setMessage(message);

        alertDialog.setButton(yes, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogConfirm", "OnYesCallBack", "0");
            }
        });
        alertDialog.setButton2(no, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogConfirm", "OnNoCallBack", "1");
            }
        });
        alertDialog.show();
    }

    public static void ShowDialogInfo(String title, String message, String ok) {
        DismissCurrentAlert();
        alertDialog = new AlertDialog.Builder(UnityPlayer.currentActivity).create(); //Read Update
        alertDialog.setTitle(title);
        alertDialog.setMessage(message);

        alertDialog.setButton(ok, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogInfo", "OnOkCallBack", "0");
            }
        });


        alertDialog.show();
    }

    public static void DismissCurrentAlert() {
        if (alertDialog != null)
            alertDialog.hide();
    }
    public static void ShowDatePicker(int year, int month, int day) {
        DatePickerDialog datePickerDialog = new DatePickerDialog(UnityPlayer.currentActivity,
                new DatePickerDialog.OnDateSetListener() {

                    @Override
                    public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {

                        String s = String.format("%d-%d-%d %d:%d:%d", year, monthOfYear, dayOfMonth,0,0,0);
                        UnityPlayer.UnitySendMessage("MobileDateTimePicker", "PickerClosedEvent", s);
                    }
                },
                year, month, day);
        datePickerDialog.show();
    }

    public static void ShowTimePicker() {
        final Calendar c = Calendar.getInstance();
        int hour = c.get(Calendar.HOUR_OF_DAY);
        int minute = c.get(Calendar.MINUTE);

        // Create a new instance of TimePickerDialog and return it
        TimePickerDialog timePickerDialog = new TimePickerDialog(UnityPlayer.currentActivity,
                new TimePickerDialog.OnTimeSetListener() {
                    @Override
                    public void onTimeSet(TimePicker view, int hourOfDay, int minute) {

                        String s = String.format("%d-%d-%d %d:%d:%d",1970,1,1, hourOfDay, minute, 0);
                        UnityPlayer.UnitySendMessage("MobileDateTimePicker", "PickerClosedEvent", s);
                    }
                }, hour, minute, true);
        timePickerDialog.show();

    }
}

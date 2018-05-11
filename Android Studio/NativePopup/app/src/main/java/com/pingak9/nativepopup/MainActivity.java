package com.pingak9.nativepopup;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.widget.DatePicker;
import android.widget.TimePicker;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import java.util.Calendar;
import java.util.Date;


public class MainActivity extends UnityPlayerActivity
{
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "onCreate");

    }
    @Override
    public void onDestroy()    {
        super.onDestroy();
        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "onDestroy");
    }


    public void ShowDialogNeutral(String title, String message, String accept, String neutral, String decline) {
        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "ShowDialogNeutral");
        AlertDialog alertDialog = new AlertDialog.Builder(this).create(); //Read Update
        alertDialog.setTitle(title);
        alertDialog.setMessage(message);

        alertDialog.setButton(accept, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogNeutral", "OnAcceptCallBack", "0");
            }
        });
        alertDialog.setButton(neutral, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogNeutral", "OnNeutralCallBack", "1");
            }
        });
        alertDialog.setButton(decline, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogNeutral", "OnDeclineCallBack", "2");
            }
        });
        alertDialog.show();
    }

    public void ShowDialogConfirm(String title, String message, String yes, String no) {
        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "ShowDialogConfirm");
        AlertDialog alertDialog = new AlertDialog.Builder(this).create(); //Read Update
        alertDialog.setTitle(title);
        alertDialog.setMessage(message);

        alertDialog.setButton(yes, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogConfirm", "OnYesCallBack", "0");
            }
        });
        alertDialog.setButton(no, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogConfirm", "OnNoCallBack", "1");
            }
        });
        alertDialog.show();
    }

    public void ShowDialogInfo(String title, String message, String ok) {

        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "ShowDialogInfo");
        AlertDialog alertDialog = new AlertDialog.Builder(this).create(); //Read Update
        alertDialog.setTitle(title);
        alertDialog.setMessage(message);

        alertDialog.setButton(ok, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("MobileDialogInfo", "OnOkCallBack", "0");
            }
        });

        alertDialog.show();
    }

    public void DismissCurrentAlert() {

    }

    public void ShowDatePicker(double unix) {
        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "ShowDatePicker");
        long myLong = System.currentTimeMillis() + ((long) (unix * 1000));
        Date itemDate = new Date(myLong);

        int year = itemDate.getYear();
        int month =  itemDate.getMonth();
        int day =  itemDate.getDay();

        // Create a new instance of DatePickerDialog and return it
        DatePickerDialog datePickerDialog = new DatePickerDialog(this, onDateSetListener, year, month, day);
    }

    DatePickerDialog.OnDateSetListener   onDateSetListener ;

    {
        onDateSetListener = new DatePickerDialog.OnDateSetListener() {

            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {

                Date date = new Date();
                date.setYear(year);
                date.setMonth(monthOfYear);
                date.setDate(dayOfMonth);

                UnityPlayer.UnitySendMessage("MobileDateTimePicker", "PickerClosedEvent", date.toString());
                UnityPlayer.UnitySendMessage("MobileDateTimePicker", "DateChangedEvent", date.toString());
            }
        };
    }

    public void ShowTimePicker() {
        UnityPlayer.UnitySendMessage("PopupView", "DebugLog", "ShowTimePicker");
        // Use the current time as the default values for the picker
        final Calendar c = Calendar.getInstance();
        int hour = c.get(Calendar.HOUR_OF_DAY);
        int minute = c.get(Calendar.MINUTE);

        // Create a new instance of TimePickerDialog and return it
        TimePickerDialog timePickerDialog = new TimePickerDialog(this, onTimeSetListener, hour, minute, true);
    }
    TimePickerDialog.OnTimeSetListener  onTimeSetListener;

    {
        onTimeSetListener = new TimePickerDialog.OnTimeSetListener() {

            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {

                Date date = new Date();
                date.setHours(hourOfDay);
                date.setMinutes(minute);

                UnityPlayer.UnitySendMessage("MobileDateTimePicker", "PickerClosedEvent", date.toString());
                UnityPlayer.UnitySendMessage("MobileDateTimePicker", "DateChangedEvent", date.toString());
            }
        };
    }

}

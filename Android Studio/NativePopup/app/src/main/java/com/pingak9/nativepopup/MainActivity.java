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

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;


public class MainActivity extends UnityPlayerActivity
{
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }
    @Override
    public void onDestroy()    {
        super.onDestroy();
    }


    public void ShowDialogNeutral(String title, String message, String accept, String neutral, String decline) {
        AlertDialog alertDialog = new AlertDialog.Builder(this).create(); //Read Update
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

    public void ShowDialogConfirm(String title, String message, String yes, String no) {
        AlertDialog alertDialog = new AlertDialog.Builder(this).create(); //Read Update
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

    public void ShowDialogInfo(String title, String message, String ok) {

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

    public void ShowDatePicker(int year, int month, int day) {
        // Create a new instance of DatePickerDialog and return it
        DatePickerDialog datePickerDialog = new DatePickerDialog(this, onDateSetListener, year, month, day);
        datePickerDialog.show();
    }

    DatePickerDialog.OnDateSetListener   onDateSetListener ;

    {
        onDateSetListener = new DatePickerDialog.OnDateSetListener() {

            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {

                String s = String.format("%d-%d-%d %d:%d:%d", year, monthOfYear, dayOfMonth,0,0,0);
                UnityPlayer.UnitySendMessage("MobileDateTimePicker", "PickerClosedEvent", s);
            }
        };
    }

    public void ShowTimePicker() {
        // Use the current time as the default values for the picker
        final Calendar c = Calendar.getInstance();
        int hour = c.get(Calendar.HOUR_OF_DAY);
        int minute = c.get(Calendar.MINUTE);

        // Create a new instance of TimePickerDialog and return it
        TimePickerDialog timePickerDialog = new TimePickerDialog(this, onTimeSetListener, hour, minute, true);
        timePickerDialog.show();
    }
    TimePickerDialog.OnTimeSetListener  onTimeSetListener;

    {
        onTimeSetListener = new TimePickerDialog.OnTimeSetListener() {

            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {

                String s = String.format("%d-%d-%d %d:%d:%d",1970,1,1, hourOfDay, minute, 0);
                UnityPlayer.UnitySendMessage("MobileDateTimePicker", "PickerClosedEvent", s);
            }
        };
    }

}

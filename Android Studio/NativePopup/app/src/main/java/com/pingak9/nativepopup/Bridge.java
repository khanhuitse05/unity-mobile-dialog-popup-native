package com.pingak9.nativepopup;

import com.unity3d.player.UnityPlayer;

/**
 * Created by PingAK9
 */
public class Bridge {

    public static void ShowDialogNeutral(String title, String message, String accept, String neutral, String decline) {
        MainActivity activity = (MainActivity)UnityPlayer.currentActivity;
        activity.ShowDialogNeutral(title, message, accept, neutral, decline);
    }

    public static void ShowDialogConfirm(String title, String message, String yes, String no) {

        MainActivity activity = (MainActivity)UnityPlayer.currentActivity;
        activity.ShowDialogConfirm(title, message, yes, no);
    }

    public static void ShowDialogInfo(String title, String message, String ok) {

        MainActivity activity = (MainActivity)UnityPlayer.currentActivity;
        activity.ShowDialogInfo(title, message, ok);
    }

    public static void DismissCurrentAlert() {

        MainActivity activity = (MainActivity)UnityPlayer.currentActivity;
        activity.DismissCurrentAlert();
    }

    public static void ShowDatePicker(int year, int month, int day) {
        MainActivity activity = (MainActivity)UnityPlayer.currentActivity;
        activity.ShowDatePicker(year, month, day);
    }
    public static void ShowTimePicker() {
        MainActivity activity = (MainActivity)UnityPlayer.currentActivity;
        activity.ShowTimePicker();
    }
}

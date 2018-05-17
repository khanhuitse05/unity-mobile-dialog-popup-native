# Create Mobile Native Popup Using Unity
## Platform
- iOS
- Android
## Feature
- Ok, Yes/No, Neutral popup (Single, two, three action)

<img src="https://github.com/PingAK9/MobileDialog-Unity/blob/master/Img/AndroidBox.png"><img src="https://github.com/PingAK9/MobileDialog-Unity/blob/master/Img/iOSBox.png">

- DatePicker, TimePicker

<img src="https://github.com/PingAK9/MobileDialog-Unity/blob/master/Img/AndroidDate.png"><img src="https://github.com/PingAK9/MobileDialog-Unity/blob/master/Img/iOSDate.png">

## Easy access from Unity
Welcome to Native Popups for iOS and Android! This plugin provides easy access from Unity to the native functionality of iOS and Android for displaying popups
```
    public void OnDialogInfo()
    {
        NativeDialog.OpenDialog("Info popup", "Welcome To Native Popup", "Ok", 
            ()=> {
                Debug.Log("OK Button pressed");
            });
    }

    public void OnDialogConfirm()
    {
        NativeDialog.OpenDialog("Confirm popup", "Do you wants about app?", "Yes", "No",
            () => {
                Debug.Log("Yes Button pressed");
            },
            () => {
                Debug.Log("No Button pressed");
            });
    }
    public void OnDialogNeutral()
    {
        NativeDialog.OpenDialog("Like this game?", "Please rate to support future updates!", "Rate app", "later", "No, thanks",
            () =>
            {
                Debug.Log("Rate Button pressed");
            },
            () =>
            {
                Debug.Log("Later Button pressed");
            },
            () =>
            {
                Debug.Log("No Button pressed");
            });
    }

    public void OnDatePicker()
    {
        NativeDialog.OpenDatePicker(1992,5,10,
            (DateTime _date) =>
            {
                Debug.Log(_date.ToString());
            },
            (DateTime _date) =>
            {
                Debug.Log(_date.ToString());
            });        
    }
    public void OnTimePicker()
    {
        NativeDialog.OpenTimePicker(
            (DateTime _date) =>
            {
                Debug.Log(_date.ToString());
            },
            (DateTime _date) =>
            {
                Debug.Log(_date.ToString());
            });
    }
```
## Open source
I have provide all java and object c source.  you can know how it work, optimization, or add any features
### Android studio
- Unity call to static function
```
    AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.pingak9.nativepopup.Bridge");
    javaUnityClass.CallStatic("ShowDialogInfo", title, message, ok);
```
- Java show popup
```
    void ShowDialogInfo(String title, String message, String ok) {

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
```
- Build library jar and file jar to folder Plugins/Android
### Object C
- Unity call to C
```
    [DllImport("__Internal")]
    private static extern void _TAG_ShowDialogInfo(string title, string message, string ok);
```
- Object C show popup
```
+(void)ShowDialogInfo: (NSString *) title message: (NSString*) msg okTitle:(NSString*) b1 {
    
    UIAlertController *alertController = [UIAlertController alertControllerWithTitle:title message:msg preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:b1 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        [IOSNativePopUpsManager unregisterAllertView];
        UnitySendMessage("MobileDialogInfo", "OnOkCallBack",  [DataConvertor NSIntToChar:0]);
    }];
    [alertController addAction:okAction];
    
    
    [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
    _currentAllert = alertController;
}
```
- Copy file object C to folder Plugins/iOS


Happy coding!

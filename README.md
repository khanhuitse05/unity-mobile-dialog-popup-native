# Create Mobile Native Popup Using Unity
## Platform
- iOS
- Android
## Feature
- Ok, Yes/No, Neutral popup (Single, two, three action)
- DatePicker, TimePicker
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
- Java show popup
- Build library jar
- Copy file jar to folder Plugins/Android
### Object C
- Unity call to C
- Object C show popup
- Copy file object C to folder Plugins/iOS


Happy coding!

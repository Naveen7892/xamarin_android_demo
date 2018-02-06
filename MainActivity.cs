using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
//using System.Runtime.Remoting.Contexts;
using Android.Content;
using System;

/*
 * REFERENCES:
 * 
 * https://developer.xamarin.com/guides/android/getting_started/hello,android/hello,android_quickstart/
**/

namespace XamarinHelloWorld {
    [Activity (Label = "Phone Word", MainLauncher = true)]
    public class MainActivity : Activity {
        protected override void OnCreate (Bundle savedInstanceState) {
            base.OnCreate (savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            // New code will go here
            // Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText> (Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView> (Resource.Id.TranslatedPhoneWord);
            Button translateButton = FindViewById<Button> (Resource.Id.TranslateButton);

            // Add code to translate number
            translateButton.Click += (sender, e) =>
            {
                // Translate user’s alphanumeric phone number to numeric
                string translatedNumber = Core.PhonewordTranslator.ToNumber (phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace (translatedNumber)) {
                    translatedPhoneWord.Text = string.Empty;
                } else {
                    translatedPhoneWord.Text = translatedNumber;
                }
 
                // To hide keyboard on outside tap, not working
                //InputMethodManager imm = (InputMethodManager) GetSystemService (Context.InputMethodService);
                //imm.HideSoftInputFromInputMethod (this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
            };

        }

    }

}


using System;
using Xamarin.Forms;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using System.Collections.Generic;
using Android.Content.Res;
using Java.IO;
using Org.Apache.Http.Entity;
using Android;
using Android.Support.V4.App;
using Android.App.Usage;
using Android.Webkit;
using Android.Content;
using System.Runtime.Remoting.Contexts;
using Xamarin.Essentials;

namespace Recycler.Droid
{
    [Activity(Label = "Eco Assistant", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //По умолчанию
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);  //Инициализация бибилиотеки для кроссплатформенности
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);  //Инициализация платформы Xamarin
            //По умолчанию

            Stream stream = Assets.Open("ecoassistant.pdf");
            
            List<byte> b = new List<byte>();

            if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Permission.Granted 
                || CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 1);
            }
                
            string path = Application.GetDir("data",0).AbsolutePath + "/info.pdf";
            
            System.IO.File.Create(path);
			
            using (BinaryReader r = new BinaryReader(stream))
            {
                while(true)
                {
                    try
                    {
                        byte b1 = r.ReadByte();
                        b.Add(b1);
                    }
                    catch (EndOfStreamException) { break; }
                }
            }
            stream.Dispose();
			System.IO.File.WriteAllBytes(path, b.ToArray());
            
			LoadApplication(new App(path));
        }

        /// <summary>
        /// По умолчанию
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
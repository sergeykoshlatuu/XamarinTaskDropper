using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Plugin.PictureChooser;
using MvvmCross.Plugin.PictureChooser.Platforms.Android;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Services;

namespace TaskDropper.Droid.Services
{
    public class PhotoService : IPhotoService
    {
        public byte[] Photos
        {
            get;
            set; 
        }

        public PhotoService()
        {
            
        }
        public void ChoosePictureFromGallary(Action<byte[]> action)
        {
            var task = Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();
            task.ChoosePictureFromLibrary(400, 95, pictureStream => {
                var memoryStream = new MemoryStream();
                pictureStream.CopyTo(memoryStream);
                Photos = memoryStream.ToArray();
                action(Photos);
            }, () => { });
        }

        public void TakePictureFromCamera(Action<byte[]> action)
        {
           
               var task= Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();
                task.TakePicture(400, 95, pictureStream =>
                {
                    var memoryStream = new MemoryStream();
                    pictureStream.CopyTo(memoryStream);
                    Photos = memoryStream.ToArray();
                    action(Photos);
                }, () => { });
        }

        public bool CheckPermission()
        {

            if (ActivityCompat.CheckSelfPermission(Application.Context, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void OnPicture(Stream stream) 
        {
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            Photos = memoryStream.ToArray();
        }

        public byte[] GetPhoto()
        {
            throw new NotImplementedException();
        }

        static readonly int REQUEST_STORAGE = 0;

        static string[] PERMISSIONS_CONTACT = {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage
        };

        

    }
}
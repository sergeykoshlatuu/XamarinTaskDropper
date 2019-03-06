using System;
using System.IO;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Support.V4.App;
using MvvmCross;
using MvvmCross.Plugin.PictureChooser;
using TaskDropper.Core.Interface;

namespace TaskDropper.Forms.Droid.Services
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
        public void ChoosePictureFromGallery(Action<byte[]> action)
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

            var task = Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();
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
            return Photos;
        }

        static readonly int REQUEST_STORAGE = 0;

        static string[] PERMISSIONS_CONTACT = {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage
        };



    }
}
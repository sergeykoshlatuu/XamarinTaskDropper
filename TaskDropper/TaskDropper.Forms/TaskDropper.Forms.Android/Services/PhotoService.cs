using System;
using Android.Support.V4.App;
using Android;
using MvvmCross.Plugin.PictureChooser;
using TaskDropper.Core.Interface;
using MvvmCross;
using System.IO;

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
            if (ActivityCompat.CheckSelfPermission(Android.App.Application.Context, Manifest.Permission.WriteExternalStorage) == (Android.Content.PM.Permission.Granted)&&
                ActivityCompat.CheckSelfPermission(Android.App.Application.Context, Manifest.Permission.Camera) == (Android.Content.PM.Permission.Granted))
            {
                return true;
            }
            return false;
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
    }
}
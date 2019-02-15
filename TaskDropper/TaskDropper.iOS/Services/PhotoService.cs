using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross;
using MvvmCross.Plugin.PictureChooser;
using TaskDropper.Core.Interface;
using UIKit;

namespace TaskDropper.iOS.Services
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
            return true;
            //if (ActivityCompat.CheckSelfPermission(Application.Context, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
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

       


    }
}

using System;
using System.IO;
using MvvmCross;
using MvvmCross.Plugin.PictureChooser;
using TaskDropper.Core.Interface;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
        public void ChoosePictureFromGallery(Action<byte[]> action)
        {
            var task = Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();

                task.ChoosePictureFromLibrary(400, 95, pictureStream =>
                {
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
            //iOS automaticly check permission 
            return true;
        }


        public byte[] GetPhoto()
        {
            return Photos;
        }

       


    }
}

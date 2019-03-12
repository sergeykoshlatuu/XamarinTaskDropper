using System;
using System.IO;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Support.V4.App;
using MvvmCross;
using MvvmCross.Plugin.PictureChooser;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TaskDropper.Core.Interface;

namespace TaskDropper.Droid.Services
{
    public class PhotoService : IPhotoService
    {
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
                action(memoryStream.ToArray());
            }, () => { });
        }

        public async void TakePictureFromCamera(Action<byte[]> action)
        {
            var task = Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();
            if (await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage) != PermissionStatus.Granted ||
                      await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Camera) != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Storage, Plugin.Permissions.Abstractions.Permission.Camera);
                //Best practice to always check that the key exists                    
            }
            if (await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage) == PermissionStatus.Granted ||
                      await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Camera) == PermissionStatus.Granted)
            {
                task.TakePicture(400, 95, pictureStream =>
                {
                    var memoryStream = new MemoryStream();
                    pictureStream.CopyTo(memoryStream);
                    action(memoryStream.ToArray());
                }, () => { });
            }
        }

        
        
      
    }
}

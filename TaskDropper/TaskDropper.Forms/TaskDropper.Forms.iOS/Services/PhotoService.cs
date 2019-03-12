using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using MvvmCross;
using MvvmCross.Plugin.PictureChooser;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TaskDropper.Core.Interface;
using TaskDropper.Forms.Pages;
using UIKit;
using Xamarin.Forms;

namespace TaskDropper.Forms.iOS.Services
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
                MessagingCenter.Send<Page>(new TaskChangePage(), "iosPermission");
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Storage, Plugin.Permissions.Abstractions.Permission.Camera);
                //Best practice to always check that the key exists
                return;
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


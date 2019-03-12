using TaskDropper.Core.Interface;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace TaskDropper.Forms.Droid.Services
{
    public class PermissionService : IPermissionService
    {

        public async void AddPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                //Best practice to always check that the key exists            
            }
            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Camera);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Camera);
                //Best practice to always check that the key exists            
            }
        }
    }
}
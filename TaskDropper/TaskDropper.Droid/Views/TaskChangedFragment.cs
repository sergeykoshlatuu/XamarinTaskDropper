using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using TaskDropper.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Widget;
using static Android.Content.ClipData;
using Android.Support.V4.Content;
using Android;
using Android.Content.PM;
using Android.App;
using Android.Support.V4.App;
using Android.Util;
using Android.Support.Design.Widget;

namespace TaskDropper.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class TaskChangedFragment : BaseFragment<TaskChangedViewModel>
    {
        protected override int FragmentId => Resource.Layout.item_changed;

        static readonly int REQUEST_STORAGE = 0;

        static string[] PERMISSIONS_CONTACT = {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage
        };
        View layout;

        private LinearLayout _linearLayoutMain;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            Typeface newTypeface = Typeface.CreateFromAsset(Activity.Assets, "NK123.otf");
            Button showPopupMenu = view.FindViewById<Button>(Resource.Id.OpenPopup);

            var DettachPhoto = view.FindViewById<Button>(Resource.Id.DettachPhoto);

            DettachPhoto.Click += delegate
            {
                HideImage();
            };

            showPopupMenu.Click += (s, arg) => {

                PopupMenu menu = new PopupMenu(Context, showPopupMenu);
                

                // Call inflate directly on the menu:
                menu.Inflate(Resource.Menu.popup_menu);

                // A menu item was clicked:
                menu.MenuItemClick += (s1, arg1) => {

                        if (arg1.Item.ItemId == Resource.Id.FromGallary)
                        {
                            ViewModel.ChoosePictureCommand.Execute();

                        }
                    
                    if (arg1.Item.ItemId == Resource.Id.FromCamera)
                        {
                        if (ActivityCompat.CheckSelfPermission(Context, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
                        {
                            ViewModel.TakePictureCommand.Execute();
                        }

                        else
                        {
                            RequestStoragePermission();
                        }
                    }
                };

                // Menu was dismissed:
                menu.DismissEvent += (s2, arg2) => {
                    Console.WriteLine("menu dismissed");
                };

                menu.Show();
            };

           
            view.FindViewById<EditText>(Resource.Id.title_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<EditText>(Resource.Id.description_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<CheckBox>(Resource.Id.status_check).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<TextView>(Resource.Id.done_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.Savetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.Deletetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<TextView>(Resource.Id.app_name_text).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.OpenPopup).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.DettachPhoto).SetTypeface(newTypeface, TypefaceStyle.Normal);
            

            _linearLayoutMain = view.FindViewById<LinearLayout>(Resource.Id.main_layout);
            _linearLayoutMain.Click += delegate
            {
                HideSoftKeyboard();
            };

            var _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _toolbar.Click += delegate
            {
                HideSoftKeyboard();
            };

            var addtask_button = view.FindViewById<ImageButton>(Resource.Id.addtask_button);
            addtask_button.Visibility = ViewStates.Invisible;
            var back_button = view.FindViewById<ImageButton>(Resource.Id.back_button);
            back_button.Visibility = ViewStates.Visible;


            return view;
        }

        private void HideImage()
        {
            var image = View.FindViewById<ImageView>(Resource.Id.imageview);
            image.SetImageBitmap(null);
        }

        public void HideSoftKeyboard()
        {
            InputMethodManager close = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            close.HideSoftInputFromWindow(_linearLayoutMain.WindowToken, 0);
        }

        void RequestStoragePermission()
        {
            Log.Info("TaskDropper", "CAMERA permission has NOT been granted. Requesting permission.");

            if (ActivityCompat.ShouldShowRequestPermissionRationale(ParentActivity, Manifest.Permission.WriteExternalStorage))
            {
                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example if the user has previously denied the permission.
                Log.Info("TaskDropper", "Displaying storage permission rationale to provide additional context.");

                Snackbar.Make(layout,"Storage Permission",
                     Snackbar.LengthIndefinite).SetAction(Resource.String.ok, new Action<View>(delegate (View obj) {
                         ActivityCompat.RequestPermissions(ParentActivity, new String[] { Manifest.Permission.Camera }, REQUEST_STORAGE);
                     })).Show();
            }
            else
            {
                // Camera permission has not been granted yet. Request it directly.
                ActivityCompat.RequestPermissions(ParentActivity, new String[] { Manifest.Permission.WriteExternalStorage }, REQUEST_STORAGE);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == REQUEST_STORAGE)
            {
                // Received permission result for camera permission.
                Log.Info("TaskDropper", "Received response for Camera permission request.");

                // Check if the only required permission has been granted
                if (grantResults.Length == 1 && grantResults[0] == Permission.Granted)
                {
                    // Camera permission has been granted, preview can be displayed
                    Log.Info("TaskDropper", "CAMERA permission has now been granted. Showing preview.");
                    Snackbar.Make(layout, Resource.String.permission_available_camera, Snackbar.LengthShort).Show();
                }
                else
                {
                    Log.Info("TaskDropper", "CAMERA permission was NOT granted.");
                    Snackbar.Make(layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

    }
}

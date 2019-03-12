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
using TaskDropper.Core.Services;
using TaskDropper.Droid.Services;
using Plugin.Permissions;
using Android.Runtime;

namespace TaskDropper.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class TaskChangedFragment : BaseFragment<TaskChangedViewModel>
    {
        protected override int FragmentId => Resource.Layout.item_changed;
        Button saveButton;
        Button deleteButton;
        static readonly int REQUEST_STORAGE = 0;
        Android.Support.V7.Widget.Toolbar _toolbar;
        Button DettachPhoto;
        Button showPopupMenu;
        private LinearLayout _linearLayoutMain;
        private ScrollView _scrollView;
       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            showPopupMenu = view.FindViewById<Button>(Resource.Id.OpenPopup);
            DettachPhoto = view.FindViewById<Button>(Resource.Id.DettachPhoto);
            DettachPhoto.Click += HideImage;
            SetupPopupMenu(view);
            //fonts
            SetupFonts(view);
            //Hide Keyboard
          
            CheckInternetConnection(view);

            SetupHideKeyboard(view);
            //Seting Action Bar
            SetupBackActionBar(view);

            return view;
        }
        
        public void CheckInternetConnection(View view)
        {
             saveButton = view.FindViewById<Button>(Resource.Id.Savetask);
             deleteButton = view.FindViewById<Button>(Resource.Id.Deletetask);

            saveButton.Click += ShowMessage;
            deleteButton.Click += ShowMessage;
        }

       public void  ShowMessage(Object sender, EventArgs e)
        {
            if (!ViewModel.CheckInternetConnection())
            {
                new AlertDialog.Builder(this.Context)
                                   .SetTitle("Eror")
                                   .SetMessage("No internet connection ")
                                   .Show();
            }
        }
         public void SetupFonts(View view)
        {
            Typeface newTypeface = Typeface.CreateFromAsset(Activity.Assets, "NK123.otf");
            view.FindViewById<EditText>(Resource.Id.title_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<EditText>(Resource.Id.description_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<CheckBox>(Resource.Id.status_check).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<TextView>(Resource.Id.done_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.Savetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.Deletetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<TextView>(Resource.Id.app_name_text).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.OpenPopup).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.DettachPhoto).SetTypeface(newTypeface, TypefaceStyle.Normal);
        }

        public void SetupPopupMenu(View view)
        {
            showPopupMenu.Click += ShowPopupMenu;

        }
         
        private void ShowPopupMenu(Object sender, EventArgs e)
        {
            PopupMenu menu = new PopupMenu(Context, showPopupMenu);

            // Call inflate directly on the menu:
            menu.Inflate(Resource.Menu.popup_menu);

            // A menu item was clicked:
            menu.MenuItemClick += PopupMenuItemClick;

            menu.Show();
        }

        private void PopupMenuItemClick(object s1, PopupMenu.MenuItemClickEventArgs arg1)
        {
            if (arg1.Item.ItemId == Resource.Id.FromGallary)
            {
                ViewModel.ChoosePictureCommand.Execute();
            }

            if (arg1.Item.ItemId == Resource.Id.FromCamera)
            {
                ViewModel.TakePictureCommand.Execute();
            }
            
        }
        public void SetupHideKeyboard(View view)
        {
            _linearLayoutMain = view.FindViewById<LinearLayout>(Resource.Id.content);
            _linearLayoutMain.Click += HideSoftKeyboard;

            _scrollView = view.FindViewById<ScrollView>(Resource.Id.scrollingElement);
            _scrollView.Click += HideSoftKeyboard;

            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _toolbar.Click += HideSoftKeyboard;          
        }

        private void HideImage(Object sender,EventArgs e)
        {
            var image = View.FindViewById<ImageView>(Resource.Id.imageview);
            image.SetImageBitmap(null);
        }

        public void HideSoftKeyboard(Object sender, EventArgs e)
        {
            InputMethodManager close = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            close.HideSoftInputFromWindow(_linearLayoutMain.WindowToken, 0);
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            DettachPhoto.Click -= HideSoftKeyboard;

            _linearLayoutMain.Click -= HideSoftKeyboard;

            _scrollView.Click -= HideSoftKeyboard;
            
            _toolbar.Click -= HideSoftKeyboard;

            saveButton.Click -= ShowMessage;

            deleteButton.Click -= ShowMessage;

            showPopupMenu.Click -= ShowPopupMenu;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

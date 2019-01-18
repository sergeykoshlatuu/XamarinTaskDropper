﻿using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using TaskDropper.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Widget;

namespace TaskDropper.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class TaskChangedFragment : BaseFragment<TaskChangedViewModel>
    {
        protected override int FragmentId => Resource.Layout.item_changed;
        private LinearLayout _linearLayoutMain;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            Button showPopupMenu = view.FindViewById<Button>(Resource.Id.OpenPopup);

            showPopupMenu.Click += (s, arg) => {

                PopupMenu menu = new PopupMenu(Context, showPopupMenu);

                // Call inflate directly on the menu:
                menu.Inflate(Resource.Menu.popup_menu);

                // A menu item was clicked:
                menu.MenuItemClick += (s1, arg1) => {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                    if (arg1.Item.ItemId == Resource.Id.FromGallary)
                    {
                        ViewModel.ChoosePictureCommand.Execute();
                    }
                    if (arg1.Item.ItemId == Resource.Id.FromCamera)
                    { 
                        ViewModel.TakePictureCommand.Execute();
                    }
                };

                // Menu was dismissed:
                menu.DismissEvent += (s2, arg2) => {
                    Console.WriteLine("menu dismissed");
                };

                menu.Show();
            };

            Typeface newTypeface = Typeface.CreateFromAsset(Activity.Assets, "NK123.otf");
            view.FindViewById<EditText>(Resource.Id.title_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<EditText>(Resource.Id.description_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<CheckBox>(Resource.Id.status_check).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<TextView>(Resource.Id.done_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.Savetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<Button>(Resource.Id.Deletetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            view.FindViewById<TextView>(Resource.Id.app_name_text).SetTypeface(newTypeface, TypefaceStyle.Normal);

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

        public void HideSoftKeyboard()
        {
            InputMethodManager close = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            close.HideSoftInputFromWindow(_linearLayoutMain.WindowToken, 0);
        }

        

    }
}

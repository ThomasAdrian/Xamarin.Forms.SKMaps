﻿// **********************************************************************
// 
//   AppDelegate.cs
//   
//   This file is subject to the terms and conditions defined in
//   file 'LICENSE.txt', which is part of this source code package.
//   
//   Copyright (c) 2017, Le rond-point
// 
// ***********************************************************************
using MvvmCross.iOS.Platform;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using UIKit;
using Xamarin.Forms;
using FormsSkiaBikeTracker;
using LRPLib;
using LRPLib.Mvx.iOS;
using LRPLib.Mvx.Views.XForms.iOS;
using LRPLib.Views.XForms.iOS;

[assembly: ResolutionGroupName(Constants.GeneralNamespace)]
namespace FormsSkiaBikeTracker.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            var setup = new Setup(this, _window);
            setup.Initialize();

            LrpLib.Init();
            LrpLibMvx.Init();
            LrpLibViews.Init();
            LrpLibMvxViews.Init();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            _window.MakeKeyAndVisible();

            return true;
        }
    }
}
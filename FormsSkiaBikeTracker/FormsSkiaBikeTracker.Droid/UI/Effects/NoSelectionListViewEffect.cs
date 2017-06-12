﻿using System.Linq;
using FormsSkiaBikeTracker.Droid.UI.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NativeListView = Android.Widget.ListView;
using SharedNoSelectionEffect = FormsSkiaBikeTracker.Forms.UI.Effects.NoSelectionListViewEffect;

[assembly: ExportEffect(typeof(NoSelectionListViewEffect), nameof(NoSelectionListViewEffect))]
namespace FormsSkiaBikeTracker.Droid.UI.Effects
{
    class NoSelectionListViewEffect : PlatformEffect
    {
        private NativeListView _NativeControl => Control as NativeListView;
        private SharedNoSelectionEffect _Effect => Element.Effects.FirstOrDefault(e => e is SharedNoSelectionEffect) as SharedNoSelectionEffect;

        protected override void OnAttached()
        {
            _NativeControl.SetSelector(Resource.Layout.no_selector);
        }

        protected override void OnDetached()
        {
        }
    }
}

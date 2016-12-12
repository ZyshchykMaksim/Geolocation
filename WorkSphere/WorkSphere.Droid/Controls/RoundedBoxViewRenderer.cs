using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WorkSphere.Controls;
using WorkSphere.Droid.Controls;
using WorkSphere.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace WorkSphere.Droid.Controls
{

    public sealed class RoundedBoxViewRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<RoundedBoxView, View>
    {
        public static void Init()
        {
        }

        private RoundedBoxView _formControl
        {
            get { return Element; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView> e)
        {
            base.OnElementChanged(e);

            this.InitializeFrom(_formControl);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            this.UpdateFrom(_formControl, e.PropertyName);
        }
    }
}
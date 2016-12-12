using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WorkSphere.Controls;
using WorkSphere.iOS.Controls;
using WorkSphere.iOS.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace WorkSphere.iOS.Controls
{
    [Preserve(AllMembers = true)]
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        /// <summary>
        ///   Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        private RoundedBoxView _formControl
        {
            get { return Element as RoundedBoxView; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
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

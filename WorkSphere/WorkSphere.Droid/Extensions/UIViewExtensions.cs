using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using WorkSphere.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace WorkSphere.Droid.Extensions
{
    public static class UIViewExtensions
    {
        public static void InitializeFrom(this View nativeControl, RoundedBoxView formsControl)
        {
            if (nativeControl == null || formsControl == null)
                return;

            var background = new GradientDrawable();

            background.SetColor(formsControl.BackgroundColor.ToAndroid());

            if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
            {
                nativeControl.Background = background;
            }
            else
            {
                nativeControl.SetBackgroundDrawable(background);
            }

            nativeControl.UpdateCornerRadius(formsControl.CornerRadius);
            nativeControl.UpdateBorder(formsControl.BorderColor, formsControl.BorderThickness);
        }

        public static void UpdateFrom(this View nativeControl, RoundedBoxView formsControl,
          string propertyChanged)
        {
            if (nativeControl == null || formsControl == null)
                return;

            if (propertyChanged == RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                nativeControl.UpdateCornerRadius(formsControl.CornerRadius);
            }
            if (propertyChanged == VisualElement.BackgroundColorProperty.PropertyName)
            {
                var background = nativeControl.Background as GradientDrawable;

                if (background != null)
                {
                    background.SetColor(formsControl.BackgroundColor.ToAndroid());
                }
            }

            if (propertyChanged == RoundedBoxView.BorderColorProperty.PropertyName)
            {
                nativeControl.UpdateBorder(formsControl.BorderColor, formsControl.BorderThickness);
            }

            if (propertyChanged == RoundedBoxView.BorderThicknessProperty.PropertyName)
            {
                nativeControl.UpdateBorder(formsControl.BorderColor, formsControl.BorderThickness);
            }
        }

        public static void UpdateBorder(this View nativeControl, Color color, int thickness)
        {
            var backgroundGradient = nativeControl.Background as GradientDrawable;

            if (backgroundGradient != null)
            {
                var relativeBorderThickness = (int)System.Math.Round(Xamarin.Forms.Forms.Context.ToPixels(thickness)); //#46
                backgroundGradient.SetStroke(relativeBorderThickness, color.ToAndroid());
            }
        }

        public static void UpdateCornerRadius(this View nativeControl, double cornerRadius)
        {
            var backgroundGradient = nativeControl.Background as GradientDrawable;

            if (backgroundGradient != null)
            {
                var relativeCornerRadius = Xamarin.Forms.Forms.Context.ToPixels(cornerRadius); //#46
                backgroundGradient.SetCornerRadius(relativeCornerRadius);
            }
        }
    }
}
using SnookerClubApp.Animations.FrameworkElementAnimations;

using System.Collections.Generic;
using System.Windows;

namespace SnookerClubApp.Animations.FrameworkElementAnimations
{
    public class SlideCollapseAndFadeWithLeft : BaseFrameworkElementAnimation<SlideCollapseAndFadeWithLeft>
    {
        private double Height = 0;

        private Thickness elementMargin;

        private Thickness parentMargin;

        //Animates the object
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (FirstLoad)
            {
                Height = element.Height;
                elementMargin = element.Margin;
                parentMargin = (element.Parent as FrameworkElement).Margin;
            }

            if (value)
            {
                element.Margin = elementMargin;
                (element.Parent as FrameworkElement).Margin = parentMargin;

                await element.Expand(Height, FirstLoad ? 0 : 0.3);
                await element.SlideAndFadeInFromLeft(element.ActualWidth, FirstLoad ? 0 : 0.3);
            }
            else
            {
                await element.SlideAndFadeOutToLeft(element.ActualWidth, FirstLoad ? 0 : 0.3, false);
                await element.Collapse(Height, FirstLoad ? 0 : 0.3);

                element.Margin = new Thickness(0);
                (element.Parent as FrameworkElement).Margin = new Thickness(0);
            }
        }
    }

    public class CollapseAndExpand : BaseFrameworkElementAnimation<CollapseAndExpand>
    {
        /// <summary>
        /// The heights of elements for this animation
        /// </summary>
        private Dictionary<FrameworkElement, double> ElementHeights { get; set; } = new Dictionary<FrameworkElement, double>();

        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            double height = element.Height;
            if (height.Equals(double.NaN))
            {
                return;
            }

            if (!ElementHeights.ContainsKey(element))
            {
                ElementHeights.Add(element, height);
            }

            if (value)
            {
                await element.Expand(ElementHeights[element], FirstLoad ? 0 : 0.2);
            }
            else
            {
                await element.Collapse(ElementHeights[element], FirstLoad ? 0 : 0.2);
            }
        }
    }

    public class FadeInAndOut : BaseFrameworkElementAnimation<FadeInAndOut>
    {
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (value)
                await element.FadeIn(FirstLoad ? 0 : 0.3);
            else
                await element.FadeOut(FirstLoad ? 0 : 0.3);
        }

    }

    /// <summary>
    /// Slides an element in and out from top
    /// </summary>
    public class SlideWithTop : BaseFrameworkElementAnimation<SlideWithTop>
    {
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (value)
                await element.SlideInFromTop(element.Height, FirstLoad ? 0 : 0.3);
            else
                await element.SlideOutToTop(element.Height, FirstLoad ? 0 : 0.3);

        }
    }

}

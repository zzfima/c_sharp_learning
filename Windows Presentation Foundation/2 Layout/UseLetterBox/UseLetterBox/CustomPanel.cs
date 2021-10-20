using System;
using System.Windows;
using System.Windows.Controls;

namespace UseLetterBox
{
    public class CustomPanel : Panel
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            var v = this.Children;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size sumSize = new Size();

            foreach (UIElement item in Children)
            {
                item.Measure(availableSize);
                sumSize.Width += item.DesiredSize.Width;
                sumSize.Height += item.DesiredSize.Height;
            }

            return sumSize;
        }
    }
}

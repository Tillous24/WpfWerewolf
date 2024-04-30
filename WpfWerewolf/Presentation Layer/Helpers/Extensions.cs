using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace WpfWerewolf.Presentation_Layer.Helpers
{
    internal static class Extensions
    {
        internal static T FindVisualChildByName<T>(this DependencyObject parent, string name) where T : FrameworkElement
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                FrameworkElement framewrkElemnt = child as FrameworkElement;

                if (framewrkElemnt != null && framewrkElemnt.Name == name)
                {
                    return (T)(object)framewrkElemnt;
                }

                T grandChild = FindVisualChildByName<T>(child, name);
                if (grandChild != null)
                {
                    return grandChild;
                }
            }

            return null;
        }

        
    }
}

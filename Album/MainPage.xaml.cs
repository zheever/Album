using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Album
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        LinearGradientBrush colorBrush = new LinearGradientBrush(); 

        public MainPage()
        {
            this.InitializeComponent();
            GradientColorBrushInit();
        }

        private void Panel_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RelativePanel panel = sender as RelativePanel;
            panel.Background = colorBrush;
        }

        private void Panel_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RelativePanel panel = sender as RelativePanel;
            panel.Background = null;
        }

        private void BeginRelativePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var colorBrush = new SolidColorBrush(Color.FromArgb(170, 0, 0, 0));
            RelativePanel panel = sender as RelativePanel;
            panel.Background = colorBrush;
            this.Frame.Navigate(typeof(GamePage));
        }

        private void GradientColorBrushInit()
        {
            colorBrush.StartPoint = new Point(0, 0);
            colorBrush.EndPoint = new Point(1, 1);
            var g1 = new GradientStop();
            g1.Color = Color.FromArgb(200, 0, 0, 0);
            g1.Offset = 0.0;

            var g2 = new GradientStop();
            g2.Color = Color.FromArgb(100, 0, 0, 0);
            g2.Offset = 0.25;

            var g3 = new GradientStop();
            g3.Color = Color.FromArgb(0, 0, 0, 0);
            g3.Offset = 1.0;
            var gstopColl = new GradientStopCollection();
            gstopColl.Add(g1);
            gstopColl.Add(g2);
            gstopColl.Add(g3);
            colorBrush.GradientStops = gstopColl;
        }

        private void RulePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var i = new MessageDialog("选择与音乐匹配的的专辑封面，获得相应的分数，让您找回失去的音乐记忆。").ShowAsync();
        }

        private void ThanksPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ThanksPage));
        }

        private void ExitPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}

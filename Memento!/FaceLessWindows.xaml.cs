using Memento_.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Memento_
{
    /// <summary>
    /// Interaction logic for FaceLessWindows.xaml
    /// </summary>
    public partial class FaceLessWindows : Window
    {
        public string Text
        {
            set
            {
                mainTextBox.Text = value != String.Empty ? value : "Xamarin";
            }
            get { return mainTextBox.Text; }
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        public FaceLessWindows()
        {
           // var temp = EventManager.GetRoutedEvents();

            InitializeComponent();
             Loaded += (sender, e) =>
             {
                 var hwnd = new WindowInteropHelper(this).Handle;
                 SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
             };

            

                var dis = Application.Current.Dispatcher;

                var timer = new System.Timers.Timer(6000) { AutoReset = true, Enabled = true };
                timer.Elapsed += (sender, e) =>
                {
                    var list = new List<Color>(6);
                    for (int i = 0; i < 6; i++)
                        list.Add(Helpers.GetRandColor());

                    dis.Invoke(() => TimerUpdate(list));
                };
                timer.Start();
            


        }

         void TimerUpdate(List<Color> randColors)
         {

            color0.Color = randColors[5];
            color1.Color = randColors[0];

            color2.Color = randColors[1];

            color3.Color = randColors[2];

            color4.Color = randColors[3];

            color5.Color = randColors[4];
         }


        
    }
}

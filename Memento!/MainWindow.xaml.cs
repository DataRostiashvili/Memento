using Memento_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memento_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var windows = new List<Window>();


            int ind = 0;

            int margin = 0;
            const int MAX_LEFT_OFFSET = 1369, MAX_TOP_OFFSET = 768;
            foreach (var item in RunTimeData.MemorizableItems)
            {
                
                windows.Add(new FaceLessWindows { WindowStyle = WindowStyle.None, Text = item.Value });
                windows[ind].WindowStartupLocation = WindowStartupLocation.Manual;
                windows[ind].WindowStyle = WindowStyle.None;

                int left = 0, top = 0;
                switch(item.PositionToScreen)
                {
                    case 0: left = margin; top = margin; break;
                    case 1: top = MAX_TOP_OFFSET / 2; left = margin; break;
                    case 2: top = MAX_TOP_OFFSET - margin; left = margin; break;

                    case 3: left = MAX_LEFT_OFFSET / 2; top = margin; break;
                    case 4: left = MAX_LEFT_OFFSET / 2; top = MAX_TOP_OFFSET / 2; break;
                    case 5: left = MAX_LEFT_OFFSET / 2; top = MAX_TOP_OFFSET - margin;  break;

                    case 6: left = MAX_LEFT_OFFSET - margin ; top = margin; break;
                    case 7: left = MAX_LEFT_OFFSET - margin; top = MAX_TOP_OFFSET / 2; break;
                    case 9: left = MAX_LEFT_OFFSET - margin ; top = MAX_TOP_OFFSET - margin; break;

                    default:
                        throw new Exception("unsopported");

                }

                windows[ind].Left = left;
                windows[ind].Top = top;

                ind++;
            }

            foreach (var i in windows)
                i.Show();
            new FaceLessWindows { WindowStyle = WindowStyle.None }.Show();
            Hide();
        }
    }
}

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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Ink;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool lose = false;
        int x = 8;
        int y = 4;

        int round = 0;
        int way = 0;
        int leng = 10;

        List<int> xs = new List<int>();
        List<int> ys = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            

        }

        public void Snake(object source, EventArgs e)
        {
            round++;
            main.Children.Clear();
            switch (way)
            {
                case 0:
                    if (y == 8)
                    {
                        y = 0;
                    }
                    else
                    {
                        y++;
                    }
                    break;

                case 1:
                    if (x == 15)
                    {
                        x = 0;
                    }
                    else
                    {
                        x++;
                    }
                    break;

                case 2:
                    if (y == 0)
                    {
                        y = 8;
                    }
                    else
                    {
                        y--;
                    }
                    break;

                case 3:
                    if (x == 0)
                    {
                        x = 15;
                    }
                    else
                    {
                        x--;
                    }
                    break;
            }
            listup();
            Draw();
        }
        Rectangle head = new Rectangle
        {
            Height = 100,
            Width = 100,
            Fill = new SolidColorBrush(Color.FromRgb(0, 128, 0))
        };

        public void Draw()
        {
            
            main.Children.Add(head);
            Canvas.SetLeft(head, x * 100);
            Canvas.SetTop(head, y * 100);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer myTimer = new DispatcherTimer();
            myTimer.Tick += new EventHandler(Snake);
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            xs.Add(0);
            ys.Add(0);

            for (int i = 0; i < leng; i++)
            {
                xs.Add(0);
                ys.Add(0);
            }

            myTimer.Start();

           
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.W)
            {
                way = 2;
            }
            else if (e.Key == Key.S)
            {
                way = 0;
            }
            else if(e.Key == Key.D)
            {
                way = 1;
            }
            else if(e.Key == Key.A)
            {
                way = 3;
            }
        }

        public void listup()
        {
            for(int i = leng; i > 0; i--)
            {
                xs[i] = xs[i -1];
                ys[i] = ys[i -1];
            }
            xs[0] = x;
            ys[0] = y;

            for(int i = leng; i > 0; i--)
            {
                drawexces(xs[i], ys[i], main);
            }
        }

        private void drawexces(int x, int y, Canvas c)
        {
            Rectangle body = new Rectangle 
            {
                Height = 100,
                Width = 100,
                Fill = new SolidColorBrush(Color.FromRgb(128, 0, 0))
            };

            
            c.Children.Add(body);
            Canvas.SetLeft(body, x * 100);
            Canvas.SetTop(body, y * 100);
        }
    }
}

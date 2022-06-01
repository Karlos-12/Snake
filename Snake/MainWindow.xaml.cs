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
        int scores = 0;
        int speed = 300;

        int x = 8;
        int y = 4;

        int xkostka = 0;
        int ykostka = 0;

        int round = 0;
        int way = 0;
        int leng = 5;

        List<int> xs = new List<int>();
        List<int> ys = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }
        Rectangle kostka = new Rectangle
        {
            Height = 100,
            Width = 100,
            Fill = new SolidColorBrush(Color.FromRgb(128, 128, 0))
        };

        public void scored()
        {
            scores += 10;
            if(scores <= 9)
            {
                score.Content = "000" + scores;
            }
            else if (scores <= 99)
            {
                score.Content = "00" + scores;
            }
            else if (scores <= 999)
            {
                score.Content = "0" + scores;
            }

        }

        public void genratorjakdebil()
        {
            
            Random random = new Random();
            bool does = true;
            do
            {  
                ykostka = random.Next(8);
                xkostka = random.Next(8);
                for(int i = xs.Count - 1; i > 0; i--)
                {
                    if(xs[i] != xkostka && ys[i] != ykostka)
                    {
                        does = false;
                    }
                }
            }
            while(does == true);
            
        }
        int exercontrolníhovno = 0;

        public void Snake(object source, EventArgs e)
        {
            exercontrolníhovno--;
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
                    if (x == 16)
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
                        x = 16;
                    }
                    else
                    {
                        x--;
                    }
                    break;
            }
            listup();
            Draw();

            for(int i = xs.Count - 1; i > 0; i--)
            {
                if (xs[i] == x && ys[i] == y)
                {
                    ende();
                }
            }
            if(exercontrolníhovno < 0)
            {
                if (x == xkostka && y == ykostka)
                {
                    scored();
                    speed -= 25;
                    myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);
                    genratorjakdebil();
                    leng++;
                }
            }

           if(exercontrolníhovno == 0)
            {
                genratorjakdebil();
            }

            main.Children.Add(kostka);
            Canvas.SetLeft(kostka, xkostka * 100);
            Canvas.SetTop(kostka, ykostka * 100);
        }

        public void ende()
        {
            MessageBox.Show("najs more si debil fakt chudák žížala");
            myTimer.Stop();
            main.Children.Clear();
        }

        Rectangle head = new Rectangle
        {
            Height = 100,
            Width = 100,
            Fill = new ImageBrush{
                ImageSource = new BitmapImage(new Uri(@"hlava more.png", UriKind.Relative))
            }
            };

        public void Draw()
        {         
            main.Children.Add(head);
            Canvas.SetLeft(head, x * 100);
            Canvas.SetTop(head, y * 100);
        }
        DispatcherTimer myTimer = new DispatcherTimer();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myTimer = new DispatcherTimer();
            exercontrolníhovno = leng;

            myTimer.Tick += new EventHandler(Snake);
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);

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
            int savyx = 0;
            int svaey = 0;
            for(int i = leng; i > 0; i--)
            {
                if(i > xs.Count-1 || i > ys.Count-1)
                {
                    xs.Add(savyx);
                    ys.Add(svaey);
                }
                else
                {
                    xs[i] = xs[i - 1];
                    ys[i] = ys[i - 1];
                }
            }
            xs[0] = x;
            ys[0] = y;

            for(int i = leng; i > 0; i--)
            {
                if (i > xs.Count - 1 || i > ys.Count - 1)
                {
                    drawexces(savyx, savyx, main);
                }
                else
                {
                    drawexces(xs[i], ys[i], main);
                }
            }
        }

        private void drawexces(int x, int y, Canvas c)
        {
            Rectangle body = new Rectangle 
            {
                Height = 100,
                Width = 100,
                Fill = new SolidColorBrush(Color.FromArgb(128, 16, 82, 14))
            };

            
            c.Children.Add(body);
            Canvas.SetLeft(body, x * 100);
            Canvas.SetTop(body, y * 100);
        }
    }
}

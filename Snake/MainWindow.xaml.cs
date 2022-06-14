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

        int xkostka = -2;
        int ykostka = -2;

        int xburg = -2;
        int yburg = -2;

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
            Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"hm jmgjkh.png", UriKind.Relative))
            }
        };

        Rectangle burgir = new Rectangle
        {
            Height = 100,
            Width = 100,
            Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"fdjgbsreghwiefnjkseangkowanmG.png", UriKind.Relative))
            }
        };

        public void scored(int nasob)
        {
            scores += 10 * nasob;
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
            ykostka = -2;
            xkostka = -2;

            yburg = -2;
            xburg = -2;

            Random random = new Random();

            switch(random.Next(4))
            {
                case 0:
                    bool doesd = true;
                    do
                    {
                        ykostka = random.Next(8);
                        xkostka = random.Next(8);
                        for (int i = xs.Count - 1; i > 0; i--)
                        {
                            if (xs[i] != xkostka && ys[i] != ykostka)
                            {
                                doesd = false;
                            }
                        }
                    }
                    while (doesd == true);

                    break;
                case 1:
                    bool doesx = true;
                    do
                    {
                        ykostka = random.Next(8);
                        xkostka = random.Next(8);
                        for (int i = xs.Count - 1; i > 0; i--)
                        {
                            if (xs[i] != xkostka && ys[i] != ykostka)
                            {
                                doesx = false;
                            }
                        }
                    }
                    while (doesx == true);

                    break;
                case 2:
                    bool doesy = true;
                    do
                    {
                        ykostka = random.Next(8);
                        xkostka = random.Next(8);
                        for (int i = xs.Count - 1; i > 0; i--)
                        {
                            if (xs[i] != xkostka && ys[i] != ykostka)
                            {
                                doesy = false;
                            }
                        }
                    }
                    while (doesy == true);

                    break;
                case 3:

                    bool doesS = true;
                    do
                    {
                        yburg = random.Next(8);
                        xburg = random.Next(8);
                        for (int i = xs.Count - 1; i > 0; i--)
                        {
                            if (xs[i] != xburg && ys[i] != yburg)
                            {
                                doesS = false;
                            }
                        }
                    }
                    while (doesS == true);
                    break;
            }
            
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
                    scored(1);
                    speed -= 25;
                    myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);
                    genratorjakdebil();
                    leng++;
                }
                else if(x == xburg && y == yburg)
                {
                    scored(2);
                    speed -= 15;
                    myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);
                    genratorjakdebil();
                    leng++;
                }
            }

            if (exercontrolníhovno == 0)
           {
                genratorjakdebil();
           }

            main.Children.Add(kostka);
            Canvas.SetLeft(kostka, xkostka * 100);
            Canvas.SetTop(kostka, ykostka * 100);

            main.Children.Add(burgir);
            Canvas.SetLeft(burgir, xburg * 100);
            Canvas.SetTop(burgir, yburg * 100);
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
                ImageSource = new BitmapImage(new Uri(@"hlavamore.png", UriKind.Relative))
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
            ys.Clear();
            xs.Clear();
            scores = 0;
            speed = 300;

            x = 8;
            y = 4;

            xkostka = 0;
            ykostka = 0;

            xburg = 0;
            yburg = 0;

            round = 0;
            way = 0;
            leng = 5;
            myTimer = new DispatcherTimer();
            exercontrolníhovno = leng;

            myTimer.Tick += new EventHandler(Snake);
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);

            xs.Add(0);
            ys.Add(0);

            for (int i = 0; i < leng; i++)
            {
                xs.Add(-2);
                ys.Add(-2);
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
            int savyx = -2;
            int svaey = -2;
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

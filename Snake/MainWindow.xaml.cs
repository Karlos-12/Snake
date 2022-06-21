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
using SharpDX.XInput;

namespace Snake
{

    public partial class MainWindow : Window
    {
        Controller cntr1 = new Controller(UserIndex.One);

        int highscor = 410;

        int bigup = 1;
        int hulx = -2;
        int huly = -2;

        int scale = 100;
        int sizefx = 16;
        int sizefy = 8;

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

        public void changesize(int mera)
        {
            scale = mera;

            sizefx = 1600/mera;
            sizefy = 800/mera;

            kostka = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"hm jmgjkh.png", UriKind.Relative))
                }
            };

            burgir = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"fdjgbsreghwiefnjkseangkowanmG.png", UriKind.Relative))
                }
            };

            head = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"hlavamore.png", UriKind.Relative))
                }
            };

            joint = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"jointec.png", UriKind.Relative))
                }
            };
        }

        public MainWindow()
        {
            InitializeComponent();

            kostka = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"hm jmgjkh.png", UriKind.Relative))
                }
            };

            burgir = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"fdjgbsreghwiefnjkseangkowanmG.png", UriKind.Relative))
                }
            };

            head = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"hlavamore.png", UriKind.Relative))
                }
            };

            joint = new Rectangle
            {
                Height = scale,
                Width = scale,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"jointec.png", UriKind.Relative))
                }
            };
        }

        Rectangle kostka = null;
        Rectangle burgir = null;
        Rectangle joint = null;

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

            hulx = -2;
            huly = -2;

            Random random = new Random();

            if (scores > bigup * 100)
            {
                bool doesdf = true;
                do
                {
                    int csd = 0;
                    huly = random.Next(sizefy);
                    hulx = random.Next(sizefx);
                    for (int i = xs.Count - 1; i > 0; i--)
                    {
                        if (xs[i] == hulx && ys[i] == huly)
                        {
                            csd++;
                        }
                    }
                    if (csd == 0)
                    {
                        doesdf = false;
                    }
                }
                while (doesdf == true);

                bigup++;
            }
            else
            {
                switch (random.Next(4))
                {
                    case 0:
                        bool doesd = true;
                        do
                        {
                            int cd = 0;
                            ykostka = random.Next(sizefy);
                            xkostka = random.Next(sizefx);
                            for (int i = xs.Count - 1; i > 0; i--)
                            {
                                if (xs[i] == xkostka && ys[i] == ykostka)
                                {
                                    cd++;
                                }
                            }
                            if (cd == 0)
                            {
                                doesd = false;
                            }
                        }
                        while (doesd == true);

                        break;
                    case 1:
                        bool doesx = true;
                        do
                        {
                            int cx = 0;
                            ykostka = random.Next(sizefy);
                            xkostka = random.Next(sizefx);
                            for (int i = xs.Count - 1; i > 0; i--)
                            {
                                if (xs[i] == xkostka && ys[i] == ykostka)
                                {
                                    cx++;
                                }
                            }
                            if (cx == 0)
                            {
                                doesx = false;
                            }

                        }
                        while (doesx == true);

                        break;
                    case 2:
                        bool doesy = true;
                        do
                        {
                            int c = 0;
                            ykostka = random.Next(sizefy);
                            xkostka = random.Next(sizefx);
                            for (int i = xs.Count - 1; i > 0; i--)
                            {
                                if (xs[i] == xkostka && ys[i] == ykostka)
                                {
                                    c++;
                                }
                            }
                            if (c == 0)
                            {
                                doesy = false;
                            }
                        }
                        while (doesy == true);

                        break;
                    case 3:

                        bool doesS = true;
                        do
                        {
                            int cs = 0;
                            yburg = random.Next(sizefy);
                            xburg = random.Next(sizefx);
                            for (int i = xs.Count - 1; i > 0; i--)
                            {
                                if (xs[i] == xkostka && ys[i] == ykostka)
                                {
                                    cs++;
                                }
                            }
                            if (cs == 0)
                            {
                                doesS = false;
                            }
                        }
                        while (doesS == true);
                        break;
                }
            }
            
        }
        int exercontrolníhovno = 0;
        State state;

        public void Snake(object source, EventArgs e)
        {
            
            
            exercontrolníhovno--;
            round++;
            main.Children.Clear();
            switch (way)
            {
                case 0:
                    if (y == sizefy)
                    {        
                        y = 0;
                    }
                    else
                    {
                        y++;
                    }
                    break;

                case 1:
                    if (x == sizefx)
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
                        y = sizefy;
                    }
                    else
                    {
                        y--;
                    }
                    break;

                case 3:
                    if (x == 0)
                    {
                        x = sizefx;
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
                    speed -= 10;
                    myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);
                    genratorjakdebil();
                    leng++;
                }
                else if(x == xburg && y == yburg)
                {
                    scored(2);
                    speed -= 5;
                    myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);
                    genratorjakdebil();
                    leng++;
                }
                else if(x == hulx && y == huly)
                {
                    changesize(scale - 20);
                    genratorjakdebil();
                }    
            }

            if (exercontrolníhovno == 0)
            {
                genratorjakdebil();
            }

            main.Children.Add(kostka);
            Canvas.SetLeft(kostka, xkostka * scale);
            Canvas.SetTop(kostka, ykostka * scale);

            main.Children.Add(burgir);
            Canvas.SetLeft(burgir, xburg * scale);
            Canvas.SetTop(burgir, yburg * scale);

            main.Children.Add(joint);
            Canvas.SetLeft(joint, hulx*scale);
            Canvas.SetTop(joint, huly*scale);
        }

        public void ende()
        {
            MessageBox.Show("najs more si debil fakt chudák žížala");
            myTimer.Stop();
            main.Children.Clear();
            fdgd.IsEnabled = true;
            Score scer = new Score(scores, highscor);
            scer.Show();
        }

        Rectangle head = null;

        public void Draw()
        {         
            main.Children.Add(head);
            Canvas.SetLeft(head, x * scale);
            Canvas.SetTop(head, y * scale);
        }
        DispatcherTimer myTimer = new DispatcherTimer();
        DispatcherTimer controler2 = new DispatcherTimer();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bigup = 0;
            fdgd.IsEnabled = false;
            ys.Clear();
            xs.Clear();
            scores = 0;
            speed = 300;

            x = 8;
            y = 4;

            xkostka = -2;
            ykostka = -2;

            xburg = -2;
            yburg = -2;

            round = 0;
            way = 0;
            leng = 5;
            
            exercontrolníhovno = leng;

            myTimer = new DispatcherTimer();
            myTimer.Tick += new EventHandler(Snake);
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, speed);

            controler2 = new DispatcherTimer();
            controler2.Tick += new EventHandler(contorler);
            controler2.Interval = new TimeSpan(0, 0, 0, 0, 1);

            xs.Add(-2);
            ys.Add(-2);

            for (int i = 0; i < leng; i++)
            {
                xs.Add(-2);
                ys.Add(-2);
            }

            myTimer.Start();
            controler2.Start();
        }
        bool contolremod = false;
        public void contorler(object source, EventArgs e)
        {
            //state = cntr1.GetState();
            if (contolremod == true)
            {
                switch (state.Gamepad.Buttons)
                {
                    case GamepadButtonFlags.DPadUp:
                        way = 2;
                        break;
                    case GamepadButtonFlags.DPadDown:
                        way = 0;
                        break;
                    case GamepadButtonFlags.DPadRight:
                        way = 1;
                        break;
                    case GamepadButtonFlags.DPadLeft:
                        way = 3;
                        break;
                }
            }
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
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
                Height = scale,
                Width = scale,
                Fill = new SolidColorBrush(Color.FromArgb(128, 16, 82, 14))
            };

            
            c.Children.Add(body);
            Canvas.SetLeft(body, x * scale);
            Canvas.SetTop(body, y * scale);
        }

        private void fg(object sender, RoutedEventArgs e)
        {

        }

        private void controler_Click(object sender, RoutedEventArgs e)
        {
            if(controler1.IsChecked == true)
            {
                contolremod = true;
            }
            else
            {
                contolremod = false;
            }
        }
    }
}

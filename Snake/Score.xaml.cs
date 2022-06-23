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
using System.Windows.Shapes;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using System.Printing;
using Microsoft.VisualBasic;

namespace Snake
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        int scoros;
        highscore NONI;

        public Score(int scor)
        {
            InitializeComponent();
            sc.Content = "Your score is:" + scor;
            prr.Value = scor;
            scoros = scor;
           
        }
      
        IFirebaseConfig ifc = new FirebaseConfig
        {
            AuthSecret= "kAOcEH61r9XMNiTfi3ZwvZE7PUzqoCmR0bXJanq4",
            BasePath = "https://hadik-390ee-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new FirebaseClient(ifc);
            var non = client.Get("winnerlist/best/");
            NONI = non.ResultAs<highscore>();
            prr.Maximum = NONI.score;

            if (NONI.score > scoros)
            {
                ggg.Visibility = Visibility.Hidden;
            }
            fight.Content = NONI.pps;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NONI.score < scoros)
            {
                string pp = Interaction.InputBox("Your name?", "Well done", "Name..");
                System.Threading.Thread.Sleep(1000);

                highscore hgh = new highscore()
                {
                    name = "best",
                    pps = pp,
                    score = scoros
                };

                var setter = client.Set("winnerlist/" + hgh.name, hgh);
            }
            else
            {
                ggg.Visibility = Visibility.Hidden;
            }
        }
    }
}

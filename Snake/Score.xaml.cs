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

namespace Snake
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        public Score(int scor, int high)
        {
            InitializeComponent();
            sc.Content = "Your score is:" + scor;
            prr.Value = scor;
            prr.Maximum = high;
        }

    }
}

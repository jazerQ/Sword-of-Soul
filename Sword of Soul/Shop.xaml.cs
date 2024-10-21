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
using System.Windows.Threading;
using System.Threading;

namespace Sword_of_Soul
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int Counter = 0;
        private string ForTextBlock = "О нет, куда я попал? Что со мной случилось?";
        private MediaPlayer media = new MediaPlayer();
        public Shop()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += Timer_Tick;
            timer.Start();
            media.Open(new Uri("C:\\Users\\user\\source\\repos\\Sword of Soul\\Sword of Soul\\music\\148968245-8-bit-game-text-typing-1.mp3", UriKind.Absolute));
            media.MediaEnded += Media_MediaEnded;
            media.Play();
        }

        private void Media_MediaEnded(object sender, EventArgs e)
        {
            media.Position = TimeSpan.Zero;
            media.Play();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(Counter == ForTextBlock.Length)
            {
                timer.Stop();
                media.Stop();
                Thread.Sleep(1500);
                UpGrage up = new UpGrage();
                up.Show();
                this.Close();
                return;
            }
            Text.Text += ForTextBlock[Counter];
            Counter++;
        }
    }
}

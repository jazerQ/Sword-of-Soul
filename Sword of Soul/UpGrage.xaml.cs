using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Threading;

namespace Sword_of_Soul
{
    /// <summary>
    /// Логика взаимодействия для UpGrage.xaml
    /// </summary>
    public partial class UpGrage : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int Counter = 0;
        
        private bool flagSpeech = false;
        private string ForTextBlock = "Здравия желаю, ты каким-то образом тут как-то оказался, телепортировался чтоль, я до конца не понял, сорян, но ес чо можешь покупать разных хлам у меня, в \"ТАВЕРНЕ Паули\"! и сорян что когда я говорю , кто-то говорит на фоне бесконечный \"I`m Fine\" это меня прокляла ведьма";
        private MediaPlayer media = new MediaPlayer();
        public UpGrage()
        {
            InitializeComponent();
            Trade.Click += Trade_Click;
            Talk.Click += Talk_Click;
            GoFight.IsEnabled = false;
            GoFight.Click += GoFight_Click;
            setTimer();
        }

        private void GoFight_Click(object sender, RoutedEventArgs e)
        {
            game Forest = new game();
            Forest.Show();
            this.Close();
        }

        private void Trade_Click(object sender, RoutedEventArgs e)
        {
            Catalog catalog = new Catalog();
            if (catalog.IsLoaded)
            {
                
                return;
            }
            
            catalog.Show();
            
        }

        private void Talk_Click(object sender, RoutedEventArgs e)
        {
            if (!flagSpeech)
            {
                timer.Start();
                StartMusic();
            }

                /*}
                else
                {
                    Catalog catalog = new Catalog();
                    catalog.Show();
                }*/
        }
            private void StartMusic()
        {
            media.Open(new Uri("C:\\Users\\user\\source\\repos\\Sword of Soul\\Sword of Soul\\music\\148968245-8-bit-game-text-typing-1.mp3", UriKind.Absolute));
            media.MediaEnded += Media_MediaEnded;
            media.Play();
        }
        private void setTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Tick += Timer_Tick;
            
            
        }

        private void Media_MediaEnded(object sender, EventArgs e)
        {
            media.Position = TimeSpan.Zero;
            media.Play();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Counter == ForTextBlock.Length)
            {
                timer.Stop();
                media.Stop();
                Trade.IsEnabled = true;
                GoFight.IsEnabled = true;
                flagSpeech = true;
                return;
            }
            Speech.Text += ForTextBlock[Counter];
            Counter++;
        }
    }
}


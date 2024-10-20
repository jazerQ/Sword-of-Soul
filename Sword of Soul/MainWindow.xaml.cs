﻿using System;
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
using System.Windows.Media.Animation;
using System.Threading;

namespace Sword_of_Soul
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        
        private bool _menuOpened = false;
        public WelcomeWindow()
        {
            InitializeComponent();
            /*WelcomeAnimation();
            Menu menu = new Menu();
            menu.Show();
            this.Close();*/
            this.Loaded += WelcomeWindow_Loaded;
        }

        private async void WelcomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            await WelcomeAnimation();
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Clos();
        }
        private void Clos()
        {
            if (!_menuOpened)
            {
                _menuOpened = true;
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
        }
    }
}

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

namespace Sword_of_Soul
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
            this.MouseDown += Catalog_MouseDown;
            CheckPower();
            CheckHealth();
            LoadCosts();
            UpgradeHealth.Click += UpgradeHealth_Click;
            UpgradePower.Click += UpgradePower_Click;
        }
        private void CheckPower()
        {
            if (Money.coins >= Costs.CostUpPower)
            {
                UpgradePower.IsEnabled = true;
                return;
            }
            UpgradePower.IsEnabled = false;
        }
        private void CheckHealth()
        {
            if (Money.coins >= Costs.CostUpHealth)
            {
                UpgradeHealth.IsEnabled = true;
                return;
            }
            UpgradeHealth.IsEnabled = false;
        }
        private void UpgradePower_Click(object sender, RoutedEventArgs e)
        {
            Money.coins -= Costs.CostUpPower;
            Costs.CurrentLevelPower++;
            Costs.CostUpPower =(int) (Costs.CostPower * Math.Pow((1 + 0.15), Costs.CurrentLevelPower));
            HealthPower.Power += 2;
            CheckPower();
            CheckHealth();
            LoadCosts();
        }

        private void UpgradeHealth_Click(object sender, RoutedEventArgs e)
        {
            Money.coins -= Costs.CostUpHealth;
            Costs.CurrentLevelHealth++;
            Costs.CostUpHealth = (int)(Costs.CostHealth * Math.Pow((1 + 0.15), Costs.CurrentLevelHealth));
            HealthPower.Health += 5;
            CheckHealth();
            CheckPower();
            LoadCosts();
        }
        private void LoadCosts()
        {
            CostOfHealth.Text = Costs.CostUpHealth.ToString();
            CostOfPower.Text = Costs.CostUpPower.ToString();
            MyMoney.Text = Money.coins.ToString();
            CurrentHealth.Text = $"Текущее здоровье - {HealthPower.Health}";
            CurrentPower.Text = $"Текущая сила - {HealthPower.Power}";
        }

        private void Catalog_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

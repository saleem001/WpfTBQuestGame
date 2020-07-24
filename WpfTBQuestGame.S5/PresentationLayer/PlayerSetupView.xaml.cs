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
using WpfTheAionProject.Models;

namespace WpfTheAionProject.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;
        //GameSessionViewModel _gam;
        public PlayerSetupView(Player player)
        {
            _player = player;
            InitializeComponent();
            SetupWindow();
        }
        private void SetupWindow()
        {
            List<string> house = Enum.GetNames(typeof(Player.HouseName)).ToList();
            List<string> armyName = Enum.GetNames(typeof(Player.ArmyName)).ToList();

            ArmyNameCombobx.ItemsSource = armyName;
            HouseCombobx.ItemsSource = house;

            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if (NameTextBox.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            return errorMessage == "" ? true : false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;
            if (IsValidInput(out errorMessage))
            {
                Player.ArmyName armyName;
                Player.HouseName house;
                Enum.TryParse(ArmyNameCombobx.SelectionBoxItem.ToString(), out armyName);
                Enum.TryParse(HouseCombobx.SelectionBoxItem.ToString(), out house);
                _player.Army = armyName;
                _player.House = house;
               

           
                Visibility = Visibility.Hidden;
            }
            else
            {
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }
    }
}

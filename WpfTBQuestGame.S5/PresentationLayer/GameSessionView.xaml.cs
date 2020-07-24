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

namespace WpfTheAionProject.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;
        int count = 0;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
            
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if(LocationItemsDataGrid.SelectedItem!=null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                 _gameSessionViewModel.OnUseGameItem();
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MoveEastButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(EastLocation.Text== "Location Not Accessible")
            {
                MessageBox.Text = "Selected Location is Not Accessible";
            }
            else
            {
                _gameSessionViewModel.MoveEast();
                CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
                MessageBox.Text = _gameSessionViewModel.CurrentLocation.Message;
            }
        }

        private void MoveNorthButton_Click(object sender, RoutedEventArgs e)
        {
            if (_gameSessionViewModel.CurrentLocation.XCORD == 1)
            {  
                if(_gameSessionViewModel.CurretLocation.XP>10)
                {
                    _gameSessionViewModel.MoveNorth();
                    CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
                    MessageBox.Text = _gameSessionViewModel.CurrentLocation.Message;
                    EastLocation.Visibility = Visibility.Hidden;
                    WestLocation.Visibility = Visibility.Hidden;
                    MoveEastButton.IsEnabled = false;
                    MoveWestButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Text = "Allas! \n\nYour XPs are less than 10 and you do not have enough allies";
                }
            }
            else
            {
                if (NorthLocation.Text == "Location Not Accessible")
                {
                    MessageBox.Text = "Selected Location is Not Accessible";
                }
                else
                {
                    _gameSessionViewModel.MoveNorth();
                    CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
                    MessageBox.Text = _gameSessionViewModel.CurrentLocation.Message;
                }
               

            }
        }

        private void MoveWestButton_Click(object sender, RoutedEventArgs e)
        {
            if (WestLocation.Text == "Location Not Accessible")
            {
                MessageBox.Text = "Selected Location is Not Accessible";
            }
            else
            {
                _gameSessionViewModel.MoveWest();
                CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
                MessageBox.Text = _gameSessionViewModel.CurrentLocation.Message;
            }
           
        }

        private void MoveSouthButton_Click(object sender, RoutedEventArgs e)
        {
            EastLocation.Visibility = Visibility.Visible;
            WestLocation.Visibility = Visibility.Visible;
            MoveEastButton.IsEnabled = true;
            MoveWestButton.IsEnabled = true;
            if (SouthLocation.Text == "Location Not Accessible")
            {
                MessageBox.Text = "Selected Location is Not Accessible";
            }
            else
            {
                _gameSessionViewModel.MoveSouth();
                CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
                MessageBox.Text = _gameSessionViewModel.CurrentLocation.Message;
            }
        }

        private void SpeakToButton_Click(object sender, RoutedEventArgs e)
        {
            if (count == 2)
            {
                count--;
                _gameSessionViewModel.AddNPCs();
            }
            else
            {
                if (LocationNpcsDataGrid.SelectedItem != null)
                {
                    _gameSessionViewModel.OnPlayerTalkTo();
                    count++;
                }
            }

        }

        private void RetreatButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnPlayerRetreat();
            }
        }

        private void DefendButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnPlayerDefend();
            }
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                if(_gameSessionViewModel.CurrentLocationName== "Empty Space")
                {
                    _gameSessionViewModel.AddNPCs();
                }
                else
                {
                    _gameSessionViewModel.OnPlayerAttack();
                }
            }
        }

        private void OpenMissionStatus_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OpenMissionStatusView();
        }
    }
}

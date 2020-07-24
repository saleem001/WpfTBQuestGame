using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.PresentationLayer;
using WpfTheAionProject.Models;
using WpfTheAionProject.DataLayer;

namespace WpfTheAionProject.BusinessLayer
{
    public class GameBusiness
    {
        public GameSessionViewModel _gameSessionViewModel;
        Player _player=new Player();
        string _messages;
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;
        Map _gameMap;
        GameMapCoordinates _initialLocationCoordinates;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
            _gameMap = GameData.GameMap();
            _initialLocationCoordinates = GameData.InitialGameMapLocation();
        }
        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _messages,
                _gameMap,
                _initialLocationCoordinates
                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            //_playerSetupView.Close();
        }

        private void SetupPlayer()
        {
            if(_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                _player.ExperiencePoints = 0;
                _player.Health = 100;
                _player.Lives = 3;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

    }
}

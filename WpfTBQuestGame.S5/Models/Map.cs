using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.Models
{
    public class Map
    {

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _mapLocation = new Location[rows, columns];
        }
        private int _maxRows, _maxColumns;
        private ObservableCollection<Location> _locations=new ObservableCollection<Location>();
        int _currentLocationCoordinate;
        private List<GameItem> _standardGameItems;


        Location[,] _mapLocation;
        private GameMapCoordinates _currentLocationCoordinates;


        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }
        public GameItem GameItemById(int gameItemId)
        {
            return StandardGameItems.FirstOrDefault(i => i.id == gameItemId);
        }
        //public string OpenLocationByRelic(int relicid)
        //{
        //    string message = "The relic did nothing";
        //    Location mapLocation = new Location();
        //    for (int row = 0; row < _maxRows;row++)
        //    {
        //        for(int col=0;col<_maxColumns;col++)
        //        {
        //            mapLocation = _mapLocation[row, col];

        //            if(mapLocation!=null && mapLocation.RequiredRelicid==relicid)
        //            {
        //                mapLocation.accessible = true;
        //                message = $"{mapLocation.name} is now accessible";
        //            }
        //        }
        //    }
        //    return message;
        //}
       

        public Location[,] MapLocation
        {
            get { return _mapLocation; }
            set { _mapLocation = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }
      
        public int CurrentLocationCoordinate
        {
            get { return _currentLocationCoordinate; }
            set { _currentLocationCoordinate = value; }
        }

        public ObservableCollection<Location> Locations
        {
            get  { return _locations; }
            set { _locations = value; }
        }


        public Location CurrentLocation
        {
            get { return _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        }

        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                ObservableCollection<Location> accessibleLocations = new ObservableCollection<Location>();
                foreach (var location in _locations)
                {
                    if (location.accessible == true)
                    {
                        accessibleLocations.Add(location);
                    }
                }
                return accessibleLocations;
            }
        }

        public List<string> AccessibleLocationsNames
        {
            get
            {
                List<string> accessibleLocationsnames = new List<string>();
                foreach (var location in _locations)
                {
                    if (location.accessible == true)
                    {
                        accessibleLocationsnames.Add(location.name);
                    }
                }
                return accessibleLocationsnames;
            }
        }
        public void MoveNorth()
        {
            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                _currentLocationCoordinates.Row -= 1;
            }
        }

        public void MoveEast()
        {
            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                _currentLocationCoordinates.Column += 1;
            }
        }

        public void MoveSouth()
        {
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                _currentLocationCoordinates.Row += 1;
            }
        }

        public void MoveWest()
        {
            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                _currentLocationCoordinates.Column -= 1;
            }
        }

        //
        // get the north location if it exists
        //
        public Location NorthLocation()
        {
            Location northLocation = null;

            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextNorthLocation = _mapLocation[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column];

                //
                // location exists
                //
                if (nextNorthLocation != null)
                {
                    northLocation = nextNorthLocation;
                }
            }

            return northLocation;
        }

        //
        // get the east location if it exists
        //
        public Location EastLocation()
        {
            Location eastLocation = null;

            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextEastLocation = _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                //
                // location exists 
                //
                if (nextEastLocation != null)
                {
                    eastLocation = nextEastLocation;
                }
            }

            return eastLocation;
        }

        //
        // get the south location if it exists
        //
        public Location SouthLocation()
        {
            Location southLocation = null;

            //
            // not on south border
            //
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextSouthLocation = _mapLocation[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                //
                // location exists and player can access location
                //
                if (nextSouthLocation != null)
                {
                    southLocation = nextSouthLocation;
                }
            }

            return southLocation;
        }

        //
        // get the west location if it exists
        //
        public Location WestLocation()
        {
            Location westLocation = null;

            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextWestLocation = _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                //
                // location exists and player can access location
                //
                if (nextWestLocation != null)
                {
                    westLocation = nextWestLocation;
                }
            }

            return westLocation;
        }
    }
}

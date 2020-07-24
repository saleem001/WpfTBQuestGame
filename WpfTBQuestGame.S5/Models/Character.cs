using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public abstract class Character :ObservableObject
    {

        private string _name;
        private int _id,_locationid;
        private HouseName _house;

        protected Random random = new Random();

        public enum HouseName
        {
            Stark,
            Targaryan,
            Lannister,
            Tyrell,
            Thorne,
            Bolton,
            Baratheon,
            None
        }
        public Character()
        {

        }
        public Character(int id, string name,HouseName house)
        {
            _id = id;
            _name = name;
            _house = house;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(_id)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(_name)); }
        }
        public int Locationid
        {
            get { return _locationid; }
            set { _locationid = value;
                OnPropertyChanged(nameof(Locationid));
                OnPropertyChanged(nameof(_locationid)); }
        }
        public HouseName House
        {
            get { return _house; }
            set { _house = value;
                OnPropertyChanged(nameof(House));
                OnPropertyChanged(nameof(_house)); }
        }
        //public abstract void functionAbstract();
        //public virtual void functionVirtual()
        //{

        //}

        
    }
}

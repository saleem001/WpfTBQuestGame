namespace WpfTheAionProject.Models
{
    public abstract class GameItem
    { 

        public int id  { get; set; }
        public int Value { get; set; }
        public int ExperiencePoints { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UseMessage { get; set; }

        public abstract string InformationString();

        public string Information
        {
            get { return InformationString(); }
        }


        public GameItem(int _id,string name,int value,string description,int exriencePoints,string useMessage="")
        {
            id = _id;
            Name = name;
            Value = value;
            Description = description;
            ExperiencePoints = exriencePoints;
            UseMessage = useMessage;
        }
    }
}

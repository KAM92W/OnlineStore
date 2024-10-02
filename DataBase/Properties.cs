using System.ComponentModel;

namespace DataBase
{
    public class Properties
    {
        private int id;
        private string name;
        private string description;
        public Products Product { get; set; }
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public Properties(int PropertyId, string PropertyName, string PropertyDescription) 
        {
            this.PropertyId = PropertyId;
            this.PropertyName = PropertyName;
            this.PropertyDescription = PropertyDescription;
        }
    }
}

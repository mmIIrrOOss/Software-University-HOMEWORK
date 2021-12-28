using _07.Military_Elite.Contracts;

namespace _07.Military_Elite.Models
{
    public class Repear : IRepeair
    {
        public Repear(string partName,int hourseWorked)
        {
            this.PartName = partName;
            this.HourseWorked = hourseWorked;
        }

        public string PartName { get; private set; }

        public int HourseWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HourseWorked}";
        }
    }
}

using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;

        private int numberofLaps;
        private bool tookplace;
        private List<IPilot> pilots;
        public Race(string raceName, int numberofLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberofLaps;
            TookPlace = false;
            pilots= new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberofLaps; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberofLaps = value;
            }
        }


        public bool TookPlace { get { return tookplace; } set => tookplace = value; }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string yesorNo = "";
            if (tookplace==true)
            {
                yesorNo = "Yes";
            }
            else
            {
                yesorNo = "No";
            }
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"The {raceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {numberofLaps}");
            sb.AppendLine($"Took place: {yesorNo}");
            return sb.ToString().TrimEnd();
        }
    }
}

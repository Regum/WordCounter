using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OxyPlot;

namespace WordCounter
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.Title = "Text 1";
            this.TabTitle = "Text 1";

            //this.Drews = new List<Drew> { new Drew("Fulsom", "Drew"), new Drew("Rubio", "Andrubio"), new Drew("Ksendzoff", "Boris") };

            this.Drews = new ObservableCollection<Drew>() { new Drew("Fulsom", "Drew"), new Drew("Rubio", "Andrubio"), new Drew("Ksendzoff", "Boris") };


            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                
            };

            //Text t = Junction.Texts[0];

        }

        public string Title { get; private set; }
        public string TabTitle { get; private set; }

        public IList<DataPoint> Points { get; private set; }
        //public List<Drew> Drews { get; private set; }
        public ObservableCollection<Drew> Drews { get; set; }
    }

    public class Drew
    {

        public Drew()
        {

        }

        public Drew(string lastName, string prefName)
        {

        }

        public string LastName { get; set; }
        public string PreferredName { get; set; }

    }
}

using System;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using OxyPlot;
using OxyPlot.Series;
using PipesAndFilters4DotNet;

namespace WordCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WordPipeline wp = new WordPipeline();
            wp.Execute();
            
            InitializeComponent();
            this.Models = CreatePlotModels();
            this.DataContext = this;

            Junction.WriteToFile();
        }

        public IList<PlotModel> Models { get; private set; }

        private static Random r = new Random(13);

        private static IList<PlotModel> CreatePlotModels()
        {
            List<PlotModel> models = new List<PlotModel>();
            List<int> data = new List<int>();

            int topCount, dataCount;
            LineSeries series;
            PlotModel model;

            foreach(Text t in Junction.Texts)
            {
                model = new PlotModel();
                model.Title = t.FileName;

                topCount = t.Top50.Count;              
                for(int i = 0; i < topCount; ++i)
                {
                    data.Clear();
                    data = t.GetFrequencies(t.Top50[i]);
                    series = new LineSeries();

                    dataCount = data.Count;

                    //Add points to series.
                    for(int j = 0; j < dataCount; ++j)
                    {
                        series.Points.Add(new DataPoint(j, data[j]));
                    }

                    //Add series to plot.
                    model.Series.Add(series);
                }

                //Add plot to window.
                models.Add(model);
                
            }

            return models;
        }

        public PlotModel MyModel { get; private set; }
        public string TestText { get; private set; }
        
    }

    
}

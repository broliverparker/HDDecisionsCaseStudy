using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace HDDecisionsCaseStudy
{
    /// <summary>
    /// Interaction logic for PreviousResults.xaml
    /// </summary>
    public partial class PreviousResults : Window
    {
        public ObservableCollection<ApplicationResult> ResultsGrid { get; set; }

        public PreviousResults()
        {
            LoadData();
            InitializeComponent();
        }

        public async void LoadData()
        {
            var jsonString = await GetApplicants("http://oliverparkerfyp.website/api/getapplicants.php");
            List<ApplicationResult> resultsList = JsonConvert.DeserializeObject<List<ApplicationResult>>(jsonString);

            grid_results.ItemsSource = resultsList;
        }

        private async Task<string> GetApplicants(string url)
        {

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "json";
            request.Method = "GET";
            // This sets up a http web request which is type GET, this means we are retrieving data from the database

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            // Whilst there is a response it takes the stream from the database and stores it into the Json doc
        }
    }

    public class ApplicationResult
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string Outcome { get; set; }
    }

}

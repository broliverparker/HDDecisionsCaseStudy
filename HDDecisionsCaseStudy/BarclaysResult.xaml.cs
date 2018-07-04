using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for BarclaysResult.xaml
    /// </summary>
    public partial class BarclaysResult : Window
    {
        Applicant currentApplicant;
        public BarclaysResult(Applicant applicant)
        {
            currentApplicant = applicant;
            InitializeComponent();
        }

        private void btn_Accept_Click(object sender, RoutedEventArgs e)
        {
            SubmitApplicationBarclays("http://oliverparkerfyp.website/api/applyuser.php", (currentApplicant.FirstName + 
                " " + currentApplicant.LastName), "Accepted");
            this.Close();
        }

        private void btn_decline_Click(object sender, RoutedEventArgs e)
        {
            SubmitApplicationBarclays("http://oliverparkerfyp.website/api/applyuser.php", (currentApplicant.FirstName +
                " " + currentApplicant.LastName), "Declined");
            this.Close();
        }

        private async Task<string> SubmitApplicationBarclays(string url, string name, string outcome)
        {
            string success = "";

            using (var webClient = new WebClient())
            {
                var data = new NameValueCollection();
                data["name"] = name;
                data["result"] = "Barclays";
                data["outcome"] = outcome;
                var response = webClient.UploadValues(url, "POST", data);

            }
            return success;
        }

       
    }
}

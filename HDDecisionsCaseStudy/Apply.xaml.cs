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
    /// Interaction logic for Apply.xaml
    /// </summary>
    public partial class Apply : Window
    {
        public Apply()
        {
            InitializeComponent();
        }

        private void btn_submitApplication_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dob = calendar_DOB.SelectedDate;
            
            Applicant applicant = new Applicant(txt_FirstName.Text, txt_LastName.Text, dob != null ? dob.Value.ToString("yyyyMMdd") : "n/a", int.Parse(txt_Income.Text));

            int result = applicant.ValidateApplication();

            switch(result)
            {
                case 0:
                    MessageBoxResult msgresult = MessageBox.Show("Credit Cards are not available for under 18s, please make sure " +
                        "your date of birth is correct.", "Unsuccessful.");
                    SubmitApplicationRejected("http://oliverparkerfyp.website/api/applyuser.php", (applicant.FirstName +
               " " + applicant.LastName));
                    break;
                case 1:
                    BarclaysResult bresult = new BarclaysResult(applicant);
                    bresult.Show();
                    this.Close();
                    break;
                case 2:
                    VanquisResult rresult = new VanquisResult(applicant);
                    rresult.Show();
                    this.Close();
                    break;
            }
           
        }

        private async Task<string> SubmitApplicationRejected(string url, string name)
        {
            string success = "";

            using (var webClient = new WebClient())
            {
                var data = new NameValueCollection();
                data["name"] = name;
                data["result"] = "Rejected";
                data["outcome"] = "";
                var response = webClient.UploadValues(url, "POST", data);

            }
            return success;
        }
    }
}

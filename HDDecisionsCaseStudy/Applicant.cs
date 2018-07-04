using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDDecisionsCaseStudy
{
    public class Applicant
    {

        public Applicant(string fname, string lname, string dob, int income)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.DateOfBirth = dob;
            this.Income = income; 
        }

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public string DateOfBirth
        { get; set; }

        public int Income
        { get; set; }

        public int CalculateAge()
        {

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(DateOfBirth);

            string age = (((now - dob) / 10000).ToString());

            if (age.ToString().Length == 1)
                return int.Parse(age.Substring(0, 1));
            else
                return int.Parse(age.Substring(0, 2));
        }

        public int ValidateApplication()
        {
            if (CalculateAge() > 18)
            {
                if (Income > 30000)
                    return 1;
                else
                    return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

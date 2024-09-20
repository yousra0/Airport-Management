using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime Birthdate { get; set; }
        public string PassportNumber { get; set; } 
        public DateTime FlightDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public string EmailAdress { get; set; }

        public ICollection<Flight> Flights { get; set; }


        public override string ToString()
        {
            return "FirstName" + FirstName
                + "" + "BirthDate" + Birthdate;
        }

        /*public Boolean checkProfile (string firstName, string lastName)
        {
            return (FirstName == firstName && LastName == lastName);
        }
        public Boolean checkProfile(string firstName, string lastName, string email)
        {
            return (FirstName == firstName && LastName == lastName && EmailAdress == email);
        }*/

        public Boolean checkProfile(string firstName, string lastName, string email=null)
        {
            if (email == null)
                return FirstName == firstName && LastName == lastName;
            else
                return FirstName == firstName && LastName == lastName && EmailAdress == email;
        }

    }
}

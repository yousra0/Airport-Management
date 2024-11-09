using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassportNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public List<Flight> Flights { get; set; }

        //vérification du profile avec nom et prénom
        /*public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }*/

        //vérification du profile avec nom , prénom et email
       /* public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }*/

        //remplacer à la fois les 2 méthodes précédentes
        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FirstName == firstName && LastName == lastName &&
               EmailAddress == email;
            else
                return FirstName == firstName && LastName == lastName;
        }

        //afficher un message avec la methode PassengerType
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger:" + FirstName);
        }
    }
}

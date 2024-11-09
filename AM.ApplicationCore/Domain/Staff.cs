using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime Employementdate { get; set; }
        public string Function { get; set; }
        public double Salary { get; set; }

        //afficher un message avec la methode PassengerType
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a staff member");
        }
    }
}

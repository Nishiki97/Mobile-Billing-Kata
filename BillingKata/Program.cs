using System;
using System.Globalization;

namespace BillingKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //add new customer
            CultureInfo cultureCus = new CultureInfo("en-US");

            Customer cus = new Customer("Nishiki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "077-5649621", 'A', Convert.ToDateTime("1/1/2010 12:10:15 PM", cultureCus));
            cus.addNewCustomer();

            //add new cdr to the customer 077-5649621
            CultureInfo cultureCDR = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "077-4565324", Convert.ToDateTime("1/1/2010 12:10:15 PM", cultureCDR), 5.30);
            cdr.addNewCDR();
            cdr.CheckExtention();
        }
    }
}

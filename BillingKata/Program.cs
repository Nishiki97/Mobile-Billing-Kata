using System;
using System.Globalization;

namespace BillingKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer
            CultureInfo cultureCus = new CultureInfo("en-US");

            Customer cus = new Customer("Nishiki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "077-5649621", 'A', Convert.ToDateTime(DateTime.Now, cultureCus));
            cus.addNewCustomer();

            //CDR
            CultureInfo cultureCDR = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "077-4565324", Convert.ToDateTime(DateTime.Now, cultureCDR), 5.30);
            cdr.addNewCDR();
            cdr.CheckExtention();

            //Bill
            Bill bill = new Bill();
            bill.GenerateBill(cus, cdr);
        }
    }
}

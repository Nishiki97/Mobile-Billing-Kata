using System;
using System.Collections.Generic;
using System.Globalization;

namespace BillingKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Customer's full name: ");
            string userName = Console.ReadLine();

            //Customer
            CultureInfo cultureCus = new CultureInfo("en-US");

            Customer customer = new Customer();

            Customer cus1 = new Customer("Nishiki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "077-5649621", 'A', Convert.ToDateTime(DateTime.Now, cultureCus));
            customer.customerList.Add(cus1);
            Customer cus2 = new Customer("Chiyaki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "071-5645674", 'B', Convert.ToDateTime(DateTime.Now, cultureCus));
            customer.customerList.Add(cus2);

            //CDR
            CultureInfo cultureCDR = new CultureInfo("en-US");

            CDR callDetailRecords = new CDR();

            CDR cdr1 = new CDR("077-5649621", "077-4565324", Convert.ToDateTime(DateTime.Now, cultureCDR), 5.30);
            callDetailRecords.cdrDictionary.Add(cdr1);
            CDR cdr2 = new CDR("077-5649621", "077-1123532", Convert.ToDateTime(DateTime.Now, cultureCDR), 340);
            callDetailRecords.cdrDictionary.Add(cdr2);
            callDetailRecords.GetCDRList(customer.GetCustomerDetails(userName));
            callDetailRecords.CheckExtention();

            //Bill
            Bill bill = new Bill();
            bill.GenerateBill(customer.GetCustomerDetails(userName), callDetailRecords.GetCDRList(customer.GetCustomerDetails(userName)));


        }
    }
}

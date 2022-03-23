using System;
using System.Collections.Generic;
using System.Globalization;

namespace BillingKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer
            CultureInfo cultureCus = new CultureInfo("en-US");

            Customer customer = new Customer();

            Customer cus1 = new Customer("Nishiki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "077-5649621", 'A', Convert.ToDateTime(DateTime.Now, cultureCus));
            customer.customerList.Add(cus1);
            Customer cus2 = new Customer("Chiyaki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "071-5645674", 'B', Convert.ToDateTime(DateTime.Now, cultureCus));
            customer.customerList.Add(cus2);
            Customer cus3 = new Customer("Akiyoshi Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "071-5645671", 'C', Convert.ToDateTime(DateTime.Now, cultureCus));
            customer.customerList.Add(cus3);


            //user inputs ---------------------------------------
            UserInputHandler userInputs = new UserInputHandler();

            Console.WriteLine("Enter Customer's full name: ");
            userInputs.userName = Console.ReadLine();

            userInputs.CheckUserNameInput();

            Console.WriteLine("Enter the month which you want to generate the bill for {0}: ", userInputs.userName);
            userInputs.userMonth = Console.ReadLine();

            userInputs.CheckMonthUserInput();

            //CDR
            CultureInfo cultureCDR = new CultureInfo("en-US");

            CDR callDetailRecords = new CDR();
            
            CDR cdr1 = new CDR("077-5649621", "077-4565324", Convert.ToDateTime(DateTime.Now, cultureCDR), 3600);
            callDetailRecords.cdrList.Add(cdr1);
            CDR cdr2 = new CDR("077-5649621", "077-1123532", Convert.ToDateTime(DateTime.Now, cultureCDR), 340);
            callDetailRecords.cdrList.Add(cdr2);
            CDR cdr3 = new CDR("071-5645674", "077-1123111", Convert.ToDateTime(DateTime.Now, cultureCDR), 340);
            callDetailRecords.cdrList.Add(cdr3);
            CDR cdr4 = new CDR("077-5649621", "077-1123000", Convert.ToDateTime(new DateTime(2021, 6, 10, 5, 10, 20)), 3600);
            callDetailRecords.cdrList.Add(cdr4);
            CDR cdr5 = new CDR("077-5649621", "071-6753465", Convert.ToDateTime(new DateTime(2021, 5, 10, 5, 10, 20)), 3600);
            callDetailRecords.cdrList.Add(cdr5);
            CDR cdr6 = new CDR("071-5645671", "077-6753465", Convert.ToDateTime(DateTime.Now, cultureCDR), 300);
            callDetailRecords.cdrList.Add(cdr6);
            callDetailRecords.GetCDRList(customer.GetCustomerDetails(userInputs.userName), userInputs.userMonth);
            callDetailRecords.CheckExtention();

            //Bill
            Bill bill = new Bill();
            bill.GenerateBill(customer.GetCustomerDetails(userInputs.userName), callDetailRecords.GetCDRList(customer.GetCustomerDetails(userInputs.userName), userInputs.userMonth));


        }
    }
}

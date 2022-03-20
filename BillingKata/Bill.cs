using System;
using System.Collections.Generic;

namespace BillingKata
{
    public class Bill
    {
        #region variable declaration
        private double totalCallCharge;
        public double TotalCallCharge
        {
            get { return totalCallCharge; }
            set { totalCallCharge = value; }
        }

        private double discount;
        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private double tax;
        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private double rental;
        public double Rental
        {
            get { return rental; }
            set { rental = value; }
        }

        private double totalBillAmount;
        public double TotalBillAmount
        {
            get { return totalBillAmount; }
            set { totalBillAmount = value; }
        }
        #endregion

        #region methods
        private void CalculatePackagecost(Customer customer, List<CDR> cdrList)
        {
            foreach(CDR cdr in cdrList)
            {
                cdr.CheckExtention();

                Package packageA = new Package('A', 100.00, "Per minute", cdr.CallType, 3, 2, 5, 4, 18.00, 10.00, 10.00, 18.00);
                Package packageB = new Package('B', 100.00, "Per seconds", cdr.CallType, 4, 3, 6, 5, 20.00, 8.00, 8.00, 20.00);
                Package packageC = new Package('C', 300.00, "Per minute", cdr.CallType, 2, 1, 3, 2, 18.00, 9.00, 9.00, 18.00);
                Package packageD = new Package('D', 300.00, "Per seconds", cdr.CallType, 3, 2, 5, 4, 20.00, 8.00, 8.00, 20.00);

                switch (customer.PackageCode)
                {
                    case 'A':
                        totalCallCharge = packageA.CalculateHourCharge(cdrList);
                        rental = packageA.Rental;
                        break;
                    case 'B':
                        totalCallCharge = packageB.CalculateHourCharge(cdrList);
                        rental = packageB.Rental;
                        break;
                    case 'C':
                        totalCallCharge = packageC.CalculateHourCharge(cdrList);
                        rental = packageC.Rental;
                        break;
                    case 'D':
                        totalCallCharge = packageD.CalculateHourCharge(cdrList);
                        rental = packageD.Rental;
                        break;
                    default:
                        totalCallCharge = 0.00;
                        break;
                }
            }
            
        }

        public void CalculateDiscount(Customer customer)
        {
            if (totalCallCharge > 1000.00 && customer.PackageCode == 'A' || totalCallCharge > 1000.00 && customer.PackageCode == 'B')
            {
                discount = totalCallCharge * 40 / 100;
            }
            else
            {
                discount = 0.00;
            }
        }

        public void CalculateGovermentTax(Customer customer)
        {
            switch (customer.PackageCode)
            {
                case 'A':
                    tax = (totalCallCharge + 100) * 20 / 100;
                    break;
                case 'B':
                    tax = (totalCallCharge + 100) * 20 / 100;
                    break;
                case 'C':
                    tax = (totalCallCharge + 300) * 20 / 100;
                    break;
                case 'D':
                    tax = (totalCallCharge + 300) * 20 / 100;
                    break;
                default:
                    tax = 0.00;
                    break;
            }
        }

        public void CalculateTotalBillAmount()
        {
            totalBillAmount = (totalCallCharge + rental + tax) - discount;
        }

        public void GenerateBill(Customer customer, List<CDR> cdrList)
        {
            CalculatePackagecost(customer, cdrList);
            CalculateDiscount(customer);
            CalculateGovermentTax(customer);
            CalculateTotalBillAmount();

            Console.WriteLine("\r");
            Console.WriteLine("Customer full Name : {0}", customer.FullName);
            Console.WriteLine("Phone Number       : {0}", customer.PhoneNumber);
            Console.WriteLine("Billing Address    : {0}", customer.BillingAddress);
            Console.WriteLine("Total Call Charges : {0} LKR", totalCallCharge);
            Console.WriteLine("Total Discount     : {0} LKR", discount);
            Console.WriteLine("Tax                : {0} LKR", tax);
            Console.WriteLine("Rental             : {0} LKR", rental);
            Console.WriteLine("Bill Amount        : {0} LKR", totalBillAmount);
            Console.WriteLine("\r\n");
            Console.WriteLine("==================List of Call Details for {0}==================", customer.FullName);

            foreach(var cdr in cdrList)
            {
                Console.WriteLine("\r");
                Console.WriteLine("Start Time         : {0}", cdr.StartingTime);
                Console.WriteLine("Duration in seconds: {0}", cdr.Duration);
                Console.WriteLine("Destination Number : {0}", cdr.ReceiverPhoneNo);
            }
        }
        #endregion
    }
}
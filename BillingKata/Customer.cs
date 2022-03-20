using System;
using System.Collections;
using System.Collections.Generic;

namespace BillingKata
{
    public class Customer
    {
        #region variable declaration
        //fullName
        private string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
            }
        }
        //billingAddress
        private string billingAddress;
        public string BillingAddress { 
            get
            {
                return billingAddress;
            }
            set 
            { 
                billingAddress = value;
            } 
        }
        //phoneNumber
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        //packagecode
        private char packageCode;
        public char PackageCode
        {
            get
            {
                return packageCode;
            }
            set
            {
                packageCode = value;
            }
        }
        //RegisteredDate
        private DateTime registeredDate;
        public DateTime RegisteredDate
        {
            get
            {
                return registeredDate;
            }
            set
            {
                registeredDate = value;
            }
        }
        public List<Customer> customerList = new List<Customer>();
        #endregion

        #region default and overload constructors
        public Customer()
        {
            fullName = "";
            billingAddress = "";
            phoneNumber = "";
            packageCode = 'A';
            registeredDate = new DateTime();
        }

        public Customer(string fullName, string billingAddress, string phoneNumber, char packageCode, DateTime registeredDate)
        {
            this.fullName=fullName;
            this.billingAddress=billingAddress;
            this.phoneNumber=phoneNumber;
            this.packageCode=packageCode;
            this.registeredDate=registeredDate;
        }
        #endregion

        #region methods
        public Customer GetCustomerDetails(string username)
        {
            fullName = username;
            Customer newSelectedCustomer = new Customer();

            foreach (Customer cutsomer in customerList)
            {
                if(cutsomer.fullName == fullName)
                {
                    fullName=cutsomer.fullName;
                    billingAddress=cutsomer.billingAddress;
                    phoneNumber=cutsomer.phoneNumber;
                    packageCode=cutsomer.packageCode;
                    registeredDate=cutsomer.registeredDate;

                    newSelectedCustomer = cutsomer;
                }
            }

            return newSelectedCustomer;
        }
        #endregion
    }
}
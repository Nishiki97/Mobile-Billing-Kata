using BillingKata;
using NUnit.Framework;
using System;
using System.Globalization;

namespace BillingKataTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region test cases for customer
        [Test]
        public void AddNewCustomer_withAllAttributes_shouldReturnSuccess()
        {
            CultureInfo culture = new CultureInfo("en-US");

            Customer cus = new Customer("Nishiki Yapa", "07, Gunasekara Mawatha, Mattumagala, Ragama", "077-5649621", 'A', Convert.ToDateTime("1/1/2010 12:10:15 PM", culture));
            cus.addNewCustomer();

        }
        #endregion

        #region test cases for CDR
        [Test]
        public void AddNewCDR_withAllAttributes_shouldReturnSuccess()
        {
            CultureInfo culture = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "077-4565324", Convert.ToDateTime("1/1/2010 12:10:15 PM", culture), 5.30);
            cdr.addNewCDR();
        }

        [Test]
        public void CheckExtention_withSameExtention_shouldReturnTypeLocal()
        {
            CultureInfo culture = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "077-4565324", Convert.ToDateTime("1/1/2010 12:10:15 PM", culture), 5.30);
            cdr.CheckExtention();
        }

        [Test]
        public void CheckExtention_withDifferentExtention_shouldReturnTypeLongDistance()
        {
            CultureInfo culture = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "071-4565324", Convert.ToDateTime("1/1/2010 12:10:15 PM", culture), 5.30);
            cdr.CheckExtention();
        }

        [Test]
        public void CheckExtention_withNullExtention_shouldReturnError()
        {
            CultureInfo culture = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "", Convert.ToDateTime("1/1/2010 12:10:15 PM", culture), 5.30);
            cdr.CheckExtention();
        }

        [Test]
        public void CheckHourType_withZeroDuration_shouldReturnError()
        {
            CultureInfo culture = new CultureInfo("en-US");

            CDR cdr = new CDR("077-5649621", "071-4565324", Convert.ToDateTime("1/1/2010 12:10:15 PM", culture), 0.00);
            cdr.CheckHourType();
        }
        #endregion
    }
}
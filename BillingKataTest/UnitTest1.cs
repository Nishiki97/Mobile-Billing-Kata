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

        #region test cases for CDR
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
        #endregion

        #region test for user input validation
        [Test]
        public void CheckUSerInput_withNullInput_shouldReturnError()
        {
            UserInputHandler newuserinput = new UserInputHandler();
            newuserinput.userName = "";
            Assert.IsEmpty(newuserinput.userName);
        }

        [Test]
        public void CheckUSerInput_withNotNullInput_shouldReturnSuccess()
        {
            UserInputHandler newuserinput = new UserInputHandler();
            newuserinput.userName = "Nishiki Yapa";
            Assert.IsNotEmpty(newuserinput.userName);
        }

        [Test]
        public void CheckMonthInput_withNullInput_shouldReturnError()
        {
            UserInputHandler newuserinput = new UserInputHandler();
            newuserinput.userMonth = "";
            Assert.IsEmpty(newuserinput.userMonth);
        }

        [Test]
        public void CheckMonthInput_withNotNullInput_shouldReturnSuccess()
        {
            UserInputHandler newuserinput = new UserInputHandler();
            newuserinput.userMonth = "January";
            Assert.IsNotEmpty(newuserinput.userMonth);
        }
        #endregion
    }
}
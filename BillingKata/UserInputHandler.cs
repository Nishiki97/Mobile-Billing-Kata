﻿using System;

namespace BillingKata
{
    public class UserInputHandler
    {
        public string userName;
        public enum Months
        {
            January,    
            February,   
            March,      
            April,      
            May,        
            June,       
            July,
            August,
            September,
            October,
            November,
            December
        }
        public string userMonth;

        public void CheckUserNameInput()
        {
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Name can't be empty! Input your name once more");
                userName = Console.ReadLine();
            }
        }

        public void CheckMonthUserInput()
        {
            if (string.IsNullOrEmpty(userMonth))
            {
                Console.WriteLine("Month can't be empty! Enter month once more");
                userName = Console.ReadLine();
            }
        }
    }
}
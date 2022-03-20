using System;
using System.Collections;
using System.Collections.Generic;

namespace BillingKata
{
    public class CDR
    {
        #region variable declaration
        //subscriberPhoneNo
        private string subscriberPhoneNo;
        public string SubscriberPhoneNo
        {
            get { return subscriberPhoneNo; }
            set { subscriberPhoneNo = value; }
        }
        //receiverPhoneNo
        private string receiverPhoneNo;
        public string ReceiverPhoneNo
        {
            get { return receiverPhoneNo; }
            set { receiverPhoneNo = value; }
        }
        //startingTime
        private DateTime startingTime;
        public DateTime StartingTime
        {
            get { return startingTime; }
            set { startingTime = value; }
        }
        //duration
        private double duration;
        public double Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        //CallType
        private string callType;
        public string CallType
        {
            get { return callType; }
            set { callType = value; }
        }

        //newStartedTime
        public double newStartedTime;
        //callEndedTime
        public double callEndedTime;
        //individual Cost
        public double individualCost;
        //CDR list
        public List<CDR> cdrList = new List<CDR>();
        #endregion

        #region default and overload constructors
        public CDR()
        {
            subscriberPhoneNo = "";
            receiverPhoneNo = "";
            startingTime = new DateTime(); 
            duration = 0.00;
        }

        public CDR(string subscriberPhoneNo, string receiverPhoneNo, DateTime startingTime, double duration)
        {
            this.subscriberPhoneNo = subscriberPhoneNo;
            this.receiverPhoneNo = receiverPhoneNo;
            this.startingTime = startingTime;
            this.duration = duration;
        }
        #endregion

        #region methods
        //get call detail records to the relevant user and user input month
        public List<CDR> GetCDRList(Customer customer, string month)
        {
            List<CDR> newCdrDictionary = new List<CDR>();

            for (int i = 0; i < cdrList.Count; i++)
            {
                if(customer.PhoneNumber == cdrList[i].subscriberPhoneNo && month == cdrList[i].startingTime.ToString("MMMM"))
                {
                    CDR cdr = cdrList[i];
                    subscriberPhoneNo = cdr.subscriberPhoneNo;
                    receiverPhoneNo = cdr.receiverPhoneNo;
                    startingTime = cdr.startingTime;
                    duration = cdr.duration;

                    newCdrDictionary.Add(cdr);
                }
            }

            return newCdrDictionary;

        }

        //check the call extention either it's local or long distance
        public string CheckExtention()
        {
            if(subscriberPhoneNo == "" || receiverPhoneNo == "")
            {
                callType = "Mobile Numbers cannot be null";
            }
            else
            {
                string splitSubscriberNo = subscriberPhoneNo.Substring(0, 3);
                string splitReceiverPhoneNo = receiverPhoneNo.Substring(0, 3);

                callType = (splitSubscriberNo.Equals(splitReceiverPhoneNo)) ? "Local" : "Long distance calls";
            }

            return callType;

        }

        //get the start and the end call time
        public void getStartedandEndedTime()
        {
            DateTime dt = DateTime.Parse(startingTime.ToString());
            
            string newTimeWithColon = dt.ToString("HH:mm");
            string newTimeWithDot = newTimeWithColon.Replace(':', '.');
            
            newStartedTime = double.Parse(newTimeWithDot, System.Globalization.CultureInfo.InvariantCulture);
            
            if (duration == 0.00)
            {
                Console.WriteLine("Duration Cannot be zero!");
            }
            else
            {
                callEndedTime = newStartedTime + duration / 3600;
            }
        }
        #endregion
    }
}
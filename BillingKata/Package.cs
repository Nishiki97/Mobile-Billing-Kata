using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingKata
{
    internal class Package
    {
        #region variable declaration
        private char packageName;
        public char PackageName { 
            get 
            { 
                return packageName; 
            } 
            set
            {
                packageName = value;
            }
        }
        private int rental;
        public int Rental
        {
            get
            {
                return rental;
            }
            set 
            { 
                rental = value; 
            }
        }
        private string billingType;
        public string BillingType
        {
            get 
            { 
                return billingType; 
            }
            set 
            { 
                billingType = value; 
            }
        }
        private string callType;
        public string CallType
        {
            get 
            { 
                return callType; 
            }
            set
            {
                callType = value;
            }
        }
        private string hourType;
        public string HourType
        {
            get
            {
                return hourType;
            }
            set
            {
                hourType = value;
            }
        }
        private double peakHoursStart;
        private double peakHoursEnd;
        private double offPeakHoursStart;
        private double offPeakHoursEnd;
        private double peakHourCharge;
        private double offPealHourCharge;
        #endregion

        #region default and overload constructors
        public Package()
        {
            packageName = 'A';
            rental = 0;
            billingType = "";
            callType = "";
            hourType = "";
        }

        public Package(char packageName, int rental, string billingType)
        {
            this.packageName=packageName;
            this.rental=rental;
            this.billingType=billingType;
        }
        #endregion

        #region methods
        public virtual void GetCallType(CDR cdr)
        {
            CallType = cdr.CheckExtention();
        }
        #endregion

        #region move this method to bill.cs
        public virtual void GetHourCost(CDR cdr)
        {
            cdr.getStartedandEndedTime();

            double startedTime = cdr.newStartedTime;
            double endedTime = cdr.callEndedTime;
            double timeGap = 0.00;

            for(double i = peakHoursStart; i < peakHoursEnd; i++)
            {
                if(i == startedTime)
                {
                    if(endedTime < peakHoursEnd)
                    {
                        timeGap = endedTime - startedTime;

                        switch (billingType)
                        {
                            case "Per minute" when callType == "Local":
                                peakHourCharge = timeGap / 60 * 3;
                                break;
                            case "Per minute" when callType == "Long distance call":
                                peakHourCharge = timeGap / 60 * 5;
                                break;
                            case "Per second" when callType == "Local":
                                peakHourCharge = timeGap / 3600 * 4;
                                break;
                            default:
                                peakHourCharge = timeGap / 3600 * 6;
                                break;
                        }
                    }
                    else
                    {
                        timeGap  = peakHoursEnd - startedTime;

                        switch (billingType)
                        {
                            case "Per minute" when callType == "Local":
                                peakHourCharge = timeGap / 60 * 3;
                                break;
                            case "Per minute" when callType == "Long distance call":
                                peakHourCharge = timeGap / 60 * 5;
                                break;
                            case "Per second" when callType == "Local":
                                peakHourCharge = timeGap / 3600 * 4;
                                break;
                            default:
                                peakHourCharge = timeGap / 3600 * 6;
                                break;
                        }
                    }
                }
            }

            
        }
        #endregion

        
    }
}

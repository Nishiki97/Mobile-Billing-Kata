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
        //package name
        private char packageName;
        public char PackageName
        {
            get { return packageName; }
            set { packageName = value; }
        }
        //rental
        private double rental;
        public double Rental
        {
            get { return rental; }  
            set { rental = value; }
        }
        //billing type
        private string billingType;
        public string BillingType
        {
            get { return billingType; }
            set { billingType = value; }
        }
        //call type
        private string callType;
        public string CallType
        {
            get { return callType; }
            set { callType = value; }
        }
        //local - peak hour charge
        private int localPeakHourCharge;
        public int LocalPeakHourChargegion
        {
            get { return localPeakHourCharge; }
            set { localPeakHourCharge = value; }
        }
        // local - off peak hour charge
        private int localOffPeakHourCharge;
        public int LocalOffPeakHourCharge
        {
            get { return localOffPeakHourCharge; }
            set { localOffPeakHourCharge = value; }
        }
        //long distance - peak hour charge
        private int longDistancePeakHourCharge;
        public int LongDistancePeakHourCharge
        {
            get { return longDistancePeakHourCharge; }
            set { longDistancePeakHourCharge = value; }
        }
        //long distance - off peak hour charge
        private int longDistanceOffPeakHourCharge;
        public int LongDistanceOffPeakHourCharge
        {
            get { return longDistanceOffPeakHourCharge; }
            set { longDistanceOffPeakHourCharge = value; }
        }
        //peak hour starting time
        private double peakHourStartTime;
        public double PeakHourStartTime
        {
            get { return peakHourStartTime; }
            set { peakHourStartTime = value; }
        }
        //peak hour ending time
        private double peakHourEndTime;
        public double PeakHourEndTime
        {
            get { return peakHourEndTime; }
            set { peakHourEndTime = value; }
        }
        //off peak hour starting time
        private double offPeakHourStartTime;
        public double OffPeakHourStartTime
        {
            get { return offPeakHourStartTime; }
            set { offPeakHourStartTime = value; }
        }
        //off peak hour ending time
        private double offPeakHourEndTime;
        public double OffPeakHourEndTime
        {
            get { return offPeakHourEndTime; }
            set { OffPeakHourEndTime = value; }
        }
        //individual cost
        public double individualCost;
        #endregion

        #region default and overload constructors
        public Package()
        {
            packageName = 'A';
            rental = 0.00;
            billingType = "";
            callType = "";
            localPeakHourCharge = 0;
            localOffPeakHourCharge = 0;
            longDistancePeakHourCharge = 0;
            longDistanceOffPeakHourCharge = 0;
            peakHourEndTime = 0;
            peakHourStartTime = 0;
            offPeakHourEndTime = 0;
            offPeakHourStartTime = 0;
        }

        public Package(char packageName, double rental, string billingType, string callType, int localPeakHourCharge, int localOffPeakHourCharge, 
            int longDistancePeakHourCharge, int longDistanceOffPeakHourCharge, double peakHourEndTime, double peakHourStartTime, double offPeakHourEndTime, double offPeakHourStartTime)
        {
            this.packageName=packageName;
            this.rental=rental;
            this.billingType=billingType;
            this.callType=callType;
            this.localPeakHourCharge=localPeakHourCharge;
            this.localOffPeakHourCharge=localOffPeakHourCharge;
            this.longDistancePeakHourCharge = longDistancePeakHourCharge;
            this.longDistanceOffPeakHourCharge = longDistanceOffPeakHourCharge;
            this.peakHourEndTime = peakHourEndTime;
            this.peakHourStartTime = peakHourStartTime;
            this.offPeakHourEndTime = offPeakHourEndTime;
            this.offPeakHourStartTime = offPeakHourStartTime;
        }
        #endregion

        #region methods
        //get the billing type charge according to the package either it's per minute or per seconds 
        private int GetValueByBillingType()
        {
            switch (BillingType)
            {
                case "Per minute":
                    return 60;
                default:
                    return 3600;
            }
        }
        //calculate the off peak charge
        private double GetOffPeakCharge(List<CDR> cdrItems)
        {
            double totalOffPEakCharge = 0.00;

            foreach(CDR cdr in cdrItems)
            {
                double FirstOffPeakhourTypeCharge = 0.00;
                double SecondOffPeakhourTypeCharge = 0.00;
                double timGapByMinute = cdr.Duration / GetValueByBillingType();

                for (double i = offPeakHourStartTime; i < 24.00; i++)
                {
                    if (i == cdr.newStartedTime || i == cdr.callEndedTime)
                    {
                        switch (CallType)
                        {
                            case "Local":
                                FirstOffPeakhourTypeCharge = timGapByMinute * localOffPeakHourCharge;
                                break;
                            default:
                                FirstOffPeakhourTypeCharge = timGapByMinute * longDistanceOffPeakHourCharge;
                                break;
                        }
                    }

                }

                for (double j = 00.00; j < offPeakHourEndTime; j++)
                {
                    if (j == cdr.newStartedTime || j == cdr.callEndedTime)
                    {
                        switch (CallType)
                        {
                            case "Local":
                                SecondOffPeakhourTypeCharge = timGapByMinute * localOffPeakHourCharge;
                                break;
                            default:
                                SecondOffPeakhourTypeCharge = timGapByMinute * longDistanceOffPeakHourCharge;
                                break;
                        }
                    }
                }
                individualCost = FirstOffPeakhourTypeCharge + SecondOffPeakhourTypeCharge;
                totalOffPEakCharge += FirstOffPeakhourTypeCharge + SecondOffPeakhourTypeCharge;
            }

            return totalOffPEakCharge;
            
        }

        private double GetPeakCharge(List<CDR> cdrList)
        {
            double totalPeakHourCharge = 0.00;

            foreach (CDR cdr in cdrList)
            {
                double PeakhourTypeCharge = 0.00;
                double timGapByMinute = cdr.Duration / GetValueByBillingType();

                for (double j = peakHourStartTime; j < peakHourEndTime; j++)
                {
                    if (j == cdr.newStartedTime || j == cdr.callEndedTime)
                    {
                        switch (CallType)
                        {
                            case "Local":
                                PeakhourTypeCharge = timGapByMinute * localPeakHourCharge;
                                break;
                            default:
                                PeakhourTypeCharge = timGapByMinute * longDistancePeakHourCharge;
                                break;
                        }
                    }
                }

                totalPeakHourCharge += PeakhourTypeCharge;
            }

            return totalPeakHourCharge;
        }

        public double CalculateHourCharge(List<CDR> cdr)
        {
            return GetPeakCharge(cdr) + GetOffPeakCharge(cdr);
        }
        #endregion
    }
}

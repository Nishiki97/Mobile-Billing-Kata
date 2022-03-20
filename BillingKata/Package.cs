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
        public char PackageName
        {
            get { return packageName; }
            set { packageName = value; }
        }

        private double rental;
        public double Rental
        {
            get { return rental; }  
            set { rental = value; }
        }

        private string billingType;
        public string BillingType
        {
            get { return billingType; }
            set { billingType = value; }
        }

        private string callType;
        public string CallType
        {
            get { return callType; }
            set { callType = value; }
        }

        private int localPeakHourCharge;
        public int LocalPeakHourChargegion
        {
            get { return localPeakHourCharge; }
            set { localPeakHourCharge = value; }
        }

        private int localOffPeakHourCharge;
        public int LocalOffPeakHourCharge
        {
            get { return localOffPeakHourCharge; }
            set { localOffPeakHourCharge = value; }
        }

        private int longDistancePeakHourCharge;
        public int LongDistancePeakHourCharge
        {
            get { return longDistancePeakHourCharge; }
            set { longDistancePeakHourCharge = value; }
        }

        private int longDistanceOffPeakHourCharge;
        public int LongDistanceOffPeakHourCharge
        {
            get { return longDistanceOffPeakHourCharge; }
            set { longDistanceOffPeakHourCharge = value; }
        }

        private double peakHourStartTime;
        public double PeakHourStartTime
        {
            get { return peakHourStartTime; }
            set { peakHourStartTime = value; }
        }

        private double peakHourEndTime;
        public double PeakHourEndTime
        {
            get { return peakHourEndTime; }
            set { peakHourEndTime = value; }
        }

        private double offPeakHourStartTime;
        public double OffPeakHourStartTime
        {
            get { return offPeakHourStartTime; }
            set { offPeakHourStartTime = value; }
        }

        private double offPeakHourEndTime;
        public double OffPeakHourEndTime
        {
            get { return offPeakHourEndTime; }
            set { OffPeakHourEndTime = value; }
        }
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

        private double GetOffPeakCharge(CDR cdr)
        {
            double FirstOffPeakhourTypeCharge = 0.00;
            double SecondOffPeakhourTypeCharge = 0.00;
            double timGapByMinute = cdr.Duration / GetValueByBillingType();

            for (double i = offPeakHourStartTime; i < 24.00; i++)
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

            for (double j = 00.00; j < offPeakHourEndTime; j++)
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

            return FirstOffPeakhourTypeCharge + SecondOffPeakhourTypeCharge;
        }

        private double GetPeakCharge(CDR cdr)
        {
            double PeakhourTypeCharge = 0.00;
            double timGapByMinute = cdr.Duration / GetValueByBillingType();

            for (double j = peakHourStartTime; j < peakHourEndTime; j++)
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

            return PeakhourTypeCharge;
        }

        public double CalculateHourCharge(CDR cdr)
        {
            return GetPeakCharge(cdr) + GetOffPeakCharge(cdr);
        }
        #endregion
    }
}

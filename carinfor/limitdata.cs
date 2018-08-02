using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace carinfor
{
    public class limitdata
    {
        private string isUsed;

        public string IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }
        private string ambientCOUp;

        public string AmbientCOUp
        {
            get { return ambientCOUp; }
            set { ambientCOUp = value; }
        }
        private string ambientCO2Up;

        public string AmbientCO2Up
        {
            get { return ambientCO2Up; }
            set { ambientCO2Up = value; }
        }
        private string ambientHCUp;

        public string AmbientHCUp
        {
            get { return ambientHCUp; }
            set { ambientHCUp = value; }
        }
        private string ambientNOUp;

        public string AmbientNOUp
        {
            get { return ambientNOUp; }
            set { ambientNOUp = value; }
        }
        private string backgroundCOUp;

        public string BackgroundCOUp
        {
            get { return backgroundCOUp; }
            set { backgroundCOUp = value; }
        }
        private string backgroundCO2Up;

        public string BackgroundCO2Up
        {
            get { return backgroundCO2Up; }
            set { backgroundCO2Up = value; }
        }
        private string backgroundHCUp;

        public string BackgroundHCUp
        {
            get { return backgroundHCUp; }
            set { backgroundHCUp = value; }
        }
        private string backgroundNOUp;

        public string BackgroundNOUp
        {
            get { return backgroundNOUp; }
            set { backgroundNOUp = value; }
        }
        private string residualHCUp;

        public string ResidualHCUp
        {
            get { return residualHCUp; }
            set { residualHCUp = value; }
        }
        private string cOAndCO2;

        public string COAndCO2
        {
            get { return cOAndCO2; }
            set { cOAndCO2 = value; }
        }
        private string cO5025;

        public string CO5025
        {
            get { return cO5025; }
            set { cO5025 = value; }
        }
        private string hC5025;

        public string HC5025
        {
            get { return hC5025; }
            set { hC5025 = value; }
        }
        private string nO5025;

        public string NO5025
        {
            get { return nO5025; }
            set { nO5025 = value; }
        }
        private string cO2540;

        public string CO2540
        {
            get { return cO2540; }
            set { cO2540 = value; }
        }
        private string hC2540;

        public string HC2540
        {
            get { return hC2540; }
            set { hC2540 = value; }
        }
        private string nO2540;

        public string NO2540
        {
            get { return nO2540; }
            set { nO2540 = value; }
        }
        private string vmasCO;

        public string VmasCO
        {
            get { return vmasCO; }
            set { vmasCO = value; }
        }
        private string vmasHC;

        public string VmasHC
        {
            get { return vmasHC; }
            set { vmasHC = value; }
        }
        private string vmasNOx;

        public string VmasNOx
        {
            get { return vmasNOx; }
            set { vmasNOx = value; }
        }
        private string vmasHCNOx;

        public string VmasHCNOx
        {
            get { return vmasHCNOx; }
            set { vmasHCNOx = value; }
        }
        private string smokeK;

        public string SmokeK
        {
            get { return smokeK; }
            set { smokeK = value; }
        }
        private string smokeHSU;

        public string SmokeHSU
        {
            get { return smokeHSU; }
            set { smokeHSU = value; }
        }
        private string dieselRevUp;

        public string DieselRevUp
        {
            get { return dieselRevUp; }
            set { dieselRevUp = value; }
        }
        private string dieselRevBelow;

        public string DieselRevBelow
        {
            get { return dieselRevBelow; }
            set { dieselRevBelow = value; }
        }
        private string maxPower;

        public string MaxPower
        {
            get { return maxPower; }
            set { maxPower = value; }
        }
        private string highIdleCO;

        public string HighIdleCO
        {
            get { return highIdleCO; }
            set { highIdleCO = value; }
        }
        private string highIdleHC;

        public string HighIdleHC
        {
            get { return highIdleHC; }
            set { highIdleHC = value; }
        }
        private string lowIdleCO;

        public string LowIdleCO
        {
            get { return lowIdleCO; }
            set { lowIdleCO = value; }
        }
        private string lowIdleHC;

        public string LowIdleHC
        {
            get { return lowIdleHC; }
            set { lowIdleHC = value; }
        }
        private string fASmokeK;

        public string FASmokeK
        {
            get { return fASmokeK; }
            set { fASmokeK = value; }
        }
        private string fARev;

        public string FARev
        {
            get { return fARev; }
            set { fARev = value; }
        }
        private string smokeRb;

        public string SmokeRb
        {
            get { return smokeRb; }
            set { smokeRb = value; }
        }

    }
}

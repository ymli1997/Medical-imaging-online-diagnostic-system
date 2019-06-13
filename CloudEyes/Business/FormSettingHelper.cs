using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Rising.Utilities.Utilities;

namespace CloudEyes.Business
{
    class FormSettingHelper
    {
        public static Boolean LongitudeDisplacementIsSelected = false;


        public static void InitConfig()
        {
            //Boolean  LongitudeDisplacementIsSelected = false;
            try
            {
                string tempSTr = ConfigurationManager.AppSettings["MultipleGraphsLongitudeDisplacementIsSelected"].ToString();
                LongitudeDisplacementIsSelected = Convert.ToBoolean(tempSTr);
            }
            catch
            {
            }
        }


        

        public static void SaveConfig()
        {
            try
            {
                AppConfigHelper.UpdateAppConfig("MultipleGraphsLongitudeDisplacementIsSelected", Convert.ToString(LongitudeDisplacementIsSelected));

            }
            catch
            {

            }
            

        }
    }
}


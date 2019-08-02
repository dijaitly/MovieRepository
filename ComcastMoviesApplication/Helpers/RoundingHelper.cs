using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComcastMoviesApplication.Helpers
{
    public class RoundingHelper
    {
        public static double Round(double value)
        {
          
            int integerComponent = (int)value;
            double decimalComponent = value - integerComponent;
            if (decimalComponent < 0.25)
            {
                 return integerComponent ;
            }
            else if (decimalComponent >= 0.25 && decimalComponent < 0.75)
            {
                return integerComponent + 0.50;
            }
            else  
            {
                return integerComponent + 1.00;
            }
            
            
        }
    }
}
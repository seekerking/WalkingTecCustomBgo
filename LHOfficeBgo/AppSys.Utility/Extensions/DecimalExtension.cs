using System;

namespace AppSys.Utility.Extensions
{
    public static class DecimalExtension
    {
     
            public static decimal CutDecimalWithN(this decimal d, int n)
            {
                string strDecimal = d.ToString();
                int index = strDecimal.IndexOf(".");
                if (index == -1 || strDecimal.Length < index + n + 1)
                {
                    strDecimal = string.Format("{0:F" + n + "}", d);
                }
                else
                {
                    int length = index;
                    if (n != 0)
                    {
                        length = index + n + 1;
                    }
                    strDecimal = strDecimal.Substring(0, length);
                }
                return Decimal.Parse(strDecimal);
            }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAssignment.Helpers
{
    public static class StringHelper
    {
        public static string CutTo(this string text, char sign)
        {
            
            int index = text.IndexOf(sign);
            if (index > 0)
               text = text.Substring(0, index);

            return text;
        }

        public static string CutFrom(this string text, char sign)
        {
            int index = text.IndexOf(sign);
            if (index >= 0)
                text = text.Substring(index+1);

            return text;
        }
    }
}
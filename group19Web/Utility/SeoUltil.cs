using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace group19Web.Utility
{
    public class SeoUltil
    {
        private static String convertToString(String[] part)
        {
            String result = "";
            for (int i = 0; i < part.Length; i++)
            {
                result += part[i].ToString().Trim() + "-";
            }
            return result;
        }
        public static String seo(String seo)
        {

            char[] sperator = { ' ' };
            String[] temp = seo.Split(sperator);
            return convertToString(temp);
        }
    }
}
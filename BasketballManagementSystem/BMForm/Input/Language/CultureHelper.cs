using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BasketballManagementSystem.BMForm.input.language
{
    public class CultureHelper
    {
        private static CultureInfo[] CultureInfomation = CultureInfo.GetCultures(CultureTypes.AllCultures);

        public static string GetCultureInfoStringFromDisplayName(string displayName)
        {
            foreach (CultureInfo c in CultureInfomation)
            {
                if (c.DisplayName == displayName)
                {
                    return c.ToString();
                }
            }

            return null;
        }
    }
}

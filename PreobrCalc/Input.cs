using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreobrCalc
{
    class Input
    {
        static public bool TryParse(string str,out double num)
        {
            if (!double.TryParse(str, out num))
            {
                string str2 = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '.')
                        str2 += ',';
                    else
                        str2 += str[i];
                }
                if (!double.TryParse(str2, out num))
                {
                    num = 0;
                    return false;
                }
                return true;
            }
            return true;
        } 
    }
}

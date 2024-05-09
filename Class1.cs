using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projMe
{
    internal class Class1
    {
        public static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }
    }
}

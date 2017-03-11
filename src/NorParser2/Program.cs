using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace NorParser2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var output = new Parser().Parse("  had ~ ! @ # $ % ^ & * ( ) _ + - = ` { } |  : \" < > ? [ ] \\ ; ' , . / * - + , ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Data
{
    public class Class1
    {
        public virtual void doSomething(string haj = "haj1")
        {
            Console.WriteLine(haj);
        }
    }
    public class Class2 : Class1
    {
        public override void doSomething(string haj = "haj2")
        {
            base.doSomething();
            Console.WriteLine(haj);
        }

    }
}

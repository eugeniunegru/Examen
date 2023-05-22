using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class Outdata
    {
        public Outdata() { }
        public void WriteStringToFile(string str)
        {
            string filePath = "C:\text.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                
                    writer.WriteLine(str);
                
            }
        }

    }
  

}

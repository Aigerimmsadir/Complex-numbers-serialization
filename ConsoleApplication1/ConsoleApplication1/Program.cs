using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{[Serializable]
    public class Complex
    {
        private double a, b;

        public double A
        {
            get
            {
                return a;
            }
            set
            {
                this.a = value;

            }
        }
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                this.b = value;

            }

        }
        public static Complex operator +(Complex l, Complex r)
        {
            Complex res = new Complex();
            res.A = r.A + l.A;
            res.B = r.B + l.B;
            return res;
        }
        public override string ToString()
        {
            return string.Format("Number is : {0}+ {1}*i",
              a, b);
        }
    }
    class Program
    {
        static void Serialize(Complex complex)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fStream = new FileStream(@"C:\Users\Lenovo\Desktop\мой сайт\lol.dat", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fStream, complex);
            }
        }
        static Complex Deserialize()
        {
            using (var fStream = File.OpenRead(@"C:\Users\Lenovo\Desktop\мой сайт\lol.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Complex newcomplex = (Complex)formatter.Deserialize(fStream);
                return newcomplex;
            }

        }

        static void Main(string[] args)
        {
            Complex k = new Complex();

            string line = Console.ReadLine();
            string[] param = line.Split(' ');
            k.A = double.Parse(param[0]);

            k.B = double.Parse(param[1]);


            Complex n = new Complex();
            string line2 = Console.ReadLine();
            string[] param2 = line2.Split(' ');
            n.A = double.Parse(param2[0]);

            n.B = double.Parse(param2[1]);
            Complex j = new Complex();
            j = k + n;
            
            Serialize(j);
            Complex jj = Deserialize();
            Console.WriteLine(jj);

        }
    }
}
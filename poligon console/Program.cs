using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poligon // Note: actual namespace depends on the project name.
{
    class Tacka
    {
        public int x, y;
        public Tacka(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool Jednako(Tacka a, Tacka b)
        {
            if ((a.x == b.x) && (a.y == b.y)) return true;
            else return false;
        }
    }
    class Vektor
    {
        public Tacka a, b;
        public Vektor(Tacka a, Tacka b)
        {
            this.a = a;
            this.b = b;
        }
        public static bool SekuSe(Vektor prvi, Vektor drugi)
        {
            int I1 = [(prvi.a.x, prvi.b.x), max(prvi.a.x, prvi.b.x)]
            int I2 = [min(X3, X4), max(X3, X4)]
        }
    }
    class Poligon
    {
        public Vektor[] vektori;
        public int n;
        
        public Poligon()
        {

        }
        public void Unos()
        {
            n = Convert.ToInt16(Console.ReadLine());
            vektori = new Vektor[n];
            for (int i = 0; i < n; i++)
            {
                Tacka a = new Tacka(Convert.ToInt16(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
                Tacka b = new Tacka(Convert.ToInt16(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
                Vektor vektor = new Vektor(a, b);
                vektori[i] = vektor;
            }
        }
        public void Ispis()
        {
            for (int i = 0; i < vektori.Length; i++)
            {
                Console.WriteLine("Vektor " + i + '\n' +"Tacka A(" + vektori[i].a.x + ", " + vektori[i].a.y + ")" + '\n' + "Tacka B(" + vektori[i].b.x + ", " + vektori[i].b.y + ")");
            }
        }
        public bool prost()
        {
            // ponovljeno teme
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Tacka.Jednako(vektori[i].a, vektori[j].b)) return false;
                }
            }
            for (int i = 0; i < broj_temena - 2; i++)
            {
                vektor prvi = new vektor(teme[i], teme[i + 1]);
                for (int j = i + 2; j < broj_temena; j++)
                {
                    if (i == 0 && j == broj_temena - 1) continue;
                    // prvi.stampa();
                    vektor drugi = new vektor(teme[j], teme[(j + 1) % broj_temena]);
                    // drugi.stampa();
                    if (vektor.seku_se(prvi, drugi) == true) return false;
                }
            }
            return true;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Poligon poligon = new Poligon();
            poligon.Unos();
            poligon.Ispis();
        }
    }
}
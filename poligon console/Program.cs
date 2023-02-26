using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Poligon // Note: actual namespace depends on the project name.
{
    class Tacka
    {
        public double x, y;
        public Tacka(double x, double y)
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
        public static bool SekuSe(Vektor v1, Vektor v2)
        {
            Tacka v1a = v1.a;   Tacka v1b = v1.b;
            Tacka v2a = v2.a;   Tacka v2b = v2.b;

            double s1_x, s1_y, s2_x, s2_y;
            s1_x = v1b.x - v1a.x; s1_y = v1b.y - v1a.y;
            s2_x = v2b.x - v2a.x; s2_y = v2b.y - v2a.y;

            double s, t;
            s = (-s1_y * (v1a.x - v2a.x) + s1_x * (v1a.y - v2a.y)) / (-s2_x * s1_y + s1_x * s2_y);
            t = (s2_x * (v1a.y - v2a.y) - s2_y * (v1a.x - v2a.x)) / (-s2_x * s1_y + s1_x * s2_y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1 && !(s == 0 && t == 0) && !(s == 1 && t == 1))
            {
                return true;
            }

            return false;
        }
        public static double VektorskiProizvod(Vektor prvi, Vektor drugi)
        {
            double part1 = (prvi.b.x - prvi.a.x) * (drugi.b.y - drugi.a.y);
            double part2 = (drugi.b.x - drugi.a.x) * (prvi.b.y - prvi.a.y);
            return part1 - part2;
        }

    }
    class Poligon
    {
        public Vektor[] vektori;
        public Tacka[] tacke;
        public int n;

        public Poligon()
        {

        }
        public void BoljiUnos()
        {
            Console.WriteLine("koliko tacaka hoces? ");
            n = Convert.ToInt16(Console.ReadLine());
            vektori = new Vektor[n];
            tacke = new Tacka[n + 1];
            Console.WriteLine("unesi T({0}) ", 0);
            Tacka a = new Tacka(Convert.ToInt16(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
            Console.WriteLine("unesi T({0}) ", 1);
            Tacka b = new Tacka(Convert.ToInt16(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
            tacke[0] = a; tacke[1] = b;
            Vektor vektorPrvi = new Vektor(a, b);
            vektori[0] = vektorPrvi;
            for (int i = 1; i < n - 1; i++)
            {
                Console.WriteLine("unesi T({0}) ", i + 1);
                Tacka tacka = new Tacka(Convert.ToInt16(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
                Vektor vektor = new Vektor(b, tacka);
                vektori[i] = vektor;
                tacke[i + 1] = tacka;
                b = tacka;
            }
            Vektor vektorPoslednji = new Vektor(b, tacke[0]);
            vektori[n - 1] = vektorPoslednji;
            Array.Resize(ref tacke, n);
        }
        public void Ispis()
        {
            for (int i = 0; i < vektori.Length; i++)
            {
                Console.WriteLine("Vektor " + i + '\n' + "Tacka A(" + vektori[i].a.x + ", " + vektori[i].a.y + ")" + '\n' + "Tacka B(" + vektori[i].b.x + ", " + vektori[i].b.y + ")");
            }
        }
        public bool Prost()
        {
            if (n < 3)
            {
                return false;
            }

            for (int i = 0; i < vektori.Length; i++)
            {
                Vektor v1 = vektori[i];
                Tacka a = v1.a;
                Tacka b = v1.b;

                for (int j = i + 2; j < vektori.Length; j++)
                {
                    Vektor v2 = vektori[j];
                    Tacka c = v2.a;
                    Tacka d = v2.b;

                    if (Tacka.Jednako(a, c) || Tacka.Jednako(a, d) || Tacka.Jednako(b, c) || Tacka.Jednako(b, d))
                    {
                        continue;
                    }

                    if (Vektor.SekuSe(v1, v2))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public bool Konveksan()
        {
            if (Prost() == true)
            {
                return false;
            }
            int t = 0;
            for (int i = 0; i < n - 1; i++)
            {
                Vektor v1 = vektori[i];
                Vektor v2 = vektori[i + 1];
                if (Vektor.VektorskiProizvod(v1, v2) >= 0)
                {
                    t++;
                }
            }
            if (Vektor.VektorskiProizvod(vektori[n - 1], vektori[0]) >= 0)
            {
                t++;
            }
            if (t == 0 || t == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double Povrsina()
        {
            double pov = 0;
            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                pov += tacke[i].x * tacke[j].y;
                pov -= tacke[i].y * tacke[j].x;
            }
            return Math.Abs(pov / 2);
        }
        public bool TackaUPoligonu(Tacka tacka)
        {
            int t = 0;
            Tacka tackaDaleko = new Tacka(int.MaxValue, int.MaxValue);
            Vektor vektorTest = new Vektor(tacka, tackaDaleko);
            for (int i = 0; i < vektori.Length; i++)
            {
                if (Vektor.SekuSe(vektorTest, vektori[i]))
                {
                    t++;
                }
            }
            if (t % 2 == 0 || t == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Poligon poligon = new Poligon();
                Tacka tacka = new Tacka(1, 2);
                poligon.BoljiUnos();
                poligon.Ispis();
                Console.WriteLine("prost? " + poligon.Prost());
                Console.WriteLine("konveksan? " + poligon.Konveksan());
                Console.WriteLine("povrsina: " + poligon.Povrsina());
                Console.WriteLine("tacka u poligonu? " + poligon.TackaUPoligonu(tacka));
            }
        }
    }
}
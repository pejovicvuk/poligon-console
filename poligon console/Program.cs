using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public static bool SekuSe(Vektor v1, Vektor v2)
        {
            Tacka v1a = v1.a;
            Tacka v1b = v1.b;
            Tacka v2a = v2.a;
            Tacka v2b = v2.b;
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
            int t = 0;
            double ugao;
            for (int i = 0; i < n - 1  ; i++) //angle = atan2(vector2.y, vector2.x) - atan2(vector1.y, vector1.x);
            {
                ugao = Math.Atan2((vektori[i + 1].b.y - vektori[i + 1].a.y - vektori[i].b.x - vektori[i].a.x), (vektori[i + 1].b.x - vektori[i + 1].a.x - vektori[i].b.y - vektori[i].a.y));
                if (ugao > 0)
                {
                    t++;
                }
            }
            //slucaj kada se porede poslednji vektor sa prvim
            ugao = Math.Atan2((vektori[0].b.y - vektori[0].a.y - vektori[n - 1].b.x - vektori[n - 1].a.x), (vektori[0].b.x - vektori[0].a.x - vektori[n - 1].b.y - vektori[n - 1].a.y));
            if (ugao > 0)
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


        internal class Program
        {
            static void Main(string[] args)
            {
                Poligon poligon = new Poligon();
                poligon.Unos();
                poligon.Ispis();
                Console.WriteLine(poligon.Prost());
                Console.WriteLine(poligon.Konveksan());
            }
        }
    }
}
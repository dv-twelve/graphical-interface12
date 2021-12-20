using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp12_g_1
{
    class Triangle
    {
        // закрытые поля
        private int m_a { get; set; }
        private int m_b { get; set; }
        private int m_c { get; set; }

        // публичные свойства
        public int A{ get { return m_a; } set { m_a = value; } }
        public int B{ get { return m_b; } set { m_b = value; } }
        public int C{ get { return m_c; } set { m_c = value; } }

        // свойство для определения существования треуголника
        public bool TriangleIs 
        {
            get
            {
                if (m_c + m_b > m_a && m_a + m_c > m_b && m_a + m_b > m_c)
                {
                    return true;
                }
                return false;
            }
        }

        // индексатор
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:return m_a;
                    case 1: return m_b;
                    case 2: return m_c;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0: m_a=value;break;
                    case 1: m_b=value; break;
                    case 2: m_c=value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        // конструктор
        public Triangle(int a,int b,int c)
        {
            m_a = a;
            m_b = b;
            m_c = c;
        }
        // перегрузка метода ToString() класса родителя Object для вывода длин сторон треугольника на экран
        public override string ToString()
        {
            return String.Concat(m_a.ToString(), " ", m_b.ToString(), " ", m_c.ToString());
        }
        // метод для расчёт периметра треугольника
        public int Perimetr()
        {
            return m_a+ m_b + m_c;    
        }
        // метод для вычисления плозади треугольника
        public float Square()
        {
            float halfPermietr = (float)Perimetr() / 2;
            return MathF.Sqrt(halfPermietr*(halfPermietr-m_a)*(halfPermietr-m_b)*(halfPermietr-m_c));
        }

        // перегрузки опреаций
        public static Triangle operator ++(Triangle triangle)
        {
            triangle.A++;
            triangle.B++;
            triangle.C++;
            return triangle;
        }
        // перегрузки опреаций
        public static Triangle operator --(Triangle triangle)
        {
            triangle.A--;
            triangle.B--;
            triangle.C--;
            return triangle;
        }

        public static bool operator true(Triangle triangle)
        {
            return triangle.TriangleIs;
        }
        public static bool operator false(Triangle triangle)
        {
            return triangle.TriangleIs;
        }
        public static Triangle operator *(Triangle triangle, int scalar)
        {
            triangle.A*=scalar;
            triangle.B*=scalar;
            triangle.C*=scalar;

            return triangle;
        }

        // преобразование типа в строку
        public static explicit operator string(Triangle triangle)
        {
            return triangle.ToString();
        }
        // преобразование строки (value value value) в тип 
        public static explicit operator Triangle(string str)
        {
            string[] strs=str.Split(' ');

            return new Triangle(int.Parse(strs[0]), int.Parse(strs[1]), int.Parse(strs[2]));
        }
    }
}

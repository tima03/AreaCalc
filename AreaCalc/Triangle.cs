using System.Reflection.Metadata.Ecma335;

namespace AreaCalc
{
    public class Triangle : Figure
    {
        //встроенные геттеры и сеттеры не используются, поскольку через value нельзя проверить правильность ввода в случае чего.
        //в качестве них используются методы Get_... и Set_...
        private double A_angle;
        private double B_angle;
        private double C_angle;
        private double AB_side_length;
        private double BC_side_length;
        private double CA_side_length;
        private double AB_side_height;
        private double BC_side_height;
        private double CA_side_height;

        public Triangle(double ab_side_length, double bc_side_length, double ca_side_length)
        {
            this.AB_side_length = ab_side_length;
            this.BC_side_length = bc_side_length;
            this.CA_side_length = ca_side_length;
        }
        public void Set_A_angle(double a_angle) { A_angle = a_angle; }
        public void Set_B_angle(double b_angle) { B_angle = b_angle; }
        public void Set_C_angle(double c_angle) { C_angle = c_angle; }
        public void Set_AB_side_length(double ab_side_length) { AB_side_length = ab_side_length; }
        public void Set_BC_side_length(double bc_side_length) { BC_side_length = bc_side_length; }
        public void Set_CA_side_length(double ca_side_length) { CA_side_length = ca_side_length; }

        public void Set_AB_side_height(double ab_side_height) { AB_side_height = ab_side_height; }
        public void Set_BC_side_height(double bc_side_height) { BC_side_height = bc_side_height; }
        public void Set_CA_side_height(double ca_side_height) { CA_side_height = ca_side_height; }

        public double Get_A_angle() { return A_angle; }
        public double Get_B_angle() { return B_angle; }
        public double Get_C_angle() { return C_angle; }
        public double Get_AB_side_length() { return AB_side_length; }
        public double Get_BC_side_length() { return BC_side_length; }
        public double Get_CA_side_length() { return CA_side_length; }
        public double Get_AB_side_height() { return AB_side_height; }
        public double Get_BC_side_height() { return BC_side_height; }
        public double Get_CA_side_height() { return CA_side_height; }

        public bool isTriangle() 
        {
            if ((CA_side_length>0)&&(BC_side_length>0)&&(AB_side_length>0)&&(AB_side_length + BC_side_length > CA_side_length) && (BC_side_length + CA_side_length > AB_side_length) && (CA_side_length + AB_side_length > BC_side_length))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void TriangleTypeCheck()
        {
            if (!this.isTriangle())
            {
                Console.WriteLine("Фигура не является треугольником или такой треугольник не может существовать.");
                return;
            }

            bool isEquilateral = (AB_side_length == BC_side_length) && (BC_side_length == CA_side_length);
            bool isIsosceles = (AB_side_length == BC_side_length) || (BC_side_length == CA_side_length) || (AB_side_length == CA_side_length);

            // Сравнение вещественных чисел с учетом погрешности
            double epsilon = 1e-10;
            bool isRightAngled =
                Math.Abs(Math.Pow(AB_side_length, 2) + Math.Pow(BC_side_length, 2) - Math.Pow(CA_side_length, 2)) < epsilon ||
                Math.Abs(Math.Pow(BC_side_length, 2) + Math.Pow(CA_side_length, 2) - Math.Pow(AB_side_length, 2)) < epsilon ||
                Math.Abs(Math.Pow(CA_side_length, 2) + Math.Pow(AB_side_length, 2) - Math.Pow(BC_side_length, 2)) < epsilon;

            if (isEquilateral)
            {
                Console.WriteLine("Треугольник равносторонний.");
            }
            else if (isIsosceles && isRightAngled)
            {
                Console.WriteLine("Треугольник равнобедренный и прямоугольный.");
            }
            else if (isIsosceles)
            {
                Console.WriteLine("Треугольник равнобедренный.");
            }
            else if (isRightAngled)
            {
                Console.WriteLine("Треугольник прямоугольный.");
            }
            else
            {
                Console.WriteLine("Треугольник общего типа.");
            }
        }


        public override double GetArea()
        {
            if (this.isTriangle())
            {
                double Per_half = this.GetPerimeter() / 2;
                double Area = Math.Sqrt(Per_half * (Per_half - AB_side_length) * (Per_half - BC_side_length) * (Per_half - CA_side_length));
                return Area;
            }
            else
            { 
                Console.WriteLine("Фигура не является треугольником или такой треугольник не может существовать."); 
                return 0;
            }
            throw new NotImplementedException();
        }

        public override double GetPerimeter()
        {
            if (this.isTriangle())
            {
                return AB_side_length + BC_side_length + CA_side_length;
            }
            else
            {
                Console.WriteLine("Фигура не является треугольником или такой треугольник не может существовать.");
                return 0;
            }
            throw new NotImplementedException();
        }
    }
}

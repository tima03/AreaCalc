


namespace AreaCalc
{
    public class Circle:Figure
    {
            private double Radius;
            private double Diameter;
            public Circle(double radius)
            {
                this.Radius = radius;
                this.Diameter = radius*2;
            }
            public void Set_Radius(double radius) { Radius = radius; }

            public double Get_Radius() { return Radius; }

            public bool isCircle()
            {
                if (Radius>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override double GetArea()
            {
                if (this.isCircle())
                {
                    double Area = Math.PI*Math.Pow(Radius,2);
                    return Area;
                }
                else
                {
                    Console.WriteLine("Фигура не является кругом или такой круг не может существовать.");
                    return 0;
                }
                throw new NotImplementedException();
            }

            public override double GetPerimeter()
            {
                if (this.isCircle())
                {
                    return 2*Math.PI*Radius;
                }
                else
                {
                    Console.WriteLine("Фигура не является кругом или такой круг не может существовать.");
                    return 0;
                }
                throw new NotImplementedException();
            }
        }
}

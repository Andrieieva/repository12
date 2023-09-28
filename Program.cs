using System;

namespace Lesson_12_Inheritance_And_Polymorphism
{
    public class Shape
    {
        public Shape(string name)
        {
            _name = name;
        }

        private string _name = string.Empty;
        public string Name => _name;

        public virtual float Perimeter => 0;

        public virtual float Area => 0;

        public virtual void DrawShapeToConsole()
        {
            Console.WriteLine();
        }

        public override string ToString()
            => $"{_name} has an area of {Area} sq. units and perimeter of {Perimeter} units";
    }

    public class Circle : Shape
    {
        public Circle(float radius)
            : base(nameof(Circle))
        {
            Radius = radius;
        }

        public float Radius { get; }

        public override float Perimeter => 2 * (float)Math.PI * Radius;

        public override float Area => (float)Math.PI * Radius * Radius;

        public override void DrawShapeToConsole()
        {
            Console.WriteLine("Circle:");
            Console.WriteLine("  ***  ");
            Console.WriteLine("*     *");
            Console.WriteLine("*     *");
            Console.WriteLine("  ***  ");
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(float width, float height)
            : base(nameof(Rectangle))
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }

        public float Height { get; }

        public override float Area => Width * Height;

        public override float Perimeter => 2 * (Width + Height);

        public override void DrawShapeToConsole()
        {
            Console.WriteLine("Rectangle:");
            Console.WriteLine("********");
            Console.WriteLine("*      *");
            Console.WriteLine("********");
        }
    }

    public class Triangle : Shape
    {
        public Triangle(float side1, float side2, float side3)
            : base("Triangle")
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public float Side1 { get; }
        public float Side2 { get; }
        public float Side3 { get; }

        public override float Perimeter => Side1 + Side2 + Side3;

        public override float Area
        {
            get
            {
                float s = Perimeter / 2;
                return (float)Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
            }
        }

        public override void DrawShapeToConsole()
        {
            Console.WriteLine("Triangle:");
            Console.WriteLine("  /\\");
            Console.WriteLine(" /  \\");
            Console.WriteLine("/____\\");
        }
    }

    public class RightAngledTriangle : Triangle
    {
        public RightAngledTriangle(float baseSide, float height)
            : base(baseSide, height, (float)Math.Sqrt(baseSide * baseSide + height * height))
        {
            Name = "Right-Angled Triangle";
        }

        public string Name { get; }

        public override void DrawShapeToConsole()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("  /\\");
            Console.WriteLine(" /  \\");
            Console.WriteLine("/____\\");
        }
    }

    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(float baseSide, float side)
            : base(baseSide, side, side)
        {
            Name = "Isosceles Triangle";
        }

        public string Name { get; }

        public override void DrawShapeToConsole()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("   /\\");
            Console.WriteLine("  /  \\");
            Console.WriteLine(" /____\\");
        }
    }

    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(float side)
            : base(side, side, side)
        {
            Name = "Equilateral Triangle";
        }

        public string Name { get; }

        public override void DrawShapeToConsole()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("   *   ");
            Console.WriteLine("  ***  ");
            Console.WriteLine(" ***** ");
            Console.WriteLine("*******");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a shape type:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Right-Angled Triangle");
            Console.WriteLine("5. Isosceles Triangle");
            Console.WriteLine("6. Equilateral Triangle");

            int shapeChoice = int.Parse(Console.ReadLine());

            Shape chosenShape = null;

            switch (shapeChoice)
            {
                case 1:
                    Console.Write("Enter circle radius: ");
                    float circleRadius = float.Parse(Console.ReadLine());
                    chosenShape = new Circle(circleRadius);
                    break;
                case 2:
                    Console.Write("Enter rectangle width: ");
                    float rectWidth = float.Parse(Console.ReadLine());
                    Console.Write("Enter rectangle height: ");
                    float rectHeight = float.Parse(Console.ReadLine());
                    chosenShape = new Rectangle(rectWidth, rectHeight);
                    break;
                case 3:
                    Console.Write("Enter triangle side 1: ");
                    float side1 = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle side 2: ");
                    float side2 = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle side 3: ");
                    float side3 = float.Parse(Console.ReadLine());
                    chosenShape = new Triangle(side1, side2, side3);
                    break;
                case 4:
                    Console.Write("Enter right-angled triangle base side: ");
                    float baseSide = float.Parse(Console.ReadLine());
                    Console.Write("Enter right-angled triangle height: ");
                    float triangleHeight = float.Parse(Console.ReadLine());
                    chosenShape = new RightAngledTriangle(baseSide, triangleHeight);
                    break;
                case 5:
                    Console.Write("Enter isosceles triangle base side: ");
                    float isoscelesBaseSide = float.Parse(Console.ReadLine());
                    Console.Write("Enter isosceles triangle side: ");
                    float isoscelesSide = float.Parse(Console.ReadLine());
                    chosenShape = new IsoscelesTriangle(isoscelesBaseSide, isoscelesSide);
                    break;
                case 6:
                    Console.Write("Enter equilateral triangle side length: ");
                    float equilateralSide = float.Parse(Console.ReadLine());
                    chosenShape = new EquilateralTriangle(equilateralSide);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Drawing the chosen shape:");
            chosenShape.DrawShapeToConsole();
            Console.WriteLine();
            Console.WriteLine($"Perimeter: {chosenShape.Perimeter}");
            Console.WriteLine($"Area: {chosenShape.Area}");
        }
    }
}


namespace TestTask.Figures;

public class Triangle : Figure
{
    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    private double SideA { get; }
    private double SideB { get; }
    private double SideC { get; }
    
    
    
    public override double GetArea()
    {
        var semiPerimeter = (SideA + SideB + SideC) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    private bool IsRightAngled()
    {
        return true;
    }

    private bool IsValidSides()
    {
        return SideA + SideB < SideC && SideB + SideC < SideA && SideA + SideC < SideB;
    }
}
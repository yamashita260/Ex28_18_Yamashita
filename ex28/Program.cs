using System;

public class Ex_28_Yamashita
{
    static void Main()
    {
        TriangularPrism triangularPrism = new TriangularPrism(0, 0, 0);
        Console.WriteLine("三角柱");
        Console.WriteLine("計算方法を選択\n1.三辺と高さ\n2.底面の底辺と高さと柱の高さ");
            switch (InputInt(1, 2))
        {
            case 1:
                triangularPrism = new TriangularPrism(InputFloat("一辺の長さ(a)を入力してください"), InputFloat("一辺の長さ(b)を入力してください"), InputFloat("一辺の長さ(c)を入力してください"), InputFloat("高さを入力して下さい"));
                break;
            case 2:
                triangularPrism = new TriangularPrism(InputFloat("底面の底辺を入力して下さい"), InputFloat("底面の高さを入力して下さい"), InputFloat("高さを入力して下さい"));
                break;

        }

        Console.WriteLine("表面積 = " + triangularPrism.GetSurface());
        Console.WriteLine("体積 = " + triangularPrism.GetVolume());
    }

    static float InputFloat(string outoutstring)
    {
        float input;
        while(true)
        {
            Console.WriteLine(outoutstring);
            if(float.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }
        }
    }

    static float InputInt(int min, int max)
    {
        int input;
        while(true)
        {
            if(int.TryParse(Console.ReadLine(), out input))
            {
                if(input >= min && input <= max)
                {
                    return input;
                }
            }
        }
    }
}

class TriangularPrism
{
    float Bottom1, Bottom2, Bottom3, BottomHeight, Height;
    float bottom, side;
    public TriangularPrism(float bottom1, float bottom2, float bottom3, float height)
    {
        this.Bottom1= bottom1;
        this.Bottom2= bottom2;
        this.Bottom3= bottom3;
        this.Height= height;

        float Bottom = (bottom1 + bottom2 + bottom3) / 2.0f;
        bottom = MathF.Sqrt(Bottom * (Bottom - bottom1) * (Bottom - bottom2) * (Bottom - bottom3));
        side = (bottom1 + bottom2 + bottom3) * height;
    }

    public TriangularPrism(float bottom1, float height, float bottomHeight)
    {
        this.Bottom1= bottom1;
        this.BottomHeight= bottomHeight;
        this.Height= height;
        bottom = this.Bottom1 * this.BottomHeight / 2.0f;
        side = (float)(bottom1 + bottomHeight + Math.Sqrt(bottom1 * bottom1 + bottomHeight * bottomHeight)) * height;
    }
    public double GetSurface()
    {
        return bottom * 2 + side;
    }
    public float GetVolume()
    {
        return bottom * Height;
    }
}
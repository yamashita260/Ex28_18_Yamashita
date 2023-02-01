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
                Console.WriteLine("エラー");
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
    float SideA, SideB, SideC, Tri_Hight, Height;
    float bottom, side;
    public TriangularPrism(float sideA, float sideB, float sideC, float height)
    {
        this.SideA= sideA;
        this.SideB= sideB;
        this.SideC= sideC;
        this.Height= height;

        float Bottom = (sideA + sideB + sideC) / 2.0f;
        bottom = MathF.Sqrt(Bottom * (Bottom - SideA) * (Bottom - sideB) * (Bottom - sideC));
        side = (sideA + sideB + sideC) * height;
    }

    public TriangularPrism(float sideA, float height, float tri_height)
    {
        this.SideA= sideA;
        this.Tri_Hight= tri_height;
        this.Height= height;
        bottom = this.SideA * Tri_Hight / 2.0f;
        side = (float)(sideA + tri_height + Math.Sqrt(sideA * sideA + tri_height * tri_height)) * height;
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
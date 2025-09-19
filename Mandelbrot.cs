using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Mandelbrot";
int ScreenWidth = 300;
int ScreenHeight = 300;
scherm.ClientSize = new Size(ScreenWidth, ScreenHeight);
Bitmap Mandelbrot = new Bitmap(ScreenWidth, ScreenHeight);
Label lab = new Label();
scherm.Controls.Add(lab);
lab.Size = new Size(ScreenWidth, ScreenHeight);
Graphics g = Graphics.FromImage(Mandelbrot);
lab.Image = Mandelbrot;

double scale = 100;
int FMax = 100;

int CalculateMandelgetal(double x, double y, double a, double b)
{
    int counter = 0;
    double distance = 0;
    while (counter <= FMax)
    {
        counter++;
        distance = Math.Sqrt((a * a) + (b * b));
        if (distance >= 2)
        {
            return counter;
        }
        double MandelA = a * a - b * b + x;
        double MandelB = 2 * a * b + y;
        a = MandelA;
        b = MandelB;
    }
    return 1;
}

void CreateBitmap()
{
    for (int i = 0; i < ScreenHeight; i++)
    {
        for (int j = 0; j < ScreenWidth; j++)
        {
            double Mandelgetal = CalculateMandelgetal((i/scale) - (ScreenWidth/2/scale), (j/scale) - (ScreenHeight/2/scale), (i / scale) - (ScreenWidth / 2 / scale), (j / scale) - (ScreenHeight / 2 / scale));
            if (Mandelgetal % 2 == 0)
            {
                Mandelbrot.SetPixel(i, j, Color.Black);
            }
            else if (Mandelgetal % 2 == 1)
            {
                Mandelbrot.SetPixel(i, j, Color.White);
            }
        }
    }
}

CreateBitmap();

Application.Run(scherm);
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Mandelbrot";
int ScreenWidth = 400;
int ScreenHeight = 400;
scherm.ClientSize = new Size(ScreenWidth, ScreenHeight);

Label lab = new Label();
scherm.Controls.Add(lab);
lab.Size = new Size(ScreenWidth, ScreenHeight);

double CenterX = 0;
double CenterY = 0;
double scale = 100;
int FMax = 1000;

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
    return 0;
}

void CreateBitmap()
{
    Bitmap Mandelbrot = new Bitmap(ScreenWidth, ScreenHeight);
    for (int i = 0; i < ScreenHeight; i++)
    {
        for (int j = 0; j < ScreenWidth; j++)
        {
            double Mandelgetal = CalculateMandelgetal((i/scale) - (ScreenWidth/2/scale) + CenterX, (j/scale) - (ScreenHeight/2/scale) + CenterY, (i / scale) - (ScreenWidth / 2 / scale) + CenterX, (j / scale) - (ScreenHeight / 2 / scale) + CenterY);
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
    lab.Image = Mandelbrot;
}

void Zoom(object o, MouseEventArgs e)
{
    Debug.WriteLine("CLick");
    int MouseX = e.X;
    int MouseY = e.Y;
    CenterX += (MouseX - ScreenWidth / 2) / scale;
    CenterY += (MouseY - ScreenHeight / 2) / scale;
    if (e.Button == MouseButtons.Left)
    {
        scale = scale * 2;
    }
    else if (e.Button == MouseButtons.Right)
    {
        scale = scale / 2;  
    }
    CreateBitmap();
}

CreateBitmap();
lab.MouseClick += Zoom;

Application.Run(scherm);
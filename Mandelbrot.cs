using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

Form scherm = new Form();
scherm.Text = "Huizen";
scherm.ClientSize = new Size(300, 300);
Bitmap plaatje = new Bitmap(300, 300);
Label lab = new Label();
scherm.Controls.Add(lab);
lab.Size = new Size(300, 300);
Graphics g = Graphics.FromImage(plaatje);
lab.Image = plaatje;

void Calculate(int x, int y)
{
    int xc = x;
    int yc = y;

    double hoek = Math.Atan(xc / yc);

    int xo = (int)(50 * Math.Sin(hoek)) + 45;
    int yo = (int)(50 * Math.Cos(hoek)) + 45;

    Debug.WriteLine(Math.Sin(hoek));

    Draw(xo, yo);
}
void Draw(int x, int y)
{
    g.DrawEllipse(new Pen(Color.Black, 2), 0, 0, 100, 100);
    g.DrawEllipse(new Pen(Color.Black, 2), 100, 0, 100, 100);
    g.FillEllipse(Brushes.Black, x, y, 10, 10);
    g.FillEllipse(Brushes.Black, 150 - 5, 50 - 5, 10, 10);
}
void beweeg_muis(object o, MouseEventArgs me)
{
    g.Clear(Color.White);
    Calculate(me.X, me.Y);
    lab.Invalidate();
}

lab.MouseMove += beweeg_muis;

Application.Run(scherm);
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Mandelbrot";
scherm.ClientSize = new Size(300, 300);
Bitmap plaatje = new Bitmap(300, 300);
Label lab = new Label();
scherm.Controls.Add(lab);
lab.Size = new Size(300, 300);
Graphics g = Graphics.FromImage(plaatje);
lab.Image = plaatje;

Application.Run(scherm);
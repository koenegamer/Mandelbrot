using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Reversi";
scherm.BackColor = Color.White;
int ScreenWidth = 500;
int ScreenHeight = 600;
scherm.ClientSize = new Size(ScreenWidth, ScreenHeight);

int ReversiWidth = 400;
int ReversiHeight = 400;
Label lab = new Label();
scherm.Controls.Add(lab);
lab.Size = new Size(ReversiWidth, ReversiHeight);
Point point = new Point(50, ScreenHeight - ReversiHeight - 50);
lab.Location = point;

int AantalVakjes = 6;
List<List<Steen>> Stenen = new List<List<Steen>>();
string Turn = "Rood";

void InitiateStenen()
{
    for (int i = 0; i < AantalVakjes; i++)
    {
        List<Steen> Lists = new List<Steen>(AantalVakjes);
        for (int j = 0; j < AantalVakjes; j++)
        {
            Lists.Add(new Steen(i, j, ""));
        }
        Stenen.Add(Lists);
    }
    SetSteen(2, 2, "Rood");
    SetSteen(3, 2, "Blauw");
    SetSteen(2, 3, "Blauw");
    SetSteen(3, 3, "Rood");
}

void SetSteen(int x, int y, string kleur)
{
    foreach (List<Steen> list in Stenen)
    {
        foreach (Steen steen in list)
        {
            if (steen.x == x && steen.y == y)
            {
                steen.Kleur = kleur;
            }
        }
    }
}

void Check(int x, int y)
{
    foreach (List<Steen> list in Stenen)
    {
        foreach (Steen steen in list)
        {
            if (steen.Kleur == Turn)
            {
                int dx;
                int dy;
                if (x > steen.x)
                {
                    dx = x - steen.x;
                }
                else
                {
                    dx = steen.x - x;
                }
                if (y > steen.y)
                {
                    dy = y - steen.y;
                }
                else
                {
                    dy = steen.y - y;   
                }
                if (dx == 1 && dy == 1 || dx == -1 && dy == 1 || dx == 1 && dy == -1 || dx == -1 && dy == -1 || dx == 1 || dy == 1 || dx == -1 || dy == -1)
                {
                    continue;
                }
            }
        }
    }
}

void Draw(Object o, PaintEventArgs pea)
{
    Graphics g = pea.Graphics;

    for (int i = 0; i <= AantalVakjes; i++)
    {
        g.DrawLine(Pens.Black, 0, (ReversiHeight * i) / AantalVakjes, ReversiWidth, (ReversiHeight * i) / AantalVakjes);
    }
    for (int i = 0; i <= AantalVakjes; i++)
    {
        g.DrawLine(Pens.Black, (ReversiWidth * i) / AantalVakjes, 0, (ReversiWidth * i) / AantalVakjes, ReversiHeight);
    }
    foreach (List<Steen> list in Stenen)
    {
        foreach (Steen steen in list)
        {
            Color kleur;
            if (steen.Kleur == "Rood")
            {
                kleur = Color.Red;
            }
            else if (steen.Kleur == "Blauw")
            {
                kleur = Color.Blue;
            }
            else
            {
                kleur = Color.White;
            }
            Brush brush = new SolidBrush(kleur);
            g.FillEllipse(brush, (steen.x * ReversiWidth) / AantalVakjes, (steen.y * ReversiHeight) / AantalVakjes, ReversiWidth / AantalVakjes, ReversiHeight / AantalVakjes);
        }
    }
}

void Click(Object o, MouseEventArgs mea)
{
    SetSteen((mea.X * AantalVakjes) / ReversiWidth, (mea.Y * AantalVakjes) / ReversiHeight, Turn);
    if (Turn == "Rood")
    {
        Turn = "Blauw";
    }
    else
    {
        Turn = "Rood";
    }
    lab.Invalidate();
}

lab.Paint += Draw;
lab.MouseClick += Click;

InitiateStenen();

Application.Run(scherm);

class Steen
{
    public string Kleur;
    public int x;
    public int y;
    public Steen (int x, int y, string kleur)
    {
        this.x = x;
        this.y = y; 
        this.Kleur = kleur;
    }
}

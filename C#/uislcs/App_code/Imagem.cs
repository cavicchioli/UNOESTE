using System;
using System.Drawing;

/// <summary>
/// desenha codigo de barras
/// </summary>
public partial class Barras
{
    string[] codigos = new string[100];
    Brush branco = new SolidBrush(Color.White);
    Brush preto = new SolidBrush(Color.Black);

    public Barras()
    {
        codigos[0] = "00110";
        codigos[1] = "10001";
        codigos[2] = "01001";
        codigos[3] = "11000";
        codigos[4] = "00101";
        codigos[5] = "10100";
        codigos[6] = "01100";
        codigos[7] = "00011";
        codigos[8] = "10010";
        codigos[9] = "01010";

        string texto = "";

        for (int f1 = 9; f1 >= 0; --f1)
        {
            for (int f2 = 9; f2 >= 0; --f2)
            {

                int f = (f1 * 10) + f2;

                for (int i = 0; i < 5; i++)
                {
                    texto += codigos[f1].Substring(i, 1) + codigos[f2].Substring(i, 1);
                }
                codigos[f] = texto;
                texto = "";
            }
        }
    }
    public static Bitmap getBarras(string s)
    {
        Barras b = new Barras();
        return b.getBitmap(s);
    }
    public Bitmap getBitmap(string s)
    {
        Bitmap bmp = new Bitmap(405, 1);
        Graphics g = Graphics.FromImage(bmp);
        //g.Clear(Color.Red);
        Rectangle rect = new Rectangle(0, 0, 1, 1); //0,0,1,50
        Brush cor = branco;

        if (s.Length % 2 != 0)
        {
            s = "0" + s;
        }

        // composição do código de barras pf,bf,pf,bf + barras + pg bf pf
        char[] inicio = { '0', '0', '0', '0' };
        FillBarras(g, ref rect, ref cor, inicio);

        for (int ss = 0; ss < s.Length; ss += 2)
        {
            int id = Convert.ToInt32(s.Substring(ss, 2));
            char[] codigo = codigos[id].ToCharArray();
            FillBarras(g, ref rect, ref cor, codigo);
        }

        char[] fim = { '1', '0', '0' };
        FillBarras(g, ref rect, ref cor, fim);

        return bmp;
    }
    void FillBarras(Graphics g, ref Rectangle r, ref Brush cor, char[] codigo)
    {
        foreach (char c in codigo)
        {
            if (c == '0') { r.Width = 1; } //4
            else { r.Width = 3; } //12
            if (cor == branco) { cor = preto; }
            else { cor = branco; }
            g.FillRectangle(cor, r); // adiciona ao grafico
            r.X += r.Width;
        }
    }
}
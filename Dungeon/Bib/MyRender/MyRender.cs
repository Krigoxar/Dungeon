using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Resources;

namespace Dungeon
{
    public struct ColorRGB

    {

        public byte R;

        public byte G;

        public byte B;

        public ColorRGB(Color value)

        {

            this.R = value.R;

            this.G = value.G;

            this.B = value.B;

        }

        public static implicit operator Color(ColorRGB rgb)

        {

            Color c = Color.FromArgb(rgb.R, rgb.G, rgb.B);

            return c;

        }

        public static explicit operator ColorRGB(Color c)

        {

            return new ColorRGB(c);

        }

    }
    class MyRender
    {
        public static ColorRGB HSL2RGB(double h, double sl, double l)

        {

            double v;

            double r, g, b;



            r = l;   // default to gray

            g = l;

            b = l;

            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)

            {

                double m;

                double sv;

                int sextant;

                double fract, vsf, mid1, mid2;



                m = l + l - v;

                sv = (v - m) / v;

                h *= 6.0;

                sextant = (int)h;

                fract = h - sextant;

                vsf = v * sv * fract;

                mid1 = m + vsf;

                mid2 = v - vsf;

                switch (sextant)

                {

                    case 0:

                        r = v;

                        g = mid1;

                        b = m;

                        break;

                    case 1:

                        r = mid2;

                        g = v;

                        b = m;

                        break;

                    case 2:

                        r = m;

                        g = v;

                        b = mid1;

                        break;

                    case 3:

                        r = m;

                        g = mid2;

                        b = v;

                        break;

                    case 4:

                        r = mid1;

                        g = m;

                        b = v;

                        break;

                    case 5:

                        r = v;

                        g = m;

                        b = mid2;

                        break;

                }

            }

            ColorRGB rgb;

            rgb.R = Convert.ToByte(r * 255.0f);

            rgb.G = Convert.ToByte(g * 255.0f);

            rgb.B = Convert.ToByte(b * 255.0f);

            return rgb;

        }
        Form1 form;
        Bitmap frame;
        string[] feeld;
        public MyRender(Form1 form)
        {
            this.form = form;
            frame = Make_void_frame();
        }
        double i = 0;
        public Bitmap Make_A_Facking_Rainbow()
        {
            i += 0.06;
            if (i > 1)
            {
                i = 0;
            }
            ColorRGB c = HSL2RGB(i, 0.5, 0.5);
            int width = form.Width;
            int hight = form.Height;
            Bitmap void_frame = new Bitmap(width, hight);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < hight; y++)
                {
                    void_frame.SetPixel(x, y, c);
                }
            }
            return void_frame;
        }
        public Bitmap Make_void_frame()
        {
            int width = form.Width;
            int hight = form.Height;
            Bitmap void_frame = new Bitmap(width, hight);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < hight; y++)
                {
                    void_frame.SetPixel(x, y, Color.Black);
                }
            }
            return void_frame;
        }
        int State_Of_Render = 0;
        public void Set_State_Of_Render(int State_Of_Render)
        {
            this.State_Of_Render = State_Of_Render;
        }
        int count = 0;
        public void Get_data_for_printing(string[] feeld)
        {
            count++;
            if (!feeld.Equals(this.feeld) && count > 2)
            {

            }
            this.feeld = feeld;
        }
        public void Render()
        {

            switch (State_Of_Render)
            {
                case -1:
                    {
                        frame = Make_A_Facking_Rainbow();
                        form.Is_all_good = false;
                        break;
                    }
                case 0:
                    {
                        frame = Render_Labirint();
                        break;
                    }
                case 1:
                    {

                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
            }
        }
        public Bitmap Render_Labirint()
        {

            int Width = form.Width;
            int Hight = form.Height;
            int one_cord_size;
            if (Width > Hight)
            {
                int x = (Hight % 41);
                int y = (Hight - x - 20);
                one_cord_size = ((y / 41));
            }
            else
            {
                int x = (Width % 41);
                int y = (Width - x - 20);
                one_cord_size = ((y / 41));
            }
            ResourceManager resources = new ResourceManager("Dungeon.Properties.Resources", typeof(MyRender).Assembly);
            AppDomain domain = AppDomain.CurrentDomain;
            Bitmap Texture_of_Gor_proxod = Resize((Bitmap)(resources.GetObject("Gor_proxod")), one_cord_size);
            Bitmap Texture_of_Wert_proxod = Resize((Bitmap)(resources.GetObject("Wert_proxod")), one_cord_size);
            Bitmap Texture_of_D_L_corn = Resize((Bitmap)(resources.GetObject("D_L_corn")), one_cord_size);
            Bitmap Texture_of_D_R_corn = Resize((Bitmap)(resources.GetObject("D_R_corn")), one_cord_size);
            Bitmap Texture_of_U_L_corn = Resize((Bitmap)(resources.GetObject("U_L_corn")), one_cord_size);
            Bitmap Texture_of_U_R_corn = Resize((Bitmap)(resources.GetObject("U_R_corn")), one_cord_size);
            Bitmap Texture_of_D_T = Resize((Bitmap)(resources.GetObject("D_T")), one_cord_size);
            Bitmap Texture_of_R_T = Resize((Bitmap)(resources.GetObject("R_T")), one_cord_size);
            Bitmap Texture_of_U_T = Resize((Bitmap)(resources.GetObject("U_T")), one_cord_size);
            Bitmap Texture_of_L_T = Resize((Bitmap)(resources.GetObject("L_T")), one_cord_size);
            Bitmap Texture_of_D_tupic = Resize((Bitmap)(resources.GetObject("D_tupic")), one_cord_size);
            Bitmap Texture_of_R_tupic = Resize((Bitmap)(resources.GetObject("R_tupic")), one_cord_size);
            Bitmap Texture_of_U_tupic = Resize((Bitmap)(resources.GetObject("U_tupic")), one_cord_size);
            Bitmap Texture_of_L_tupic = Resize((Bitmap)(resources.GetObject("L_tupic")), one_cord_size);
            Bitmap Texture_of_Wall = Resize((Bitmap)(resources.GetObject("Wall")), one_cord_size);
            Bitmap Texture_of_Wixod_est = Resize((Bitmap)(resources.GetObject("Wixod_est")), one_cord_size);
            Bitmap Texture_of_Win = Resize((Bitmap)(resources.GetObject("Win")), one_cord_size);
            Bitmap Texture_of_Hero = Resize((Bitmap)(resources.GetObject("Hero")), one_cord_size);

            string[] feeld_for_render = feeld;
            Bitmap Labirint_Frame = Make_void_frame();
            int Y = -1;
            foreach (string String in feeld)
            {
                Y++;
                char[] Char_Arr = String.ToCharArray();
                for (int i = 0; i < 41; i++)
                {
                    bool stena_W = false;
                    bool stena_X = false;
                    bool stena_A = false;
                    bool stena_D = false;
                    bool stena_Q = false;
                    bool stena_E = false;
                    bool stena_C = false;
                    bool stena_Z = false;
                    bool stena_S = false;
                    bool pusto_S = false;
                    bool pusto_W = false;
                    if (Y - 1 > -1 && i - 1 > -1 && (feeld[Y - 1][i - 1] == '#' || feeld[Y - 1][i - 1] == '-'))
                    {
                        stena_Q = true;
                    }
                    if (Y - 1 > -1 && i + 1 < 41 && (feeld[Y - 1][i + 1] == '#' || feeld[Y - 1][i + 1] == '-'))
                    {
                        stena_E = true;
                    }
                    if (Y + 1 < 41 && i + 1 < 41 && (feeld[Y + 1][i + 1] == '#' || feeld[Y + 1][i + 1] == '-'))
                    {
                        stena_C = true;
                    }
                    if (Y + 1 < 41 && i - 1 > -1 && (feeld[Y + 1][i - 1] == '#' || feeld[Y + 1][i - 1] == '-'))
                    {
                        stena_Z = true;
                    }
                    if (Y - 1 > -1 && (feeld[Y - 1][i] == '#' || feeld[Y - 1][i] == '-'))
                    {
                        stena_W = true;
                    }
                    if (Y + 1 < 41 && (feeld[Y + 1][i] == '#' || feeld[Y + 1][i] == '-'))
                    {
                        stena_X = true;
                    }
                    if (i - 1 > -1 && (feeld[Y][i - 1] == '#' || feeld[Y][i - 1] == '|'))
                    {
                        stena_A = true;
                    }
                    if (i + 1 < 41 && (feeld[Y][i + 1] == '#' || feeld[Y][i + 1] == '|'))
                    {
                        stena_D = true;
                    }
                    if (feeld[Y][i] == '_' || feeld[Y][i] == 'P')
                    {
                        pusto_S = true;
                    }
                    if (feeld[Y][i] == '-' || feeld[Y][i] == '#')
                    {
                        stena_S = true;
                    }
                    if (Y - 1 > -1 && (feeld[Y - 1][i] == '_' || feeld[Y - 1][i] == 'P' || feeld[Y - 1][i] == 'W'))
                    {
                        pusto_W = true;
                    }

                    /*
                     

                    if (Char_Arr[i] == '#')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Labirint_Frame.SetPixel(X_cord, Y_cord, Color.Brown);
                            }
                        }
                    }
                    else if (Char_Arr[i] == '-')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Labirint_Frame.SetPixel(X_cord, Y_cord, Color.Brown);
                            }
                        }
                    }
                    else if (Char_Arr[i] == ' ')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Labirint_Frame.SetPixel(X_cord, Y_cord, Color.Green);
                            }
                        }
                    }
                    else if (Char_Arr[i] == ' ' && i % 2 == 1)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Labirint_Frame.SetPixel(X_cord, Y_cord, Color.Green);
                            }
                        }
                    }
                    else if (Char_Arr[i] == '|')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Labirint_Frame.SetPixel(X_cord, Y_cord, Color.Brown);
                            }
                        }
                    }
                    else if (Char_Arr[i] == '_')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Labirint_Frame.SetPixel(X_cord, Y_cord, Color.Green);
                            }
                        }
                    }

                     */
                    /*
                     
                     */

                    if (stena_X && stena_W && !stena_A && !stena_D && pusto_S)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_Gor_proxod.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }

                    if (!stena_X && !stena_W && stena_A && stena_D && pusto_S)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_Wert_proxod.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }


                    if (!stena_X && !stena_W && !stena_A && !stena_D && pusto_S)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_Wixod_est.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }

                    if (!stena_X && stena_W && !stena_A && stena_D && pusto_S && stena_Z)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_D_L_corn.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (!stena_X && stena_W && stena_A && !stena_D && pusto_S && stena_C)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_D_R_corn.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (stena_X && !stena_W && !stena_A && stena_D && pusto_S && stena_Q)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_U_L_corn.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }

                    if (stena_X && !stena_W && stena_A && !stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_U_R_corn.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }


                    if (!stena_X && stena_W && !stena_A && !stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_D_T.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (stena_X && !stena_W && !stena_A && !stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_U_T.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (!stena_X && !stena_W && !stena_A && stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_L_T.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (!stena_X && !stena_W && stena_A && !stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_R_T.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }



                    if (!stena_X && stena_W && stena_A && stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_D_tupic.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (stena_X && !stena_W && stena_A && stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_U_tupic.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (stena_X && stena_W && !stena_A && stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_L_tupic.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (stena_X && stena_W && stena_A && !stena_D && pusto_S && stena_E)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_R_tupic.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    if (pusto_W && stena_S)
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_Wall.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    else if (Char_Arr[i] == 'W')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_Win.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                            }
                        }
                    }
                    else if (Char_Arr[i] == 'P')
                    {
                        for (int Y_cord = Y * one_cord_size; Y_cord < Y * one_cord_size + one_cord_size; Y_cord++)
                        {
                            for (int X_cord = i * one_cord_size; X_cord < i * one_cord_size + one_cord_size; X_cord++)
                            {
                                Color color = Texture_of_Hero.GetPixel(X_cord % one_cord_size, Y_cord % one_cord_size);
                                if (color.R < 200 && color.G < 200 && color.B < 200)
                                {
                                    Labirint_Frame.SetPixel(X_cord, Y_cord, color);
                                }
                            }
                        }
                    }

                }
            }
            return Labirint_Frame;
        }
        Bitmap Resize(Bitmap resized, float One_cord_size)
        {
            Bitmap output = new Bitmap((int)One_cord_size, (int)One_cord_size);
            for (int Y = 0; Y < One_cord_size; Y++)
            {
                for (int X = 0; X < One_cord_size; X++)
                {
                    Color color = resized.GetPixel((int)(X * (24.0 / One_cord_size)), (int)(Y * (24.0 / One_cord_size)));
                    output.SetPixel(X, Y, color);
                }
            }
            return output;
        }
        public Bitmap Get_Frame()
        {
            return frame;
        }
    }
}

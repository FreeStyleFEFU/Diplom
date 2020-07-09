using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using asprise_ocr_api;


namespace Diplom_final
{
    public partial class Form1 : Form
    {
        string newway;
        public static List<List<int>> set = new List<List<int>>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var way = string.Empty;
            

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    way = openFileDialog.FileName;

                    string inputPdf = @way;
                    label1.Text = "Файл открыт: " + way.ToString();
                    char[] MyChar = { 'p', 'd', 'f' };
                    newway = way.TrimEnd(MyChar);

                    string outputPng = @newway + "bmp";

                    using (MagickImageCollection images = new MagickImageCollection())
                    {
                        images.Read(inputPdf);
                        using (IMagickImage vertical = images.AppendVertically())
                        {
                            vertical.Format = MagickFormat.Bmp;
                            vertical.Density = new Density(600);
                            vertical.Write(outputPng);
                        }
                    }

                    
                }
            }
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(textBox1.Text);
            for (int i = 0; i < a; i++)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var bmp1 = new Bitmap(newway + "bmp");

            //var bmp1 = new Bitmap(@"C:\Users\Михаил\OneDrive\диплом\Безымянный1.jpg");
            //bmp1.SetPixel(130, 150, Color.FromArgb(255, 0, 0));




            this.pictureBox1.Width = bmp1.Width;
            this.pictureBox1.Height = bmp1.Height;
            this.pictureBox1.Image = bmp1;

            
           
            //List<List<int>> po = new List<List<int>>();
            //po.Add(new List<int> { 130, 120, 230, 410 });
            //po.Add(new List<int> { 120, 130, 200, 380 });
            //po.Add(new List<int> { 100, 130, 220, 400 });
            //po.Add(new List<int> { 140, 100, 290, 510 });

            //List<List<Point>> res = new List<List<Point>>();

            //for (int m = 0; m < set.Count; m++)//по дальности обзора
            //{
            //    int r1 = set[m][2] * 38* 100 * 1  / 200 ;
            //    for (int j = 0; j < po.Count; j++)//по точкам для камер
            //    { 
            //        int x1 = po[j][0];
            //        int y1 = po[j][1];
            //        Point start = new Point(x1, y1);     
            //        for (int i = po[j][2]; i <= po[j][3] - set[m][1]; i = i + 10)// по расширенным углам обзора точек
            //        {
            //            List<Point> ress = new List<Point>();
            //            ress.Add(start);
            //            for (int n = i; n < i + set[m][1]; n++)//по углам обзора камеры// c ними происходит какой-то бред
            //            {
            //                Point finish = start;
            //                for (int r2 = 0; r2 < r1; r2++)//отмечаем точки для полигонов угла обзора
            //                {
            //                    double xx = x1 + (r2 * Math.Cos(n * Math.PI / 180));
            //                    double yy = y1 + (r2 * Math.Sin(n * Math.PI / 180));

            //                    int x = Convert.ToInt32(xx);
            //                    int y = Convert.ToInt32(yy);
            //                    Color ccolor = bmp1.GetPixel(x, y);
            //                    if (ccolor == Color.FromArgb(0, 0, 0))
            //                    {
            //                        break;
            //                    }
            //                    finish = new Point(x, y);
            //                }
            //                ress.Add(finish);
            //            }
            //            res.Add(ress);
            //        }
            //    }
            //}


            
            //SolidBrush GreenBrush = new SolidBrush(Color.FromArgb(0, 128, 0));
            //Graphics o = Graphics.FromImage(pictureBox1.Image);
            //List<int> id = new List<int>();

            //Point[] points = new Point[res[12].Count];
            //for (int l = 0; l < res[12].Count; l++)
            //{
            //    points[l] = res[12][l];
            //}
            //o.FillPolygon(GreenBrush, points);
            //pictureBox1.Invalidate();

            //for (int i = 0; i < set.Count; i++)//количество разновидностей камер
            //{
            //    for (int j = 0; j < set[i][0]; j++)//количество камер данной разновидности
            //    {
            //        List<int> s = new List<int>();
            //        for (int k = 0; k < res.Count; k++)//все возможные области видимости
            //        {
            //            Point[] points = new Point[res[k].Count];
            //            for (int l = 0; l < res[k].Count; l++)
            //            {
            //                points[l] = res[k][l];
            //            }
            //            o.FillPolygon(GreenBrush, points);
            //            pictureBox1.Invalidate();
            //            int count5 = 0;
            //            for (int l = 0; l < bmp1.Width; l++)//не забудь заменить на другой бмп
            //            {
            //                for (int m = 0; m < bmp1.Height; m++)
            //                {
            //                    Color ccolor = bmp1.GetPixel(l, m);
            //                    if (ccolor == Color.FromArgb(0, 128, 0))
            //                    {
            //                        count5++;
            //                        bmp1.SetPixel(l, m, Color.FromArgb(255, 255, 255));
            //                    }
            //                }
            //            }
            //            s.Add(count5); //нужно куда-то в цикле пихнуть обновление списка S. Также нужен список для выбранных полигонов
            //            for (int m = 0; m < id.Count; m++)
            //            {
            //                Point[] points1 = new Point[res[id[m]].Count];
            //                for (int l = 0; l < res[id[m]].Count; l++)
            //                {
            //                    points1[l] = res[id[m]][l];
            //                }
            //                o.FillPolygon(GreenBrush, points1);
            //                pictureBox1.Invalidate();
            //            }
            //        }
            //        int max = s.LastIndexOf(s.Max());
            //        id.Add(max);
            //        for (int lol = 0; lol < s.Count; lol++)
            //        {
            //            Console.WriteLine(s[lol]);
            //        }
            //        Console.WriteLine(23456789087659);

            //        for (int m = 0; m < id.Count; m++)
            //        {
            //            Point[] points1 = new Point[res[id[m]].Count];
            //            for (int l = 0; l < res[id[m]].Count; l++)
            //            {
            //                points1[l] = res[id[m]][l];
            //            }
            //            o.FillPolygon(GreenBrush, points1);
            //            pictureBox1.Invalidate();
            //        }
            //        //здесь должен быть цикл, который перебирает список s, выбирает самое большое число и по его индексу строит полигон
            //        //также должен быть цикл, который строит уже выбранные полигоны
            //    }
            //}

            //for (int i = 0; i < res.Count; i++)
            //{
            //    Point[] points = new Point[res[i].Count];
            //    for (int j = 0; j < res[i].Count; j++)
            //    {
            //        points[j] = res[i][j];
            //    }
            //    o.FillPolygon(GreenBrush, points);
            //    pictureBox1.Invalidate();
            //}

            //set.Add(new List<int> { uniq[i].X, uniq[i].Y, 90, 360 });
            //bmp1.SetPixel(100, 100, Color.FromArgb(255, 0, 0));


            //Graphics g = Graphics.FromImage(pictureBox1.Image);
            //bmp1.SetPixel(100, 100, Color.FromArgb(255, 0, 0));
            //g.DrawLine(new Pen(Brushes.Black, 1), new Point(100, 100), new Point(0, 25));
            //bmp1.SetPixel(100, 100, Color.FromArgb(255, 0, 0));
            //pictureBox1.Invalidate();

            //return;

            //-------------------------------------------------------------------------------
            // распознавание
            //AspriseOCR.SetUp();
            //AspriseOCR ocr = new AspriseOCR();
            //ocr.StartEngine("eng", AspriseOCR.SPEED_FASTEST);

            //string s = ocr.Recognize(newway + "bmp", -1, -1, -1, -1, -1,
            // AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);
            //Console.WriteLine(s);

            //ocr.StopEngine();

            //------------------------------------------------------------------
            //вычленяем циферки
            string left = "1";
            string right = "200";

            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (s[i] == ':')
            //    {
            //        for (int j = i - 1; j > 0; j--)
            //        {
            //            if (s[j] != ' ')
            //            {
            //                left += s[j];
            //            }
            //            if (s[j] == ' ')
            //            {
            //                break;
            //            }
            //        }
            //        for (int j = i + 1; j < s.Length; j++)
            //        {
            //            if (s[j] != ' ')
            //            {
            //                right += s[j];
            //            }
            //            if (s[j] == ' ')
            //            {
            //                break;
            //            }
            //        }

            //    }
            //}
            int lleft = Int32.Parse(left);
            int rright = Int32.Parse(right);

            //--------------------------------------------------------------------------------------
            //находим размеры чертежа и загоняем кординаты черных пикселей в список

            int width = bmp1.Width;
            int heigth = bmp1.Height;
            this.pictureBox1.Width = width;
            this.pictureBox1.Height = heigth;

            this.pictureBox1.Image = bmp1;

            List<Point> colors = new List<Point>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    Color color = bmp1.GetPixel(i, j);
                    if (color == Color.FromArgb(0, 0, 0))
                    {
                        Point Point1 = new Point(i, j);
                        colors.Add(Point1);
                    }
                }
            }

            //--------------------------------------------------------------------------------------------
            //Обрезаем верхние 10 процентов рисунка
            //А это вручную. Здесь все норм

            List<Color> im = new List<Color>();
            Bitmap bmp2 = new Bitmap(bmp1, new Size(width, heigth - (heigth / 10)));

            for (int i = heigth - 1; i > (heigth / 10) - 1; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    Color color = bmp1.GetPixel(j, i);
                    im.Add(color);
                }
            }

            int count = 0;
            for (int i = bmp2.Height - 1; i > -1; i--)
            {
                for (int j = 0; j < bmp2.Width; j++)
                {
                    bmp2.SetPixel(j, i, im[count]);
                    count++;
                }
            }

            Bitmap bmp3 = new Bitmap(bmp2);

            //-------------------------------------------------------------------------------------
            //Подкрашиваем в черное, белое, серое

            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    Color colo = bmp2.GetPixel(i, j);
                    for (int k = 0; k < 11; k++)
                    {
                        for (int l = 0; l < 11; l++)
                        {
                            for (int m = 0; m < 11; m++)
                            {
                                if (colo == Color.FromArgb(k, l, m))
                                {
                                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                                }
                            }
                        }
                    }
                    for (int k = 245; k < 255; k++)
                    {
                        for (int l = 245; l < 255; l++)
                        {
                            for (int m = 245; m < 255; m++)
                            {
                                if (colo == Color.FromArgb(k, l, m))
                                {
                                    bmp2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                                }
                            }
                        }
                    }
                    for (int k = 70; k < 207; k++)
                    {
                        if (colo == Color.FromArgb(k, k, k))
                        {
                            bmp2.SetPixel(i, j, Color.FromArgb(196, 196, 196));
                        }
                    }
                }
            }

            Bitmap bmp4 = new Bitmap(bmp2);

            this.pictureBox1.Width = bmp2.Width;
            this.pictureBox1.Height = bmp2.Height;
            this.pictureBox1.Image = bmp2;


            //-------------------------------------------------------------------------------------
            //Делаем голубой фон

            for (int i = 0; i < bmp2.Height; i++)
            {
                for (int j = 0; j < bmp2.Width; j++)
                {
                    Color colo = bmp2.GetPixel(j, i);
                    if (colo != Color.FromArgb(255, 255, 255))
                    {
                        break;
                    }
                    bmp2.SetPixel(j, i, Color.FromArgb(66, 170, 255));
                }
            }

            for (int i = 0; i < bmp2.Height; i++)
            {
                for (int j = bmp2.Width - 1; j > -1; j--)
                {
                    Color colo = bmp2.GetPixel(j, i);
                    if (colo != Color.FromArgb(255, 255, 255))
                    {
                        break;
                    }
                    bmp2.SetPixel(j, i, Color.FromArgb(66, 170, 255));
                }
            }

            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    Color colo = bmp2.GetPixel(i, j);
                    if (colo != Color.FromArgb(255, 255, 255))
                    {
                        if (colo != Color.FromArgb(66, 170, 255))
                        {
                            break;
                        }
                    }
                    bmp2.SetPixel(i, j, Color.FromArgb(66, 170, 255));
                }
            }

            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = bmp2.Height - (bmp2.Height / 10) - 1; j > -1; j--)
                {
                    Color colo = bmp2.GetPixel(i, j);
                    if (colo != Color.FromArgb(255, 255, 255))
                    {
                        if (colo != Color.FromArgb(66, 170, 255))
                        {
                            break;
                        }
                    }
                    bmp2.SetPixel(i, j, Color.FromArgb(66, 170, 255));
                }
            }


            //-------------------------------------------------------------------------------------
            //закрашиваем окна

            int kk = 58 * lleft * 38 / rright;

            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    Color colo = bmp2.GetPixel(i, j);
                    if (colo == Color.FromArgb(196, 196, 196))
                    {
                        Color colo1 = bmp2.GetPixel(i + 1, j);
                        Color colo2 = bmp2.GetPixel(i + 2, j);
                        if (colo1 == Color.FromArgb(255, 255, 255) || colo2 == Color.FromArgb(255, 255, 255))
                        {
                            for (int k = 3; k < kk + 5; k++)
                            {
                                Color colo3 = bmp2.GetPixel(i + k, j);
                                if (colo3 == Color.FromArgb(196, 196, 196) || colo3 == Color.FromArgb(0, 0, 0))
                                {
                                    for (int l = i; l < i + k + 1; l++)
                                    {
                                        bmp2.SetPixel(l, j, Color.FromArgb(0, 0, 0));
                                    }
                                    break;
                                }
                            }
                        }

                        colo1 = bmp2.GetPixel(i - 1, j);
                        colo2 = bmp2.GetPixel(i - 2, j);
                        if (colo1 == Color.FromArgb(255, 255, 255) || colo2 == Color.FromArgb(255, 255, 255))
                        {
                            for (int k = 3; k < kk + 5; k++)
                            {
                                Color colo3 = bmp2.GetPixel(i - k, j);
                                if (colo3 == Color.FromArgb(196, 196, 196) || colo3 == Color.FromArgb(0, 0, 0))
                                {
                                    for (int l = i - k; l < i + 1; l++)
                                    {
                                        bmp2.SetPixel(l, j, Color.FromArgb(0, 0, 0));
                                    }
                                    break;
                                }
                            }
                        }

                        colo1 = bmp2.GetPixel(i, j + 1);
                        colo2 = bmp2.GetPixel(i, j + 2);
                        if (colo1 == Color.FromArgb(255, 255, 255) || colo2 == Color.FromArgb(255, 255, 255))
                        {
                            for (int k = 3; k < kk + 5; k++)
                            {
                                Color colo3 = bmp2.GetPixel(i, j + k);
                                if (colo3 == Color.FromArgb(196, 196, 196) || colo3 == Color.FromArgb(0, 0, 0))
                                {
                                    for (int l = j; l < j + k + 1; l++)
                                    {
                                        bmp2.SetPixel(i, l, Color.FromArgb(0, 0, 0));
                                    }
                                    break;
                                }
                            }
                        }

                        colo1 = bmp2.GetPixel(i, j - 1);
                        colo2 = bmp2.GetPixel(i, j - 2);
                        if (colo1 == Color.FromArgb(255, 255, 255) || colo2 == Color.FromArgb(255, 255, 255))
                        {
                            for (int k = 3; k < kk + 5; k++)
                            {
                                Color colo3 = bmp2.GetPixel(i, j - k);
                                if (colo3 == Color.FromArgb(196, 196, 196) || colo3 == Color.FromArgb(0, 0, 0))
                                {
                                    for (int l = j - k; l < j + 1; l++)
                                    {
                                        bmp2.SetPixel(i, l, Color.FromArgb(0, 0, 0));
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    Color colo = bmp2.GetPixel(i, j);
                    if (colo == Color.FromArgb(0, 0, 0))
                    {
                        Color colo1 = bmp2.GetPixel(i + 1, j);
                        if (colo1 == Color.FromArgb(255, 255, 255))
                        {
                            Color colo2 = bmp2.GetPixel(i + 2, j);
                            if (colo2 != Color.FromArgb(255, 255, 255))
                            {
                                bmp2.SetPixel(i + 1, j, Color.FromArgb(0, 0, 0));
                            }
                        }
                        colo1 = bmp2.GetPixel(i - 1, j);
                        if (colo1 == Color.FromArgb(255, 255, 255))
                        {
                            Color colo2 = bmp2.GetPixel(i - 2, j);
                            if (colo2 != Color.FromArgb(255, 255, 255))
                            {
                                bmp2.SetPixel(i - 1, j, Color.FromArgb(0, 0, 0));
                            }
                        }
                        colo1 = bmp2.GetPixel(i, j + 1);
                        if (colo1 == Color.FromArgb(255, 255, 255))
                        {
                            Color colo2 = bmp2.GetPixel(i, j + 2);
                            if (colo2 != Color.FromArgb(255, 255, 255))
                            {
                                bmp2.SetPixel(i, j + 1, Color.FromArgb(0, 0, 0));
                            }

                        }
                        colo1 = bmp2.GetPixel(i, j - 1);
                        if (colo1 == Color.FromArgb(255, 255, 255))
                        {
                            Color colo2 = bmp2.GetPixel(i, j - 2);
                            if (colo2 != Color.FromArgb(255, 255, 255))
                            {
                                bmp2.SetPixel(i, j - 1, Color.FromArgb(0, 0, 0));
                            }

                        }
                    }
                }
            }


            this.pictureBox1.Width = bmp2.Width;
            this.pictureBox1.Height = bmp2.Height;
            this.pictureBox1.Image = bmp2;

            //-------------------------------------------------------------------------------------
            //Ищем стенки
            //bmp2 = new Bitmap(@"C:\Users\Мижга\Desktop\Page1.jpg", true);
            //Console.WriteLine(bmp2.Width + "+++++" + bmp2.Height);

            List<Point> wall = new List<Point>();


            for (int i = 0; i < bmp2.Height; i++)
            {
                for (int j = 0; j < bmp2.Width; j++)
                {
                    Color color = bmp2.GetPixel(j, i);
                    if (color == Color.FromArgb(0, 0, 0))
                    {
                        Color color1 = bmp2.GetPixel(j + 1, i);
                        Color color2 = bmp2.GetPixel(j + 2, i);
                        if (color1 == Color.FromArgb(255, 255, 255) || color2 == Color.FromArgb(255, 255, 255))
                        {
                            Color color3 = bmp2.GetPixel(j + 3, i);
                            if (color3 == Color.FromArgb(255, 255, 255))
                            {
                                Point w = new Point(j + 1, i);
                                wall.Add(w);
                                Color color5 = bmp2.GetPixel(j + 2, i + 1);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j + 1, i + 1);
                                    wall.Add(ww);
                                }
                                color5 = bmp2.GetPixel(j + 2, i - 1);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j + 1, i - 1);
                                    wall.Add(ww);
                                }

                            }
                        }

                        color1 = bmp2.GetPixel(j - 1, i);
                        color2 = bmp2.GetPixel(j - 2, i);
                        if (color1 == Color.FromArgb(255, 255, 255) || color2 == Color.FromArgb(255, 255, 255))
                        {
                            Color color3 = bmp2.GetPixel(j - 3, i);
                            if (color3 == Color.FromArgb(255, 255, 255))
                            {
                                Point w = new Point(j - 1, i);
                                wall.Add(w);
                                Color color5 = bmp2.GetPixel(j - 2, i + 1);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j - 1, i + 1);
                                    wall.Add(ww);
                                }
                                color5 = bmp2.GetPixel(j - 2, i - 1);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j - 1, i - 1);
                                    wall.Add(ww);
                                }
                            }
                        }

                        color1 = bmp2.GetPixel(j, i + 1);
                        color2 = bmp2.GetPixel(j, i + 2);
                        if (color1 == Color.FromArgb(255, 255, 255) || color2 == Color.FromArgb(255, 255, 255))
                        {
                            Color color3 = bmp2.GetPixel(j, i + 3);
                            if (color3 == Color.FromArgb(255, 255, 255))
                            {
                                Point w = new Point(j, i + 1);
                                wall.Add(w);
                                Color color5 = bmp2.GetPixel(j - 1, i + 2);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j - 1, i + 1);
                                    wall.Add(ww);
                                }
                                color5 = bmp2.GetPixel(j + 1, i + 2);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j + 1, i + 1);
                                    wall.Add(ww);
                                }
                            }
                        }

                        color1 = bmp2.GetPixel(j, i - 1);
                        color2 = bmp2.GetPixel(j, i - 2);
                        if (color1 == Color.FromArgb(255, 255, 255) || color2 == Color.FromArgb(255, 255, 255))
                        {
                            Color color3 = bmp2.GetPixel(j, i - 3);
                            if (color3 == Color.FromArgb(255, 255, 255))
                            {


                                Point w = new Point(j, i - 1);
                                wall.Add(w);
                                Color color5 = bmp2.GetPixel(j - 1, i - 2);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j - 1, i - 1);
                                    wall.Add(ww);
                                }
                                color5 = bmp2.GetPixel(j + 1, i - 2);
                                if (color5 == Color.FromArgb(255, 255, 255))
                                {
                                    Point ww = new Point(j + 1, i - 1);
                                    wall.Add(ww);
                                }

                            }
                        }
                    }
                }
            }

            List<Point> uniq = wall.Distinct().ToList();//выбрали уникальные координаты
            //for (int i = 0; i < uniq.Count; i++)
            //{
            //    bmp2.SetPixel(uniq[i].X, uniq[i].Y, Color.FromArgb(255, 87, 143));
            //}

            this.pictureBox1.Width = bmp2.Width;
            this.pictureBox1.Height = bmp2.Height;
            this.pictureBox1.Image = bmp2;
            //                                            //Console.WriteLine(uniq[1]);
            //                                            //Console.WriteLine(uniq[1].X);

            //----------------------------------------------------------------------------------------------
            //Составляем список с кординатами 
            List<List<int>> walls = new List<List<int>>();
            List<int> wal = new List<int>();


            for (int i = 0,w,v; i < uniq.Count; i++)
            {
                w = 0;
                
                Color color1 = bmp2.GetPixel(uniq[i].X + 1, uniq[i].Y);
                Color color2 = bmp2.GetPixel(uniq[i].X - 1, uniq[i].Y);
                Color color3 = bmp2.GetPixel(uniq[i].X, uniq[i].Y + 1);
                Color color4 = bmp2.GetPixel(uniq[i].X, uniq[i].Y - 1);
                Color color5 = bmp2.GetPixel(uniq[i].X + 2, uniq[i].Y);
                Color color6 = bmp2.GetPixel(uniq[i].X - 2, uniq[i].Y);
                Color color7 = bmp2.GetPixel(uniq[i].X, uniq[i].Y + 2);
                Color color8 = bmp2.GetPixel(uniq[i].X, uniq[i].Y - 2);
                if (color1 != Color.FromArgb(0, 0, 0) && color2 != Color.FromArgb(0, 0, 0) && color3 != Color.FromArgb(0, 0, 0) && color4 != Color.FromArgb(0, 0, 0)
                    && color5 != Color.FromArgb(0, 0, 0) && color6 != Color.FromArgb(0, 0, 0) && color7 != Color.FromArgb(0, 0, 0) && color8 != Color.FromArgb(0, 0, 0)
                    && color1 != Color.FromArgb(196, 196, 196) && color2 != Color.FromArgb(196, 196, 196) && color3 != Color.FromArgb(196, 196, 196) && color4 != Color.FromArgb(196, 196, 196)
                    && color5 != Color.FromArgb(196, 196, 196) && color6 != Color.FromArgb(196, 196, 196) && color7 != Color.FromArgb(196, 196, 196) && color8 != Color.FromArgb(196, 196, 196))

                {
                    color1 = bmp2.GetPixel(uniq[i].X + 1, uniq[i].Y + 1);
                    color2 = bmp2.GetPixel(uniq[i].X + 2, uniq[i].Y + 2);
                    if (color1 == Color.FromArgb(0, 0, 0) || color2 == Color.FromArgb(0, 0, 0) || color1 == Color.FromArgb(196, 196, 196) || color2 == Color.FromArgb(196, 196, 196))
                    {
                        w = 1;
                        wal.Add(w);
                        //walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 0, 270 });
                        continue;
                    }
                    color1 = bmp2.GetPixel(uniq[i].X - 1, uniq[i].Y - 1);
                    color2 = bmp2.GetPixel(uniq[i].X - 2, uniq[i].Y - 2);
                    if (color1 == Color.FromArgb(0, 0, 0) || color2 == Color.FromArgb(0, 0, 0) || color1 == Color.FromArgb(196, 196, 196) || color2 == Color.FromArgb(196, 196, 196))
                    {
                        w = 5;
                        wal.Add(w);
                        //walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 180, 540 });
                        continue;
                    }
                    color1 = bmp2.GetPixel(uniq[i].X + 1, uniq[i].Y - 1);
                    color2 = bmp2.GetPixel(uniq[i].X + 2, uniq[i].Y - 2);
                    if (color1 == Color.FromArgb(0, 0, 0) || color2 == Color.FromArgb(0, 0, 0) || color1 == Color.FromArgb(196, 196, 196) || color2 == Color.FromArgb(196, 196, 196))
                    {
                        w = 7;
                        wal.Add(w);
                        //walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 180, 540 });
                        continue;
                    }
                    color1 = bmp2.GetPixel(uniq[i].X - 1, uniq[i].Y + 1);
                    color2 = bmp2.GetPixel(uniq[i].X - 2, uniq[i].Y + 2);
                    if (color1 == Color.FromArgb(0, 0, 0) || color2 == Color.FromArgb(0, 0, 0) || color1 == Color.FromArgb(196, 196, 196) || color2 == Color.FromArgb(196, 196, 196))
                    {
                        w = 3;
                        wal.Add(w);
                        //walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 90, 360});
                        continue;
                    }

                }


                color1 = bmp2.GetPixel(uniq[i].X + 1, uniq[i].Y);
                if (color1 == Color.FromArgb(0, 0, 0))
                {
                    w = 8;
                }
                color1 = bmp2.GetPixel(uniq[i].X - 1, uniq[i].Y);
                if (color1 == Color.FromArgb(0, 0, 0))
                {
                    w = 4;
                }
                color1 = bmp2.GetPixel(uniq[i].X, uniq[i].Y + 1);
                if (color1 == Color.FromArgb(0, 0, 0))
                {
                    if (w == 4) w = 12;
                    if (w == 8) w = 11;
                    if (w == 0) w = 2;
                    wal.Add(w);
                    //walls.Add(new List<int> { uniq[i].X, uniq[i].Y, w });
                    continue;
                }
                color1 = bmp2.GetPixel(uniq[i].X, uniq[i].Y - 1);
                if (color1 == Color.FromArgb(0, 0, 0))
                {
                    if (w == 4) w = 10;
                    if (w == 8) w = 9;
                    if (w == 0) w = 6;
                    wal.Add(w);
                    // walls.Add(new List<int> { uniq[i].X, uniq[i].Y, w });
                }
            }
            //------------------------------------------------------------------------------------------
            //Расставляем углы обзора

            for (int i = 0; i < wal.Count; i++)
            {
                if (wal[i] == 1)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 90, 360  });
                    continue;
                }
                if (wal[i] == 2)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 180, 360 });
                    continue;
                }
                if (wal[i] == 3)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 180, 450 });
                    continue;
                }
                if (wal[i] == 4)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 270, 450 });
                    continue;
                }
                if (wal[i] == 5)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 270, 540 });
                    continue;
                }
                if (wal[i] == 6)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 0, 180 });
                    continue;
                }
                if (wal[i] == 7)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 0, 270 });
                    continue;
                }
                if (wal[i] == 8)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 90, 270 });
                    continue;
                }
                if (wal[i] == 9)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 0, 90 });
                    continue;
                }
                if (wal[i] == 10)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 90, 180});
                    continue;
                }
                if (wal[i] == 11)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 180, 270 });
                    continue;
                }
                if (wal[i] == 12)
                {
                    walls.Add(new List<int> { uniq[i].X, uniq[i].Y, 270, 360});
                    continue;
                }
            }
            //for (int i = 0; i < walls.Count; i++)
            //{
            //    for (int j = 0; j < walls[i].Count; j++)
            //    {
            //        Console.WriteLine(walls[i][j]);
            //    }
            //}


            //------------------------------------------------------------------------------------------------


            //for (int i = 0; i < walls.Count; i++)
            //{
            //    for (int j = 0; j < walls[i].Count; j++)
            //    {
            //        Console.WriteLine(walls[i][j]);
            //    }
            //}

            Console.WriteLine("Просчитывание всех возможных углов обзора камер");

            List<List<Point>> res = new List<List<Point>>();

            for (int m = 0; m < set.Count; m++)//по дальности обзора
            {
                int r1 = set[m][2] * 38 * 100 * 1 / 200;
                for (int j = 0; j < walls.Count; j++)//по точкам для камер
                {
                    int x1 = walls[j][0];
                    int y1 = walls[j][1];
                    Point start = new Point(x1, y1);
                    for (int i = walls[j][2]; i <= walls[j][3] - set[m][1]; i = i + 10)// по расширенным углам обзора точек
                    {
                        List<Point> ress = new List<Point>();
                        ress.Add(start);
                        for (int n = i; n < i + set[m][1]; n++)//по углам обзора камеры
                        {
                            Point finish = start;
                            for (int r2 = 0; r2 < r1; r2++)//отмечаем точки для полигонов угла обзора
                            {
                                double xx = x1 + (r2 * Math.Cos(n * Math.PI / 180));
                                double yy = y1 + (r2 * Math.Sin(n * Math.PI / 180));

                                int x = Convert.ToInt32(xx);
                                int y = Convert.ToInt32(yy);
                                Color ccolor = bmp2.GetPixel(x, y);
                                if (ccolor == Color.FromArgb(0, 0, 0))
                                {
                                    break;
                                }
                                finish = new Point(x, y);
                            }
                            ress.Add(finish);
                        }
                        res.Add(ress);
                    }
                }
            }

            Console.WriteLine(walls.Count +"Расстановка" +res.Count);

            this.pictureBox1.Width = bmp4.Width;
            this.pictureBox1.Height = bmp4.Height;
            this.pictureBox1.Image = bmp4;

            SolidBrush GreenBrush = new SolidBrush(Color.FromArgb(0, 128, 0));
            Graphics o = Graphics.FromImage(pictureBox1.Image);
            List<int> id = new List<int>();

            for (int i = 0; i < set.Count; i++)//количество разновидностей камер
            {
                for (int j = 0; j < set[i][0]; j++)//количество камер данной разновидности
                {
                    List<int> s = new List<int>();
                    for (int k = 0; k < res.Count; k++)//все возможные области видимости
                    {
                        Point[] points = new Point[res[k].Count];
                        for (int l = 0; l < res[k].Count; l++)
                        {
                            points[l] = res[k][l];
                        }
                        o.FillPolygon(GreenBrush, points);
                        pictureBox1.Invalidate();
                        int count5 = 0;
                        for (int l = 0; l < bmp4.Width; l++)//не забудь заменить на другой бмп
                        {
                            for (int m = 0; m < bmp4.Height; m++)
                            {
                                Color ccolor = bmp4.GetPixel(l, m);
                                if (ccolor == Color.FromArgb(0, 128, 0))
                                {
                                    count5++;
                                    bmp4.SetPixel(l, m, Color.FromArgb(255, 255, 255));
                                }
                            }
                        }
                        s.Add(count5); //нужно куда-то в цикле пихнуть обновление списка S. Также нужен список для выбранных полигонов
                        Console.WriteLine(s.Count +" "+ id.Count);
                        for (int m = 0; m < id.Count; m++)
                        {
                            Point[] points1 = new Point[res[id[m]].Count];
                            for (int l = 0; l < res[id[m]].Count; l++)
                            {
                                points1[l] = res[id[m]][l];
                            }
                            o.FillPolygon(GreenBrush, points1);
                            pictureBox1.Invalidate();
                        }
                    }
                    int max = s.LastIndexOf(s.Max());
                    id.Add(max);

                    for (int m = 0; m < id.Count; m++)
                    {
                        Point[] points1 = new Point[res[id[m]].Count];
                        for (int l = 0; l < res[id[m]].Count; l++)
                        {
                            points1[l] = res[id[m]][l];
                        }
                        o.FillPolygon(GreenBrush, points1);
                        pictureBox1.Invalidate();
                    }
                    //здесь должен быть цикл, который перебирает список s, выбирает самое большое число и по его индексу строит полигон
                    //также должен быть цикл, который строит уже выбранные полигоны
                }
            }


            this.pictureBox1.Width = bmp3.Width;
            this.pictureBox1.Height = bmp3.Height;
            this.pictureBox1.Image = bmp3;

            o = Graphics.FromImage(pictureBox1.Image);

            Pen fioPen = new Pen(Color.FromArgb(139, 0, 255), 1);

            for (int m = 0; m < id.Count; m++)
            {
                Point[] points1 = new Point[res[id[m]].Count];
                for (int l = 0; l < res[id[m]].Count; l++)
                {
                    points1[l] = res[id[m]][l];
                }
                o.FillPolygon(GreenBrush, points1);
                pictureBox1.Invalidate();
            }
            for (int m = 0; m < id.Count; m++)
            {
                Point[] points1 = new Point[res[id[m]].Count];
                for (int l = 0; l < res[id[m]].Count; l++)
                {
                    points1[l] = res[id[m]][l];
                }
                o.DrawPolygon(fioPen, points1);
                pictureBox1.Invalidate();
            }


        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}

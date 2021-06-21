using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace Homework
{
    public partial class Form1 : Form
    {
        //decimal[] values = { };
        //TextBox[] textBoxes = { };
        decimal[] vals = { }/*{
                Convert.ToInt32(textBox1.Text),
                Convert.ToInt32(textBox2.Text),
                Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox4.Text),
                Convert.ToInt32(textBox5.Text),
                Convert.ToInt32(textBox6.Text),
                Convert.ToInt32(textBox7.Text),
                Convert.ToInt32(textBox8.Text),
                Convert.ToInt32(textBox9.Text),
                Convert.ToInt32(textBox10.Text)
            }*/;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Paint += new PaintEventHandler(Repaint);
            
        }
        public Bitmap DrawDiagram(int diam, decimal[] values)
        {
            // Создаем новый образ и стираем фон
            Bitmap mybit = new Bitmap(diam, diam, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(mybit);
          

            // Создаем кисти для окрашивания на круговой диаграмме
            SolidBrush[] brush = new SolidBrush[10];
            brush[0] = new SolidBrush(Color.Yellow);
            brush[1] = new SolidBrush(Color.Green);
            brush[2] = new SolidBrush(Color.Blue);
            brush[3] = new SolidBrush(Color.Cyan);
            brush[4] = new SolidBrush(Color.Magenta);
            brush[5] = new SolidBrush(Color.Red);
            brush[6] = new SolidBrush(Color.Black);
            brush[7] = new SolidBrush(Color.Gray);
            brush[8] = new SolidBrush(Color.Maroon);
            brush[9] = new SolidBrush(Color.LightBlue);

            // Сумма для получения общего
            decimal all = 0.0m;
            foreach (decimal val in values)all += val;

            // Рисуем круговую диаграмму
            float startZ = 0.0f;
            float endZ = 0.0f;
            decimal current = 0.0m;
            for (int i = 0; i < values.Length; i++)
            {
                current += values[i];
                startZ = endZ;
                endZ = (float)(current / all) * 360.0f;
                graphics.FillPie(brush[i%10], 0.0f, 0.0f, diam, diam, startZ, endZ - startZ);
            }

            // Очищаем ресурсы кисти
            foreach (SolidBrush cleanBrush in brush) cleanBrush.Dispose();

            return mybit;
        }

        private void Repaint(object sender, PaintEventArgs e)
        {
            
            
            
            Bitmap myBitmap = DrawDiagram(300, vals);//Создаем картинку
            Graphics g = e.Graphics;
            g.DrawImage(myBitmap, 25, 27); //Выводим круговую диаграмму на экран в нужных координатах
            
        }

        public int conv (TextBox textBox)
        {
            int res = 0;
            try
            {
                res = Convert.ToInt32(textBox.Text);
            }
            catch (Exception)
            {
                textBox.Text = 0.ToString();
            }
            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updValues();
            groupBox1.Visible = false;
            groupBox1.Visible = true;
            Invalidate();
        }

        public void updValues()
        {
            decimal[] values = { 
                conv(textBox1),
                conv(textBox2),
                conv(textBox3),
                conv(textBox4),
                conv(textBox5),
                conv(textBox6),
                conv(textBox7),
                conv(textBox8),
                conv(textBox9),
                conv(textBox10)
            };
            int count = 0;
            foreach (var item in values)
            {
                if (item > 0) count++;
            }
            if(count>0)vals = values;
           

            


        }
    }
}

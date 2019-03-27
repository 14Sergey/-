using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.BMP)|*.BMP";
            Image img = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    img = pictureBox1.Image;
                    Bitmap obj2 = new Bitmap(ofd.FileName);

                }
                catch
                {
                    MessageBox.Show("ошибка открытия файла", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Color obj1 = new Color();


                label1.Text = get_propertys(img, 1, 4) + "\n" + "\n" + "\n" + get_propertys(img, 17, 21) + "\n" + "\n" + "\n" + get_propertys(img, 21, 25) + "\n" + "\n" + get_propertys(img, 25, 27) + "\n" + "\n" + get_propertys(img, 27, 29) + "\n" + "\n" + "\n" + get_propertys(img, 29, 33) + "\n" + "\n" + "\n" + "\n" + get_propertys(img, 45, 49);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private string get_propertys(Image img, int left, int right) //посылаем диапозон считываемого байтов в изображение и получаем свойство картинки. 
        {
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] binaryImage = memoryStream.ToArray();
            //label1.Text = Convert.ToString(binaryImage[0], 16);
            string element = null, element2;
            for (int i = right; i > left; i--)
            {
                element2 = Convert.ToString(binaryImage[i], 16);
                element += element2;
            }
            int razmer = Convert.ToInt32(element, 16);
            string rez = razmer.ToString();
            return rez;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

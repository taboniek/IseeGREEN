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

namespace Shrek
{
    public partial class Form1 : Form
    {
        Bitmap picture;
        public Form1()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            var path = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = openFileDialog1.FileName;
                    var file = openFileDialog1.OpenFile();
                    using (StreamReader reader = new StreamReader(file))
                    {
                        var fileContent = reader.ReadToEnd();
                    }

                }
                catch
                {
                    MessageBox.Show("Error!");
                }
            }
            textBox1.Text = path;
            picture = (Bitmap)Image.FromFile(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Image)picture;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Bitmap afterimg = picture;
            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    Color pixel = picture.GetPixel(i, j);
                    if (pixel.G > (pixel.B * 2) || pixel.G > (pixel.R * 2))
                    {
                        afterimg.SetPixel(i, j, Color.Green);
                    }
                    else
                    {
                        afterimg.SetPixel(i, j, Color.White);
                    }
                }
            }
            watch.Stop();
            textBox2.Text = watch.ElapsedMilliseconds.ToString() + "ms";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = (Image)afterimg;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
    }
}

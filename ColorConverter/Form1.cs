using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorConverter
{
    public partial class Form1 : Form
    {
    
        ColorConvert cc = new ColorConvert();
        //lets check
        int check = 1;
        Stack<Bitmap> image = new Stack<Bitmap>();
        Stack<Bitmap> image1 = new Stack<Bitmap>();

        public Form1()
            {
                InitializeComponent();
            }

            private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                string imagePath;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "new image file|";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    cc.rgbImage = new Bitmap(imagePath);
                //??
                    cc.ConvertRGBimagetoHSV();
                    this.pictureBox1.Image = cc.rgbImage;
                    image.Push(cc.rgbImage);
            }
            }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpH = cc.hsvImage[i, j].h + trackBar1.Value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = (ushort)(tmpH + 360);
                    else if (tmpH >= 360)
                        cc.hsvImage[i, j].h = (ushort)(tmpH - 360);
                    else
                        cc.hsvImage[i, j].h = (ushort)tmpH;
                }

            trackBar1.Value = 0;
            cc.ConvertHSVimagetoRGB();
            image.Push(cc.rgbImage);
            pictureBox1.Image = cc.rgbImage;
            this.Cursor = Cursors.Default;

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Filter = "Image Files (*.jpg)|*.jpg";
               
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }
                  
                    
                }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (image.Count != 0)
            {

                Bitmap tmp = image.Pop();
                image1.Push(tmp);
                pictureBox1.Image = tmp;

            }
            //else
            //{
            //    Bitmap tmp1 = image1.Pop();
            //    pictureBox1.Image = tmp1;
            //}
            this.Cursor = Cursors.Default;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    if (trackBar3.Value > cc.hsvImage[i, j].s)
                    {
                        cc.hsvImage[i, j].s += (byte)trackBar3.Value;
                    }
                    else
                    {

                        cc.hsvImage[i, j].s -= (byte)trackBar3.Value;
                    }

  
                    if (cc.hsvImage[i, j].s > 100)
                    {
                        cc.hsvImage[i, j].s = 100;
                    }
          
                    if (cc.hsvImage[i, j].s < 0)
                    {
                        cc.hsvImage[i, j].s = 0;
                    }
                    }
                   
            trackBar3.Value = 0;
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
            image.Push(cc.rgbImage);
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    if (trackBar4.Value > cc.hsvImage[i, j].v)
                    {
                        cc.hsvImage[i, j].v += (byte)trackBar4.Value;
                    }
                    else
                    {

                        cc.hsvImage[i, j].v -= (byte)trackBar4.Value;
                    }


                    if (cc.hsvImage[i, j].v > 100)
                    {
                        cc.hsvImage[i, j].v = 100;
                    }

                    if (cc.hsvImage[i, j].v < 0)
                    {
                        cc.hsvImage[i, j].v = 0;
                    }
                }
            trackBar4.Value = 0;
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
            image.Push(cc.rgbImage);
            this.Cursor = Cursors.Default;
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            int width;
            this.Cursor = Cursors.WaitCursor;
            if (check == 1)
            {
                width = ((cc.rgbImage.Width) / 2);
                check = 2;
            }
            else
            {
                width = cc.rgbImage.Width;
            }

            cc.ConvertRGBimagetoHSV(width);
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpH = cc.hsvImage[i, j].h + trackBar1.Value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = (ushort)(tmpH + 360);
                    else if (tmpH >= 360)
                        cc.hsvImage[i, j].h = (ushort)(tmpH - 360);
                    else
                        cc.hsvImage[i, j].h = (ushort)tmpH;
                }
            trackBar1.Value = 0;
            cc.ConvertHSVimagetoRGB(width);
            pictureBox1.Image = cc.rgbImage;
            image.Push(cc.rgbImage);
            this.Cursor = Cursors.Default;

        }

    
    }
    }
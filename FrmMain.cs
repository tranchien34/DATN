using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Diagnostics;
using Emgu.CV.CvEnum;
using System.IO;
using System.Linq;
using tesseract;
using System.Collections;
using LaptrinhVBLibs;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace LPR_Laptrinhvb
{
    public partial class FrmMain : Form
    {
        private FilterInfoCollection camera;
        private VideoCaptureDevice cam;
        private VideoCaptureDevice cam1;
        private string data_recv;
        private string bienso1;
        private string bienso2;
        private string bienso3;
        private string bienso4;

        private bool gdiplusError = false;
        private bool licensePlateDetected = false;

        public FrmMain()
        {
            InitializeComponent();
            timer1.Start();
        }


        #region định nghĩa
        List<Image<Bgr, Byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();
        PictureBox[] box = new PictureBox[12];

        public TesseractProcessor full_tesseract = null;
        public TesseractProcessor ch_tesseract = null;
        public TesseractProcessor num_tesseract = null;
        private string m_path = Application.StartupPath + @"\data\";
        private List<string> lstimages = new List<string>();
        private const string m_lang = "eng";
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            string[] _com = SerialPort.GetPortNames();
            _CB_COM.Items.AddRange(_com);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
            full_tesseract = new TesseractProcessor();
            camera = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Console.WriteLine("[CHIENTQ] Camera count: " + camera.Count);
            if (camera.Count == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else if (camera.Count == 1)
            {
                FilterInfo info = camera[0];
                comboBox1.Items.Add(info.Name);
                comboBox1.SelectedIndex = 0;
                button2.Enabled = false;
                button1.Enabled = true;
            }
            else if (camera.Count == 2)
            {
                Console.WriteLine("[CHIENTQ] Camera count: " + camera.Count);
                foreach (FilterInfo info in camera)
                {
                    comboBox1.Items.Add(info.Name);
                    comboBox2.Items.Add(info.Name);
                }
                button1.Enabled = true;
                button2.Enabled = true;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
            }
            else if (camera.Count == 3)
            {
                Console.WriteLine("[CHIENTQ] Camera count: " + camera.Count);
                foreach (FilterInfo info in camera)
                {
                    comboBox1.Items.Add(info.Name);
                    comboBox2.Items.Add(info.Name);
                }
                button1.Enabled = true;
                button2.Enabled = true;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
            }
            Console.WriteLine("End_camera");
            bool succeed = full_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi thư viện Tesseract. Chương trình cần kết thúc.");
                //Application.Exit();
                Application.Restart();
            }
            full_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFGHIKLMNOPQRSTVXYW1234567890").ToString();

            ch_tesseract = new TesseractProcessor();
            succeed = ch_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi thư viện Tesseract. Chương trình cần kết thúc.");
                //Application.Exit();
                Application.Restart();
            }
            ch_tesseract.SetVariable("tessedit_char_whitelist", "ACDEFHKLMNPRSTUVXY").ToString();

            num_tesseract = new TesseractProcessor();
            succeed = num_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi thư viện Tesseract. Chương trình cần kết thúc.");
                //Application.Exit();
                //return;
                Application.Restart();
            }
            num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890").ToString();

            System.Environment.CurrentDirectory = System.IO.Path.GetFullPath(m_path);
            for (int i = 0; i < box.Length; i++)
            {
                box[i] = new PictureBox();
            }
            string folder = Application.StartupPath + "\\ImageTest";
            foreach (string fileName in Directory.GetFiles(folder, "*.bmp", SearchOption.TopDirectoryOnly))
            {
                lstimages.Add(Path.GetFullPath(fileName));
            }
            foreach (string fileName in Directory.GetFiles(folder, "*.jpg", SearchOption.TopDirectoryOnly))
            {
                lstimages.Add(Path.GetFullPath(fileName));
            }
        }

        private void Check_BienSo(string path_Image)
        {
            if (full_tesseract == null || ch_tesseract == null || num_tesseract == null)
            {
                MessageBox.Show("Không thể nhận dKhông thể nhận diện biển số do lỗi khởi tạo Tesseract engine.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProcessImage(path_Image);
            if (PlateImagesList.Count != 0)
            {
                Image<Bgr, byte> src = new Image<Bgr, byte>(PlateImagesList[0].ToBitmap());
                Bitmap grayframe;
                Bitmap color;
                int c = clsBSoft.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);
                pictureBox1.Image = color;
                //pictureBox2.Image = grayframe;
                Image<Gray, byte> dst = new Image<Gray, byte>(grayframe);
                grayframe = dst.ToBitmap();
                string zz = "";

                // lọc và sắp xếp số
                List<Bitmap> bmp = new List<Bitmap>();
                List<int> erode = new List<int>();
                List<Rectangle> up = new List<Rectangle>();
                List<Rectangle> dow = new List<Rectangle>();
                int up_y = 0, dow_y = 0;
                bool flag_up = false;

                int di = 0;

                if (listRect == null) return;

                for (int i = 0; i < listRect.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);
                    int cou = 0;
                    full_tesseract.Clear();
                    full_tesseract.ClearAdaptiveClassifier();
                    string temp = full_tesseract.Apply(ch);
                    while (temp.Length > 3)
                    {
                        Image<Gray, byte> temp2 = new Image<Gray, byte>(ch);
                        temp2 = temp2.Erode(2);
                        ch = temp2.ToBitmap();
                        full_tesseract.Clear();
                        full_tesseract.ClearAdaptiveClassifier();
                        temp = full_tesseract.Apply(ch);
                        cou++;
                        if (cou > 10)
                        {
                            listRect.RemoveAt(i);
                            i--;
                            di = 0;
                            break;
                        }
                        di = cou;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    for (int j = i; j < listRect.Count; j++)
                    {
                        if (listRect[i].Y > listRect[j].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[j].Y;
                            dow_y = listRect[i].Y;
                            break;
                        }
                        else if (listRect[j].Y > listRect[i].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[i].Y;
                            dow_y = listRect[j].Y;
                            break;
                        }
                        if (flag_up == true) break;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                    {
                        up.Add(listRect[i]);
                    }
                    else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                    {
                        dow.Add(listRect[i]);
                    }
                }

                if (flag_up == false) dow = listRect;

                for (int i = 0; i < up.Count; i++)
                {
                    for (int j = i; j < up.Count; j++)
                    {
                        if (up[i].X > up[j].X)
                        {
                            Rectangle w = up[i];
                            up[i] = up[j];
                            up[j] = w;
                        }
                    }
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    for (int j = i; j < dow.Count; j++)
                    {
                        if (dow[i].X > dow[j].X)
                        {
                            Rectangle w = dow[i];
                            dow[i] = dow[j];
                            dow[j] = w;
                        }
                    }
                }

                int x = 0;
                int c_x = 0;

                for (int i = 0; i < up.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                    Bitmap o = ch;
                    string temp;
                    if (i < 2)
                    {
                        temp = clsBSoft.Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, true); // nhan dien so
                    }
                    else
                    {
                        temp = clsBSoft.Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, false); // nhan dien chu
                    }

                    zz += temp;
                    Console.WriteLine(temp);
                    box[i].Location = new Point(x + i * 50, 0);
                    box[i].Size = new Size(50, 100);
                    box[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i].Image = ch;
                    //panel1.Controls.Add(box[i]);
                    Console.WriteLine();
                    c_x++;
                }
                zz += "\r\n";
                for (int i = 0; i < dow.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);
                    string temp = clsBSoft.Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, true); // nhan dien so

                    zz += temp;
                    Console.WriteLine(temp);
                    box[i + c_x].Location = new Point(x + i * 50, 100);
                    box[i + c_x].Size = new Size(50, 100);
                    box[i + c_x].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i + c_x].Image = ch;
                    //panel1.Controls.Add(box[i + c_x]);
                }
                textBox1.Text = zz;

            }
        }

        public void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            Bitmap img = new Bitmap(urlImage);
            //pictureBox2.Image = null;
            pictureBox1.Image = img;
            pictureBox1.Update();
            clsBSoft.FindLicensePlate(img, pictureBox1, imageBox1, PlateImagesList, panel1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button1 click Cam1");
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(camera[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            videoShow1.Image = bitmap;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button2 click Cam1");
            if (cam1 != null && cam1.IsRunning)
            {
                cam1.Stop();
            }
            cam1 = new VideoCaptureDevice(camera[comboBox2.SelectedIndex].MonikerString);
            cam1.NewFrame += Cam_NewFrame1;
            cam1.Start();
        }

        private void Cam_NewFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            videoShow2.Image = bitmap;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Bt_connect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                serialPort1.Close();
                _Bt_connect.Text = "Connect";
                _Bt_connect.ForeColor = Color.Red;
                _lb_Status.Text = "Disconnect";
                _lb_Status.ForeColor = Color.Red;
            }
            else
            {


                //MessageBox.Show(_CB_COM.Text);

                serialPort1.PortName = _CB_COM.Text;
                serialPort1.BaudRate = 9600;

                serialPort1.Open();
                _Bt_connect.Text = "Disconnect";
                _Bt_connect.ForeColor = Color.Green;
                _lb_Status.Text = "Connect";
                _lb_Status.ForeColor = Color.Green;
                _Rb_recv.Text += "Serial " + _CB_COM.Text + " is open \r\n";

            }
        }
        private void DataReceive(object sender, SerialDataReceivedEventArgs e)
        {
            data_recv = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }
        private void save_picture1(int i)
        {
            //string path = "D:\\Picture\\" + i + ".jpg";
            //videoShow1.Image.Save(@path, System.Drawing.Imaging.ImageFormat.Jpeg);

            string path = "D:\\Picture\\" + i + ".jpg";
            try
            {
                videoShow1.Image.Save(@path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                gdiplusError = true;
            }
        }
        private void save_picture2(int i)
        {
            //string path = "D:\\Picture\\" + i + ".jpg";
            //videoShow2.Image.Save(@path, System.Drawing.Imaging.ImageFormat.Jpeg);

            string path = "D:\\Picture\\" + i + ".jpg";
            try
            {
                videoShow2.Image.Save(@path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                gdiplusError = true;
                if (gdiplusError)
                {
                    MessageBox.Show("GDI+ Error occurred.");
                }

            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            _Rb_recv.Text += data_recv + "\r\n";
            //MessageBox.Show(data_recv);


            if (data_recv.Trim() == "1")
            {
                save_picture1(1);
                try
                {
                    Check_BienSo("D:\\Picture\\1.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                bienso1 = textBox1.Text;
                if (bienso1 == "")
                {
                    serialPort1.Write("B");
                }
                else
                {
                    serialPort1.Write("A");
                }
                Console.WriteLine("Bien so 1: " + bienso1);
            }
            else if (data_recv.Trim() == "2")
            {
                save_picture1(2);
                try
                {
                    Check_BienSo("D:\\Picture\\2.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                bienso2 = textBox1.Text;
                if (bienso2 == "")
                {
                    serialPort1.Write("B");
                }
                else
                {
                    serialPort1.Write("A");
                }
                Console.WriteLine("Bien so 2: " + bienso2);
            }
            else if (data_recv.Trim() == "3")
            {
                save_picture1(3);
                try
                {
                    Check_BienSo("D:\\Picture\\3.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                bienso3 = textBox1.Text;
                if (bienso3 == "")
                {
                    serialPort1.Write("B");
                }
                else
                {
                    serialPort1.Write("A");
                }
                Console.WriteLine("Bien so 3: " + bienso3);
            }
            else if (data_recv.Trim() == "4")
            {
                save_picture1(4);
                try
                {
                    Check_BienSo("D:\\Picture\\4.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                bienso4 = textBox1.Text;
                if (bienso4 == "")
                {
                    serialPort1.Write("B");
                }
                else
                {
                    serialPort1.Write("A");
                }
                Console.WriteLine("Bien so 4: " + bienso4);
            }
            else if (data_recv.Trim() == "5")
            {
                save_picture2(5);
                Check_BienSo("D:\\Picture\\5.jpg");
                if (string.Compare(bienso1, textBox1.Text) == 0)
                {
                    _lb_checkcar.Text = "Card Oke";
                    _lb_checkcar.ForeColor = Color.Green;
                    serialPort1.Write("A");
                }
                else
                {
                    _lb_checkcar.Text = "Card Error";
                    _lb_checkcar.ForeColor = Color.Red;
                    serialPort1.Write("B");
                }

            }
            else if (data_recv.Trim() == "6")
            {
                save_picture2(6);
                try
                {
                    Check_BienSo("D:\\Picture\\6.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                if (string.Compare(bienso2, textBox1.Text) == 0)
                {
                    _lb_checkcar.Text = "Card Oke";
                    _lb_checkcar.ForeColor = Color.Green;
                    serialPort1.Write("A");
                }
                else
                {
                    _lb_checkcar.Text = "Card Error";
                    _lb_checkcar.ForeColor = Color.Red;
                    serialPort1.Write("B");
                }
            }
            else if (data_recv.Trim() == "7")
            {
                save_picture2(7);
                try
                {
                    Check_BienSo("D:\\Picture\\7.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                if (string.Compare(bienso3, textBox1.Text) == 0)
                {
                    _lb_checkcar.Text = "Card Oke";
                    _lb_checkcar.ForeColor = Color.Green;
                    serialPort1.Write("A");
                }
                else
                {
                    _lb_checkcar.Text = "Card Error";
                    _lb_checkcar.ForeColor = Color.Red;
                    serialPort1.Write("B");
                }
            }
            else if (data_recv.Trim() == "8")
            {
                save_picture2(8);
                try
                {
                    Check_BienSo("D:\\Picture\\8.jpg");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    gdiplusError = true;

                }
                if (string.Compare(bienso4, textBox1.Text) == 0)
                {
                    _lb_checkcar.Text = "Card Oke";
                    _lb_checkcar.ForeColor = Color.Green;
                    serialPort1.Write("A");
                }
                else
                {
                    _lb_checkcar.Text = "Card Error";
                    _lb_checkcar.ForeColor = Color.Red;
                    serialPort1.Write("B");
                }
            }
            data_recv = "";
        }

        private void _CB_COM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            time2.Text = DateTime.Now.ToLongDateString();
        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void _Rb_recv_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

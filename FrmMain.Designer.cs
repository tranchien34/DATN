namespace LPR_Laptrinhvb
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._Rb_recv = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._lb_checkcar = new System.Windows.Forms.Label();
            this._lb_Status = new System.Windows.Forms.Label();
            this._Bt_connect = new System.Windows.Forms.Button();
            this._CB_COM = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.videoShow2 = new System.Windows.Forms.PictureBox();
            this.videoShow1 = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.time2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoShow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoShow1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(702, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 83);
            this.textBox1.TabIndex = 7;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.ForeColor = System.Drawing.Color.Black;
            this.lblNumber.Location = new System.Drawing.Point(614, 46);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(82, 15);
            this.lblNumber.TabIndex = 11;
            this.lblNumber.Text = "NHẬN DẠNG";
            this.lblNumber.Click += new System.EventHandler(this.lblNumber_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(603, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 569);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(23, 44);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(335, 232);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(23, 313);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 232);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // _Rb_recv
            // 
            this._Rb_recv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_recv.Location = new System.Drawing.Point(934, 16);
            this._Rb_recv.Name = "_Rb_recv";
            this._Rb_recv.Size = new System.Drawing.Size(158, 82);
            this._Rb_recv.TabIndex = 19;
            this._Rb_recv.Text = "";
            this._Rb_recv.TextChanged += new System.EventHandler(this._Rb_recv_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._lb_checkcar);
            this.groupBox2.Controls.Add(this._Rb_recv);
            this.groupBox2.Controls.Add(this._lb_Status);
            this.groupBox2.Controls.Add(this._Bt_connect);
            this.groupBox2.Controls.Add(this._CB_COM);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblNumber);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(79, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1111, 109);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BẢNG KẾT NỐI";
            // 
            // _lb_checkcar
            // 
            this._lb_checkcar.AutoSize = true;
            this._lb_checkcar.Location = new System.Drawing.Point(41, 160);
            this._lb_checkcar.Name = "_lb_checkcar";
            this._lb_checkcar.Size = new System.Drawing.Size(67, 15);
            this._lb_checkcar.TabIndex = 20;
            this._lb_checkcar.Text = "Check Car";
            // 
            // _lb_Status
            // 
            this._lb_Status.AutoSize = true;
            this._lb_Status.ForeColor = System.Drawing.Color.Teal;
            this._lb_Status.Location = new System.Drawing.Point(415, 25);
            this._lb_Status.Name = "_lb_Status";
            this._lb_Status.Size = new System.Drawing.Size(117, 15);
            this._lb_Status.TabIndex = 19;
            this._lb_Status.Text = "CHỌN CỔNG COM";
            // 
            // _Bt_connect
            // 
            this._Bt_connect.ForeColor = System.Drawing.Color.Green;
            this._Bt_connect.Location = new System.Drawing.Point(501, 53);
            this._Bt_connect.Name = "_Bt_connect";
            this._Bt_connect.Size = new System.Drawing.Size(92, 25);
            this._Bt_connect.TabIndex = 17;
            this._Bt_connect.Text = "Connect";
            this._Bt_connect.UseVisualStyleBackColor = true;
            this._Bt_connect.Click += new System.EventHandler(this._Bt_connect_Click);
            // 
            // _CB_COM
            // 
            this._CB_COM.FormattingEnabled = true;
            this._CB_COM.Location = new System.Drawing.Point(339, 53);
            this._CB_COM.Name = "_CB_COM";
            this._CB_COM.Size = new System.Drawing.Size(139, 23);
            this._CB_COM.TabIndex = 16;
            this._CB_COM.SelectedIndexChanged += new System.EventHandler(this._CB_COM_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Green;
            this.button2.Location = new System.Drawing.Point(187, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 26);
            this.button2.TabIndex = 15;
            this.button2.Text = "Camera 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(187, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "Camera 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(16, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 23);
            this.comboBox2.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 23);
            this.comboBox1.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.videoShow2);
            this.groupBox3.Controls.Add(this.videoShow1);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(79, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 569);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Camera sau";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Camera trước";
            // 
            // videoShow2
            // 
            this.videoShow2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoShow2.Location = new System.Drawing.Point(51, 313);
            this.videoShow2.Name = "videoShow2";
            this.videoShow2.Size = new System.Drawing.Size(402, 232);
            this.videoShow2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoShow2.TabIndex = 1;
            this.videoShow2.TabStop = false;
            // 
            // videoShow1
            // 
            this.videoShow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoShow1.Location = new System.Drawing.Point(51, 44);
            this.videoShow1.Name = "videoShow1";
            this.videoShow1.Size = new System.Drawing.Size(402, 232);
            this.videoShow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoShow1.TabIndex = 0;
            this.videoShow1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(1047, 265);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(131, 36);
            this.time.TabIndex = 17;
            this.time.Text = "Đồng hồ ";
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1303, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.mENUToolStripMenuItem.Text = "MENU";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(18, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 10);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // time2
            // 
            this.time2.AutoSize = true;
            this.time2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time2.Location = new System.Drawing.Point(994, 319);
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(149, 33);
            this.time2.TabIndex = 19;
            this.time2.Text = "Ngày tháng ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 749);
            this.Controls.Add(this.time2);
            this.Controls.Add(this.time);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÃI ĐỖ XE - Version 1.0";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoShow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoShow1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label lblNumber;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox videoShow2;
        private System.Windows.Forms.PictureBox videoShow1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _Bt_connect;
        private System.Windows.Forms.ComboBox _CB_COM;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label _lb_Status;
        private System.Windows.Forms.RichTextBox _Rb_recv;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _lb_checkcar;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Label time2;
    }
}


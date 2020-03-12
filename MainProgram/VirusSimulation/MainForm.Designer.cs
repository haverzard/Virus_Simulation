namespace VirusSimulation
{
    partial class MainForm
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
            this.loadpop = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtloader = new System.Windows.Forms.OpenFileDialog();
            this.renderbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Button();
            this.topmenu = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadmap = new System.Windows.Forms.Button();
            this.resetbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ndays = new System.Windows.Forms.NumericUpDown();
            this.desc = new System.Windows.Forms.Label();
            this.topmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndays)).BeginInit();
            this.SuspendLayout();
            // 
            // loadpop
            // 
            this.loadpop.BackColor = System.Drawing.Color.YellowGreen;
            this.loadpop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadpop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadpop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadpop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.loadpop.Location = new System.Drawing.Point(559, 153);
            this.loadpop.Name = "loadpop";
            this.loadpop.Size = new System.Drawing.Size(151, 47);
            this.loadpop.TabIndex = 0;
            this.loadpop.Text = "Load Population";
            this.loadpop.UseVisualStyleBackColor = false;
            this.loadpop.Click += new System.EventHandler(this.loadpop_Click);
            // 
            // txtloader
            // 
            this.txtloader.FileName = "loader";
            // 
            // renderbutton
            // 
            this.renderbutton.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.renderbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.renderbutton.Enabled = false;
            this.renderbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renderbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renderbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.renderbutton.Location = new System.Drawing.Point(559, 259);
            this.renderbutton.Name = "renderbutton";
            this.renderbutton.Size = new System.Drawing.Size(72, 47);
            this.renderbutton.TabIndex = 2;
            this.renderbutton.Text = "Show";
            this.renderbutton.UseVisualStyleBackColor = false;
            this.renderbutton.Click += new System.EventHandler(this.renderbutton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GreenYellow;
            this.panel1.Location = new System.Drawing.Point(3, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 3);
            this.panel1.TabIndex = 4;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = global::VirusSimulation.Properties.Resources.exit;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit.Location = new System.Drawing.Point(710, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(25, 25);
            this.exit.TabIndex = 1;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // topmenu
            // 
            this.topmenu.Controls.Add(this.back);
            this.topmenu.Controls.Add(this.title);
            this.topmenu.Controls.Add(this.exit);
            this.topmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.topmenu.Location = new System.Drawing.Point(0, 0);
            this.topmenu.Name = "topmenu";
            this.topmenu.Size = new System.Drawing.Size(747, 52);
            this.topmenu.TabIndex = 5;
            this.topmenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topmenu_MouseDown);
            this.topmenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topmenu_MouseMove);
            this.topmenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topmenu_MouseUp);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.BackgroundImage = global::VirusSimulation.Properties.Resources.back;
            this.back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.back.Location = new System.Drawing.Point(12, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(25, 25);
            this.back.TabIndex = 3;
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.GreenYellow;
            this.title.Location = new System.Drawing.Point(286, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(216, 25);
            this.title.TabIndex = 2;
            this.title.Text = "VIRUS SIMULATION";
            // 
            // picbox
            // 
            this.picbox.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.picbox.Location = new System.Drawing.Point(2, 48);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(500, 509);
            this.picbox.TabIndex = 6;
            this.picbox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GreenYellow;
            this.panel2.Location = new System.Drawing.Point(501, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 502);
            this.panel2.TabIndex = 5;
            // 
            // loadmap
            // 
            this.loadmap.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.loadmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadmap.Enabled = false;
            this.loadmap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadmap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.loadmap.Location = new System.Drawing.Point(559, 206);
            this.loadmap.Name = "loadmap";
            this.loadmap.Size = new System.Drawing.Size(151, 47);
            this.loadmap.TabIndex = 8;
            this.loadmap.Text = "Load Map";
            this.loadmap.UseVisualStyleBackColor = false;
            this.loadmap.Click += new System.EventHandler(this.loadmap_Click);
            // 
            // resetbutton
            // 
            this.resetbutton.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.resetbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.resetbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.resetbutton.Location = new System.Drawing.Point(640, 259);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(70, 47);
            this.resetbutton.TabIndex = 9;
            this.resetbutton.Text = "Reset";
            this.resetbutton.UseVisualStyleBackColor = false;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(556, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Num of Days:";
            // 
            // ndays
            // 
            this.ndays.Enabled = false;
            this.ndays.Location = new System.Drawing.Point(651, 341);
            this.ndays.Name = "ndays";
            this.ndays.Size = new System.Drawing.Size(59, 22);
            this.ndays.TabIndex = 13;
            this.ndays.ValueChanged += new System.EventHandler(this.ndays_ValueChanged);
            // 
            // desc
            // 
            this.desc.AutoSize = true;
            this.desc.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.desc.Location = new System.Drawing.Point(161, 247);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(198, 25);
            this.desc.TabIndex = 14;
            this.desc.Text = "Graph not yet loaded.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(747, 554);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.ndays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.loadmap);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.topmenu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.renderbutton);
            this.Controls.Add(this.loadpop);
            this.Controls.Add(this.picbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topmenu.ResumeLayout(false);
            this.topmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadpop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.OpenFileDialog txtloader;
        private System.Windows.Forms.Button renderbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel topmenu;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button loadmap;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ndays;
        private System.Windows.Forms.Label desc;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button back;
    }
}

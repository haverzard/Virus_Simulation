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
            this.loadmap = new System.Windows.Forms.Button();
            this.resetbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ndays = new System.Windows.Forms.NumericUpDown();
            this.desc = new System.Windows.Forms.Label();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ndays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadpop
            // 
            this.loadpop.BackColor = System.Drawing.Color.YellowGreen;
            this.loadpop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadpop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadpop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadpop.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadpop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.loadpop.Location = new System.Drawing.Point(405, 145);
            this.loadpop.Margin = new System.Windows.Forms.Padding(2);
            this.loadpop.Name = "loadpop";
            this.loadpop.Size = new System.Drawing.Size(132, 34);
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
            this.renderbutton.BackColor = System.Drawing.Color.YellowGreen;
            this.renderbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.renderbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.renderbutton.Enabled = false;
            this.renderbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.renderbutton.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renderbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.renderbutton.Location = new System.Drawing.Point(405, 230);
            this.renderbutton.Margin = new System.Windows.Forms.Padding(2);
            this.renderbutton.Name = "renderbutton";
            this.renderbutton.Size = new System.Drawing.Size(64, 33);
            this.renderbutton.TabIndex = 2;
            this.renderbutton.Text = "Show";
            this.renderbutton.UseVisualStyleBackColor = false;
            this.renderbutton.Click += new System.EventHandler(this.renderbutton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GreenYellow;
            this.panel1.Location = new System.Drawing.Point(3, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 5);
            this.panel1.TabIndex = 4;
            // 
            // loadmap
            // 
            this.loadmap.BackColor = System.Drawing.Color.YellowGreen;
            this.loadmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadmap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadmap.Enabled = false;
            this.loadmap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadmap.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadmap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.loadmap.Location = new System.Drawing.Point(405, 188);
            this.loadmap.Margin = new System.Windows.Forms.Padding(2);
            this.loadmap.Name = "loadmap";
            this.loadmap.Size = new System.Drawing.Size(132, 33);
            this.loadmap.TabIndex = 8;
            this.loadmap.Text = "Load Map";
            this.loadmap.UseVisualStyleBackColor = false;
            this.loadmap.Click += new System.EventHandler(this.loadmap_Click);
            // 
            // resetbutton
            // 
            this.resetbutton.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.resetbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.resetbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetbutton.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbutton.ForeColor = System.Drawing.Color.White;
            this.resetbutton.Location = new System.Drawing.Point(473, 230);
            this.resetbutton.Margin = new System.Windows.Forms.Padding(2);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(64, 33);
            this.resetbutton.TabIndex = 9;
            this.resetbutton.Text = "Reset";
            this.resetbutton.UseVisualStyleBackColor = false;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(404, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Num of Days:";
            // 
            // ndays
            // 
            this.ndays.BackColor = System.Drawing.Color.GreenYellow;
            this.ndays.Enabled = false;
            this.ndays.Location = new System.Drawing.Point(487, 285);
            this.ndays.Margin = new System.Windows.Forms.Padding(2);
            this.ndays.Name = "ndays";
            this.ndays.Size = new System.Drawing.Size(44, 20);
            this.ndays.TabIndex = 13;
            this.ndays.ValueChanged += new System.EventHandler(this.ndays_ValueChanged);
            // 
            // desc
            // 
            this.desc.AutoSize = true;
            this.desc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.desc.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.ForeColor = System.Drawing.Color.White;
            this.desc.Location = new System.Drawing.Point(109, 212);
            this.desc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(159, 21);
            this.desc.TabIndex = 14;
            this.desc.Text = "Graph not yet loaded.";
            // 
            // picbox
            // 
            this.picbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picbox.Location = new System.Drawing.Point(2, 39);
            this.picbox.Margin = new System.Windows.Forms.Padding(5);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(375, 414);
            this.picbox.TabIndex = 6;
            this.picbox.TabStop = false;
            this.picbox.Click += new System.EventHandler(this.picbox_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = global::VirusSimulation.Properties.Resources.exit;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit.Location = new System.Drawing.Point(530, 5);
            this.exit.Margin = new System.Windows.Forms.Padding(2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(19, 20);
            this.exit.TabIndex = 1;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(560, 450);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.ndays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.loadmap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.renderbutton);
            this.Controls.Add(this.loadpop);
            this.Controls.Add(this.picbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ndays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadpop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog txtloader;
        private System.Windows.Forms.Button renderbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.Button loadmap;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ndays;
        private System.Windows.Forms.Label desc;
        private System.Windows.Forms.Button exit;
    }
}


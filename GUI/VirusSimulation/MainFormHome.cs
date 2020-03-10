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

using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Drawing.Imaging;


namespace VirusSimulation
{
    public partial class MainFormHome : Form
    {

        private Button Start;

        // Drag
        Point mousedownpoint = Point.Empty;

        public MainFormHome()
        {
            InitializeComponent();
        }


        // Tampilkan Graph
        

        // Drag
        private void MainFormHome_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }

        //Drag
        private void MainFormHome_MouseMove(object sender, MouseEventArgs e)
        {

            if (mousedownpoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));

        }

        //Drag
        private void MainFormHome_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }

        //Drag
        private void topmenu_MouseDown(object sender, MouseEventArgs e)
        {
            MainFormHome_MouseDown(this, e);
        }

        //Drag
        private void topmenu_MouseUp(object sender, MouseEventArgs e)
        {
            MainFormHome_MouseUp(this, e);
        }

        //Drag
        private void topmenu_MouseMove(object sender, MouseEventArgs e)
        {
            MainFormHome_MouseMove(this, e);
        }


        
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.YellowGreen;
            this.Start.CausesValidation = false;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.Location = new System.Drawing.Point(205, 308);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(144, 37);
            this.Start.TabIndex = 0;
            this.Start.Text = "START";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainFormHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::VirusSimulation.Properties.Resources.cover;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(544, 434);
            this.ControlBox = false;
            this.Controls.Add(this.Start);
            this.Name = "MainFormHome";
            this.Load += new System.EventHandler(this.MainFormHome_Load);
            this.ResumeLayout(false);

        }

        private void MainFormHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

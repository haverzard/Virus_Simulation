using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusSimulation
{
    public partial class Credits : Form
    {
        // Drag
        Point mousedownpoint = Point.Empty;

        public Credits()
        {
            InitializeComponent();
        }

        // Drag
        private void Credits_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }

        //Drag
        private void Credits_MouseMove(object sender, MouseEventArgs e)
        {

            if (mousedownpoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));

        }

        //Drag
        private void Credits_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }


        private void Credits_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.MainForm_Location;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Page = "home";
            Properties.Settings.Default.MainForm_Location = this.Location;
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Page = "exit";
            this.Close();
        }
    }
}

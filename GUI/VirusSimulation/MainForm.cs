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
    public partial class MainForm : Form
    {
        BFSer bfstool;

        Boolean pop_read = false;
        Boolean map_read = false;

        List<KeyValuePair<char, double>> infections;

        Point mousedownpoint = Point.Empty;

        public MainForm()
        {
            InitializeComponent();
        }


        private void RenderGraph()
        {
            Graph g = bfstool.getGraph();
            //Prekondisi: sudah load graph.txt dan read=true
            GraphRenderer renderer = new GraphRenderer(g);
            renderer.CalculateLayout();

            int height = 400;
            int width = (int)(g.Width * (height / g.Height));

            if (g.Width > g.Height) {
                width = 400;
                height = (int)(g.Height * (width / g.Width)); ;
            }

            int numdays = Decimal.ToInt32(ndays.Value);

            foreach (char cityTo in bfstool.getNodes()) {
                g.FindNode(Char.ToString(cityTo)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                foreach (KeyValuePair<char, int> pair in bfstool.getNode(cityTo).GetInfecters())
                {
                    char cityFrom = pair.Key;
                    int days = pair.Value;

                    Edge e = bfstool.getEdge(cityFrom, cityTo);
                    
                    if (days <= numdays)
                    {
                        e.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    else {
                        e.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                    }

                }
            }

            foreach (KeyValuePair<char, double> pair in infections) {
                char city = pair.Key;
                double time = pair.Value;
                if (time <= numdays)
                {
                    g.FindNode(Char.ToString(city)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                }
                
            }

            g.Attr.BackgroundColor = Microsoft.Msagl.Drawing.Color.DarkOliveGreen;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            picbox.Image = bitmap;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void renderbutton_Click(object sender, EventArgs e)
        {
            if (map_read && pop_read) {
                ndays.Enabled = true;
                ndays.Value = 0;
                bfstool.DoBFS(100);
                infections = bfstool.getInfections();
                RenderGraph();
                renderbutton.Enabled = false;
                desc.Visible = false;
            }

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (mousedownpoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));

        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }

        private void topmenu_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm_MouseDown(this, e);
        }

        private void topmenu_MouseUp(object sender, MouseEventArgs e)
        {
            MainForm_MouseUp(this, e);
        }

        private void topmenu_MouseMove(object sender, MouseEventArgs e)
        {
            MainForm_MouseMove(this, e);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            bfstool = new BFSer();
        }

        private void loadpop_Click(object sender, EventArgs e)
        {
            txtloader.FileName = "pop.txt";
            txtloader.ShowDialog();

            // Read the file and display it line by line.  
            try
            {
                bfstool.readPopulation(txtloader.FileName);
                pop_read = true;
                if (pop_read)
                {
                    loadmap.Enabled = true;
                }
                loadpop.Enabled = false;
                desc.Text = "Graph not yet loaded.";
            }
            catch
            {
                Console.WriteLine("error");
                pop_read = false;
                desc.Text = "Error loading population.";
            }
        }

        private void loadmap_Click(object sender, EventArgs e)
        {
            txtloader.FileName = "map.txt";
            txtloader.ShowDialog();

            // Read the file and display it line by line.  
            try
            {
                bfstool.readMap(txtloader.FileName);
                map_read = true;
                if (map_read && pop_read)
                {
                    renderbutton.Enabled = true;
                }
                loadmap.Enabled = false;
                desc.Text = "Graph not yet loaded.";
            }
            catch
            {
                Console.WriteLine("error");
                desc.Text = "Error loading map.";
                map_read = false;
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            pop_read = false;
            map_read = false;
            loadpop.Enabled = true;
            loadmap.Enabled = false;
            renderbutton.Enabled = false;
            ndays.Value = 0;
            ndays.Enabled = false;
            picbox.Image = null;
            desc.Visible = true;
            bfstool = new BFSer();
        }


        private void ndays_ValueChanged(object sender, EventArgs e)
        {
            RenderGraph();
        }

    }
}

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

        // Boolean pembacaan konfigurasi
        Boolean pop_read = false;
        Boolean map_read = false;

        // Drag
        Point mousedownpoint = Point.Empty;

        public MainForm()
        {
            InitializeComponent();
        }


        // Tampilkan Graph
        private void RenderGraph()
        {

            // Membuat graph dan renderer utnuk graph
            Graph g = bfstool.getGraph();
            GraphRenderer renderer = new GraphRenderer(g);
            renderer.CalculateLayout();

            // Setup ukuran graph
            int height = 400;
            int width = (int)(g.Width * (height / g.Height));

            if (g.Width > g.Height) {
                width = 400;
                height = (int)(g.Height * (width / g.Width)); ;
            }

            int numdays = Decimal.ToInt32(ndays.Value);

            // Untuk setiap kota
            foreach (string cityTo in bfstool.getNodes()) {
                // Warnai kota tsb putih pada graph
                g.FindNode(cityTo).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;

                // Ambil kota yang menginfeksinya dan berapa hari sebelum infeksi
                foreach (KeyValuePair<string, int> pair in bfstool.getNode(cityTo).GetInfecters())
                {
                    string cityFrom = pair.Key;
                    int days = pair.Value;

                    Edge e = bfstool.getEdge(cityFrom, cityTo);
                    
                    if (days <= numdays)
                    {
                        // Warnai edge merah jika pada hari sudah terinfeksi pada numdays 
                        e.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    else {
                        // Warnai edge hitam jika pada hari sudah terinfeksi pada numdays 
                        e.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                    }

                }
            }


            // Untuk setiap pasangan kota dan waktu sampai kota tersebut terinfeksi
            foreach (KeyValuePair<string, double> pair in bfstool.getInfections()) {
                string city = pair.Key;
                double time = pair.Value;
                if (time <= numdays)
                {
                    // Warnai node merah jika terinfeksi
                    g.FindNode(city).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                }
                
            }

            // Render gambar, masukkan ke picturebox picbox
            g.Attr.BackgroundColor = Microsoft.Msagl.Drawing.Color.DarkSeaGreen;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            picbox.Image = bitmap;
        }

        // Tombol Exit
        private void exit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Page = "exit";
            this.Close();
        }

       
        // Event Tombol Show ditekan
        private void renderbutton_Click(object sender, EventArgs e)
        {
            if (map_read && pop_read) {
                ndays.Enabled = true;
                ndays.Value = 0;
                bfstool.DoBFS(100);
                RenderGraph();
                renderbutton.Enabled = false;
                renderbutton.BackColor = System.Drawing.Color.DarkOliveGreen;
                resetbutton.BackColor = System.Drawing.Color.YellowGreen;
                desc.Visible = false;
            }

        }

        // Drag
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }

        //Drag
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (mousedownpoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));

        }

        //Drag
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }

        //Drag
        private void topmenu_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm_MouseDown(this, e);
        }

        //Drag
        private void topmenu_MouseUp(object sender, MouseEventArgs e)
        {
            MainForm_MouseUp(this, e);
        }

        //Drag
        private void topmenu_MouseMove(object sender, MouseEventArgs e)
        {
            MainForm_MouseMove(this, e);
        }

        //Drag
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.MainForm_Location;
            bfstool = new BFSer();
        }

        // Dialogbox Load Population
        private void loadpop_Click(object sender, EventArgs e)
        {
            txtloader.FileName = "pop.txt";
            txtloader.ShowDialog();

            // Read the population file  
            try
            {
                bfstool.readPopulation(txtloader.FileName);
                pop_read = true;
                if (pop_read)
                {
                    loadmap.Enabled = true;
                    loadmap.BackColor = System.Drawing.Color.YellowGreen;
                }
                loadpop.Enabled = false;
                loadpop.BackColor = System.Drawing.Color.DarkOliveGreen;
                desc.Text = "Graph not yet loaded.";
            }
            catch
            {
                pop_read = false;
                desc.Text = "Error loading population.";
            }
        }

        // Dialogbox Load Map
        private void loadmap_Click(object sender, EventArgs e)
        {
            txtloader.FileName = "map.txt";
            txtloader.ShowDialog();

            // Read the map file  
            try
            {
                bfstool.readMap(txtloader.FileName);
                map_read = true;
                if (map_read && pop_read)
                {
                    renderbutton.Enabled = true;
                    renderbutton.BackColor = System.Drawing.Color.YellowGreen;
                }
                loadmap.Enabled = false;
                loadmap.BackColor = System.Drawing.Color.DarkOliveGreen;
                desc.Text = "Graph not yet loaded.";
            }
            catch
            {
                desc.Text = "Error loading map.";
                map_read = false;
            }
        }

        // Event Tombol Reset Ditekan
        private void resetbutton_Click(object sender, EventArgs e)
        {
            // Reset semua Value
            resetbutton.BackColor = System.Drawing.Color.DarkOliveGreen;
            pop_read = false;
            map_read = false;
            loadpop.Enabled = true;
            loadpop.BackColor = System.Drawing.Color.YellowGreen;
            loadmap.Enabled = false;
            renderbutton.Enabled = false;
            ndays.Value = 0;
            ndays.Enabled = false;
            picbox.Image = null;
            desc.Visible = true;

            // Reset bfstool
            bfstool = new BFSer();
        }


        // Event Perubahan nilai ndays
        private void ndays_ValueChanged(object sender, EventArgs e)
        {
            RenderGraph();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Page = "home";
            Properties.Settings.Default.MainForm_Location = this.Location;
            Close();
        }
    }
}

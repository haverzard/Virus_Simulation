using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;

class GraphViewer
{
    public static void Main()
    {
        //create a form 
        System.Windows.Forms.Form form = new System.Windows.Forms.Form();
        //create a viewer object 
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        //create a graph object 
        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

        string line;
        char[] v1 = null;
        char[] v2 = null;
        char[] blank = null;

        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader(@"graph.txt");
        //line = file.ReadLine();
        v1 = new char[1];
        int count;
        int i = 0;
        file.Read(v1, 0, v1.Length);
        Console.WriteLine(v1);
        count = v1[0] - '0';

        while (i < count)
        {
            line = file.ReadLine();
            v1 = new char[1];
            file.Read(v1, 0, v1.Length);
            blank = new char[1];
            file.Read(blank, 0, blank.Length);
            v2 = new char[1];
            file.Read(v2, 0, v2.Length);
            Console.Write(v1);
            Console.WriteLine(v2);

            graph.AddEdge(Char.ToString(v1[0]), Char.ToString(v2[0])).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;

            i++;
        }

        file.Close();

        //create the graph content 
        viewer.Graph = graph;
        //associate the viewer with the form 
        form.SuspendLayout();
        viewer.Dock = System.Windows.Forms.DockStyle.Fill;
        form.Controls.Add(viewer);
        form.ResumeLayout();
        //show the form 
        form.ShowDialog();
    }
}

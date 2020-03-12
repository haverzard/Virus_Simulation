using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;

namespace VirusSimulation
{
    public class Node
    {
        // Object Members
        private string name;
        private int population;
        private int infectedTime;
        private SortedList adjacentNodes;
        private string infecter;
        List<KeyValuePair<string, int>> infecters;

        // Constructor
        public Node(string x, int y)
        {
            name = x;
            population = y;
            infectedTime = Int32.MaxValue;
            adjacentNodes = new SortedList();
            infecter = "-";
            infecters = new List<KeyValuePair<string, int>>();
        }

        // Setter
        public void SetName(string _name) { name = _name; }
        public void SetInfectedTime(int _infectedTime) { infectedTime = _infectedTime; }
        public void SetPopulation(int _population) { population = _population; }
        public void SetInfecter(string _infecter) { infecter = _infecter; }
        public void AddInfecters(string _infecter, int days) {
            bool exists = false;
            foreach (var pair in infecters){
                if (pair.Key == _infecter) {
                    exists = true;
                }
            }
            if (!exists) {
                infecters.Add(new KeyValuePair<string, int>(_infecter, days));
            }
        }

        // Getter
        public string GetName() { return name; }
        public int GetInfectedTime() { return infectedTime; }
        public int GetPopulation() { return population; }
        public string GetInfecter() { return infecter; }
        public List<KeyValuePair<string, int>> GetInfecters() { return infecters; }
        public List<string> GetAdjacents()
        {
            List<string> t = new List<string>();
            foreach (DictionaryEntry pair in adjacentNodes)
            {
                t.Add((string)pair.Key);
            }
            return t;
        }

        // Add new adjacent node
        public void AddAdjacents(string _name, double _infectedChance)
        {
            adjacentNodes.Add(_name, _infectedChance);
        }

        // Calculate I(x,t(x))
        public double I(int days)
        {
            return population / (1 + (population - 1) * Math.Exp(-0.25 * (days - infectedTime)));
        }

        // Calculate S(infecter,target)
        public double Spread(string _name, int days)
        {
            // Check if exists
            if (adjacentNodes.ContainsKey(_name))
            {
                // The Equation from Specification
                return I(days) * (double)adjacentNodes[_name];
            }
            else return -1;
        }

        // Calculate t when S(infecter,target) > 1
        public double SpreadDay(string _name)
        {
            // Check if exists
            if (adjacentNodes.ContainsKey(_name))
            {
                // Solve t for f(t) = (P(infecter) * Tr(infecter,target)) / (1 + P(infecter) * e^(-0.25*t)) = 1
                // using its inverse t = -0.25 * ln((P(infecter) * Tr(infecter,target - 1) / (P(infecter) - 1))
                return Math.Log(((double)adjacentNodes[_name] * population - 1) / (population - 1)) / (-0.25);
            }
            else return -1;
        }
    }

    public class BFSer
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        // Global Nodes of Cities
        Dictionary<string, Node> Nodes = new Dictionary<string, Node>();

        // Global Queue for BFS implementation
        Queue<string> InfectionProgress = new Queue<string>();

        // Graph view for GUI
        Graph graph = new Graph("graph");

        // Edges memory for GUI
        Dictionary<string, List<KeyValuePair<string, Edge>>> EdgeDict = new Dictionary<string, List<KeyValuePair<string, Edge>>>();

        // Menambah Node City dan menginisialisasi EdgeDict untuk City yang bersangkutan
        public void initEdgeDict(string city) {
            Microsoft.Msagl.Drawing.Node cnode = graph.AddNode(city);
            cnode.Attr.Shape = Shape.Circle;
            EdgeDict.Add(city, new List<KeyValuePair<string, Edge>>());
        }

        // Menambah Edge dari from ke to dan menyimpan di EdgeDict (utk GUI)
        public void addEdgeDict(string from, string to) {
            Edge e = graph.AddEdge(from, to);
            EdgeDict[from].Add(new KeyValuePair<string, Edge>(to, e));
        }

        // Membaca config map dari filename
        public void readMap(string filename)
        {
            System.IO.StreamReader f = new System.IO.StreamReader(filename);
            string ln;
            // Check if the file is not empty
            if ((ln = f.ReadLine()) == null)
            {
                System.ArgumentException e = new System.ArgumentException("Bad input file", filename);
                throw e;
            }
            // Read the total count of connections
            int n = int.Parse(ln);
            // Read all the connections and their spreading rate
            for (int i = 0; i < n; i++)
            {
                ln = f.ReadLine();
                string[] y = ln.Split(' ');
                double ch = double.Parse(y[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                string city1 = y[0];
                string city2 = y[1];
                
                Nodes[city1].AddAdjacents(city2, ch);
                addEdgeDict(city1, city2);
            }
        }

        // Membaca config population dari filename
        public void readPopulation(string filename)
        {
            
            System.IO.StreamReader f = new System.IO.StreamReader(filename);
            string ln;
            // Check if the file is not empty
            if ((ln = f.ReadLine()) == null)
            {
                System.ArgumentException e = new System.ArgumentException("Bad input file", filename);
                throw e;
            }
            // Read the first line (number of cities, infecter)
            string[] x = ln.Split(' ');
            int n = int.Parse(x[0]);
            // Read all cities' population
            for (int i = 0; i < n; i++)
            {
                ln = f.ReadLine();
                string[] y = ln.Split(' ');
                int p = int.Parse(y[1]);
                string city = y[0];
                Nodes.Add(city, new Node(city, p));
                initEdgeDict(city);
            }
            // Set the spreading time for the infecter
            Nodes[x[1]].SetInfectedTime(0);
            // Add the infecter
            InfectionProgress.Enqueue(x[1]);
        }

        // Kode BFS utama
        public void DoBFS(int rdays)
        {
            // Start the spread until nothing can be infected or the remaining days is 0
            while (InfectionProgress.Count > 0)
            {
                // Take infecter city
                string infecter = InfectionProgress.Dequeue();
                // Get all adjacent cities
                List<string> adj = Nodes[infecter].GetAdjacents();
                // Iterate all target cities from the infecter city
                foreach (string target in adj)
                {
                    // If S(infecter,target) > 1, spread succeeds
                    if (Nodes[infecter].Spread(target, rdays) > 1)
                    {
                        int days = (int)Math.Ceiling(Nodes[infecter].SpreadDay(target));

                        // History
                        Nodes[target].AddInfecters(infecter, days + Nodes[infecter].GetInfectedTime());
                        
                        if (days == Nodes[infecter].SpreadDay(target)) days += 1;
                        // Check if the new spreading time is better than before
                        // and add the infected target's infecter
                        // also add the infected target as new infecter for later
                        if ((days + Nodes[infecter].GetInfectedTime()) < Nodes[target].GetInfectedTime())
                        {
                            Nodes[target].SetInfectedTime(days + Nodes[infecter].GetInfectedTime());
                            Nodes[target].SetInfecter(infecter);
                            InfectionProgress.Enqueue(target);
                            
                        }
                    }
                }
            }

            foreach (var n in getNodes()) {
                Console.Write("Success " + n + " " + Nodes[n].GetInfectedTime() + " by ");
                Nodes[n].GetInfecters().ForEach(i => Console.Write(i.Key + "-" + i.Value + " "));
                Console.WriteLine();
            }

        }

        // Mengembalikan semua kota yang ada
        public List<string> getNodes () {
            List<string> res = new List<string>();
            foreach (var pair in Nodes)
            {
                res.Add(pair.Key);
            }
            return res;
        }

        // Mengembalikan list kota dan waktu terinfeksinya
        public List<KeyValuePair<string, double>> getInfections()
        {
            List<KeyValuePair<string, double>> res = new List<KeyValuePair<string, double>>();
            foreach (var pair in Nodes)
            {
                res.Add(new KeyValuePair<string, double> (pair.Key, Nodes[pair.Key].GetInfectedTime()));
            }
            return res;
        }

        // Mengembalikan kota n
        public Node getNode(string n) {
            return Nodes[n];
        }

        // Mengembalikan Edge yang menghubungkan from-to
        public Edge getEdge(string from, string to)
        {
            var v = EdgeDict[from].FirstOrDefault(pair => pair.Key == to);
            return v.Value;
        }

        public Graph getGraph() { return graph; }
    }


}
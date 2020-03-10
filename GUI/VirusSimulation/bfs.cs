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
        private char name;
        private int population;
        private int infectedTime;
        private SortedList adjacentNodes;
        private char infecter;
        List<KeyValuePair<char, int>> infecters;

        // Constructor
        public Node(char x, int y)
        {
            name = x;
            population = y;
            infectedTime = Int32.MaxValue;
            adjacentNodes = new SortedList();
            infecter = '-';
            infecters = new List<KeyValuePair<char, int>>();
        }

        // Setter
        public void SetName(char _name) { name = _name; }
        public void SetInfectedTime(int _infectedTime) { infectedTime = _infectedTime; }
        public void SetPopulation(int _population) { population = _population; }
        public void SetInfecter(char _infecter) { infecter = _infecter; }
        public void AddInfecters(char _infecter, int days) {
            bool exists = false;
            foreach (var pair in infecters){
                if (pair.Key == _infecter) {
                    exists = true;
                }
            }
            if (!exists) {
                infecters.Add(new KeyValuePair<char, int>(_infecter, days));
            }
        }

        // Getter
        public int GetName() { return name; }
        public int GetInfectedTime() { return infectedTime; }
        public int GetPopulation() { return population; }
        public char GetInfecter() { return infecter; }
        public List<KeyValuePair<char, int>> GetInfecters() { return infecters; }
        public List<char> GetAdjacents()
        {
            List<char> t = new List<char>();
            foreach (DictionaryEntry pair in adjacentNodes)
            {
                t.Add((char)pair.Key);
            }
            return t;
        }

        // Add new adjacent node
        public void AddAdjacents(char _name, double _infectedChance)
        {
            adjacentNodes.Add(_name, _infectedChance);
        }

        // Calculate I(x,t(x))
        public double I(int days)
        {
            return population / (1 + (population - 1) * Math.Exp(-0.25 * (days - infectedTime)));
        }

        // Calculate S(infecter,target)
        public double Spread(char _name, int days)
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
        public double SpreadDay(char _name)
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
        Dictionary<char, Node> Nodes = new Dictionary<char, Node>();

        // Global Queue for BFS implementation
        Queue<char> InfectionProgress = new Queue<char>();

        // Graph view for GUI
        Graph graph = new Graph("graph");

        // Edges memory for GUI
        Dictionary<char, List<KeyValuePair<char, Edge>>> EdgeDict = new Dictionary<char, List<KeyValuePair<char, Edge>>>();

        // Menambah Node City dan menginisialisasi EdgeDict untuk City yang bersangkutan
        public void initEdgeDict(char city) {
            Microsoft.Msagl.Drawing.Node cnode = graph.AddNode(Char.ToString(city));
            cnode.Attr.Shape = Shape.Circle;
            EdgeDict.Add(city, new List<KeyValuePair<char, Edge>>());
        }

        // Menambah Edge dari from ke to dan menyimpan di EdgeDict (utk GUI)
        public void addEdgeDict(char from, char to) {
            Edge e = graph.AddEdge(Char.ToString(from), Char.ToString(to));
            EdgeDict[from].Add(new KeyValuePair<char, Edge>(to, e));
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
                char city1 = y[0][0];
                char city2 = y[1][0];
                
                Nodes[city1].AddAdjacents(city2, ch);
                addEdgeDict(city1, city2);
                //graph.AddEdge(Char.ToString(city1), Char.ToString(city2));
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
                char city = y[0][0];
                Nodes.Add(city, new Node(city, p));
                initEdgeDict(city);
            }
            // Set the spreading time for the infecter
            Nodes[x[1][0]].SetInfectedTime(0);
            // Add the infecter
            InfectionProgress.Enqueue(x[1][0]);
        }

        // Kode BFS utama
        public void DoBFS(int rdays)
        {
            // Start the spread until nothing can be infected or the remaining days is 0
            while (InfectionProgress.Count > 0)
            {
                // Take infecter city
                char infecter = InfectionProgress.Dequeue();
                // Get all adjacent cities
                List<char> adj = Nodes[infecter].GetAdjacents();
                // Iterate all target cities from the infecter city
                foreach (char target in adj)
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
        public List<char> getNodes () {
            List<char> res = new List<char>();
            foreach (var pair in Nodes)
            {
                res.Add(pair.Key);
            }
            return res;
        }

        // Mengembalikan list kota dan waktu terinfeksinya
        public List<KeyValuePair<char, double>> getInfections()
        {
            List<KeyValuePair<char, double>> res = new List<KeyValuePair<char, double>>();
            foreach (var pair in Nodes)
            {
                res.Add(new KeyValuePair<char, double> (pair.Key, Nodes[pair.Key].GetInfectedTime()));
            }
            return res;
        }

        // Mengembalikan kota n
        public Node getNode(char n) {
            return Nodes[n];
        }

        // Mengembalikan Edge yang menghubungkan from-to
        public Edge getEdge(char from, char to)
        {
            var v = EdgeDict[from].FirstOrDefault(pair => pair.Key == to);
            return v.Value;
        }

        public Graph getGraph() { return graph; }
    }


}
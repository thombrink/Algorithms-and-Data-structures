using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph {
    class Program {
        static void Main(string[] args) {
            //Implementeer een graaf-klasse met nodes en edges waarbij je gebruikt maakt van de code uit het boek.
            //Schrijf ook een methode die de graaf als tekst op het scherm zet (een lijst van nodes en bijbehorende edges). 

            var exerciseGraph = new Graph();
            exerciseGraph.AddEdge("V2", "V0", 4);
            exerciseGraph.AddEdge("V2", "V5", 5);

            exerciseGraph.AddEdge("V0", "V1", 2);
            exerciseGraph.AddEdge("V0", "V3", 1);

            exerciseGraph.AddEdge("V1", "V3", 3);
            exerciseGraph.AddEdge("V1", "V4", 10);

            exerciseGraph.AddEdge("V3", "V2", 2);
            exerciseGraph.AddEdge("V3", "V5", 8);
            exerciseGraph.AddEdge("V3", "V6", 4);
            exerciseGraph.AddEdge("V3", "V4", 2);

            exerciseGraph.AddEdge("V6", "V5", 1);

            exerciseGraph.AddEdge("V4", "V6", 6);

            exerciseGraph.Calculate("V2");

            //exerciseGraph.PrintPath("V4");
            //exerciseGraph.PrintPath("V2");
            exerciseGraph.PrintPath("V6");

            Console.WriteLine(exerciseGraph.IsConnected());

            exerciseGraph.AddEdge("V7", "V8", 6);

            Console.WriteLine(exerciseGraph.IsConnected());

            //exerciseGraph.Print();

            var cityGraph = new Graph();
            cityGraph.AddEdge("grafhorst", "kampen", 3);
            cityGraph.AddEdge("grafhorst", "ijsselmuiden", 1);
            cityGraph.AddEdge("grafhorst", "genemuiden", 8);

            cityGraph.AddEdge("ijsselmuiden", "kampen", 1);
            cityGraph.AddEdge("ijsselmuiden", "genemuiden", 10);

            cityGraph.AddEdge("kampen", "genemuiden", 4);

            cityGraph.AddEdge("genemuiden", "ijsselmuiden", 6);

            //cityGraph.Print();

            Console.ReadKey();
        }
    }

    public class Graph {
        private Dictionary<string, Node> nodeMap = new Dictionary<string, Node>();


        public void AddEdge(string sourceName, string destinationName, int cost) {
            Node source = GetNode(sourceName);
            Node destination = GetNode(destinationName);
            source.Edges.Add(new Edge(destination, cost));
        }


        public void Calculate(string startNodeName) {
            Node startNode = GetNode(startNodeName);

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startNode);

            foreach(var node in nodeMap.Values) {
                node.Distance = int.MaxValue;
                node.Previous = null;
            }

            startNode.Distance = 0;

            while (nodeQueue.Any()) {
                var currNode = nodeQueue.Dequeue();

                if (currNode.Processed) continue;
                currNode.Processed = true;

                foreach (var edge in currNode.Edges) {
                    var destination = edge.Destination;
                    var newDistance = currNode.Distance + edge.Cost;

                    //if (destination.Distance == int.MaxValue) {
                    if(newDistance < destination.Distance) {
                        destination.Distance = newDistance;
                        destination.Previous = currNode;

                        nodeQueue.Enqueue(destination);
                    }
                }
            }
        }

        public bool IsConnected() {
            Node startNode = nodeMap.First().Value;

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startNode);

            foreach (var node in nodeMap.Values) {
                node.Distance = int.MaxValue;
                node.Previous = null;
            }

            while (nodeQueue.Any()) {
                var currNode = nodeQueue.Dequeue();

                if (currNode.Processed) continue;
                currNode.Processed = true;

                foreach (var edge in currNode.Edges) {
                    var destination = edge.Destination;

                    if (destination.Distance == int.MaxValue) {
                        nodeQueue.Enqueue(destination);
                    }
                }
            }

            return nodeMap.All(x => x.Value.Processed);
        }

        private Node GetNode(string name) {
            Node result;
            if (nodeMap.ContainsKey(name)) {
                result = nodeMap[name];
            }
            else {
                result = new Node(name);
                nodeMap.Add(name, result);
            }
            return result;
        }

        public void Print() {
            var sb = new StringBuilder();
            foreach(var node in nodeMap) {
                sb.AppendLine(node.Key);

                foreach(var edge in node.Value.Edges) {
                    sb.AppendLine("- " + edge.Destination.Name);
                }

                sb.AppendLine();
            }
            Console.Write(sb.ToString());
        }

        internal void PrintPath(string endNodeName) {
            var endNode = GetNode(endNodeName);

            if (endNode.Previous != null) {
                PrintPath(endNode.Previous.Name);
            }

            Console.WriteLine(endNode.Name);
        }
    }

    public class Node {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; } = new List<Edge>();
        public int Distance { get; set; }
        public Node Previous { get; set; }
        public bool Processed { get; set; }

        public Node(string name){
            Name = name;
        }
    }

    public class Edge {
        public Node Destination { get; set; }
        public int Cost { get; set; }

        public Edge(Node destination, int cost) {
            Destination = destination;
            Cost = cost;
        }
    }
}

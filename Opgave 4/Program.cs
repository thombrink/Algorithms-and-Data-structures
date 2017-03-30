using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_4 {
    class Program {
        static void Main(string[] args) {
            var graph = new Graph();
            graph.VulAfstand();
            graph.ToonAfstand();

            Console.WriteLine(graph.HasCycle("E"));
            Console.WriteLine(graph.HasCycle("K"));

            graph.ToonCycles();

            Console.ReadKey();
        }
    }

    public class Graph {
        private List<Node> _nodes = new List<Node>();

        public Graph() {
            var a = GetNode("A");
            var b = GetNode("B");
            var c = GetNode("C");
            var d = GetNode("D");
            var e = GetNode("E");
            var f = GetNode("F");
            var g = GetNode("G");
            var h = GetNode("H");
            var k = GetNode("K");


            a.Edges.Add(new Edge(b, 1));
            a.Edges.Add(new Edge(g, 1));

            c.Edges.Add(new Edge(b, 1));

            d.Edges.Add(new Edge(f, 1));
            d.Edges.Add(new Edge(g, 1));

            e.Edges.Add(new Edge(c, 1));

            f.Edges.Add(new Edge(f, 1));

            g.Edges.Add(new Edge(d, 1));
            g.Edges.Add(new Edge(f, 1));
            g.Edges.Add(new Edge(h, 1));

            h.Edges.Add(new Edge(e, 1));
            h.Edges.Add(new Edge(k, 1));

            k.Edges.Add(new Edge(g, 1));

            _nodes.Add(a);
            _nodes.Add(b);
            _nodes.Add(c);
            _nodes.Add(d);
            _nodes.Add(e);
            _nodes.Add(f);
            _nodes.Add(g);
            _nodes.Add(h);
            _nodes.Add(k);
        }

        private Node GetNode(string nodeName) {
            return _nodes.FirstOrDefault(x => x.Name == nodeName) ?? new Node(nodeName);
        }

        public void VulAfstand() {
            var startNode = GetNode("G");

            foreach (var node in _nodes) {
                node.Distance = int.MaxValue;
                node.Processed = false;
            }

            startNode.Distance = 0;
            startNode.Processed = true;

            var queue = new Queue<Node>();
            queue.Enqueue(startNode);

            Node currNode;
            while(queue.Count > 0) {
                currNode = queue.Dequeue();

                foreach (var edge in currNode.Edges) {
                    var newDistance = currNode.Distance + edge.Cost;
                    var destination = edge.Destination;

                    destination.Processed = true;

                    if (destination.Distance > newDistance) {
                        destination.Distance = newDistance;

                        queue.Enqueue(destination);
                    }    
                }
            }
        }

        public void ToonAfstand() {
            foreach(var node in _nodes) {
                if (node.Name == "G") continue;

                Console.WriteLine($"{node.Name}: {(node.Distance == int.MaxValue ? -1 : node.Distance)}");
            }
        }

        public bool HasCycle(string nodeName) {
            var startNode = GetNode(nodeName);

            foreach (var node in _nodes) {
                node.Processed = false;
            }

            startNode.Processed = true;

            var queue = new Queue<Node>();
            queue.Enqueue(startNode);

            Node currNode;
            while (queue.Count > 0) {
                currNode = queue.Dequeue();

                foreach (var edge in currNode.Edges) {
                    var destination = edge.Destination;

                    if (destination.Name == nodeName) {
                        return true;
                    }

                    if (!destination.Processed) {
                        queue.Enqueue(destination);
                        destination.Processed = true;
                    }
                }
            }

            return false;
        }

        public void ToonCycles() {
            foreach (var node in _nodes) {
                Console.WriteLine($"{node.Name}: {HasCycle(node.Name)}");
            }
        }


        public class Node {
            public string Name { get; set; }
            public List<Edge> Edges { get; set; } = new List<Edge>();
            public int Distance { get; set; }
            public Node Previous { get; set; }
            public bool Processed { get; set; }

            public Node(string name) {
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
}

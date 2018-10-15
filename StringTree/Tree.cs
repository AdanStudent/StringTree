using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTree
{
    class Tree
    {
        //Root Node
        public Node root;

        //temp node used to keep track of the last node in case it needs to be used 
        private Node tempNode;

        public bool IsReady { get; private set; }

        public Tree(string _fileName)
        {
            root = new Node("root", 0);

            IsReady = LoadText(_fileName);
        }

        public bool LoadText(string fileName)
        {
            string[] lines;
            try
            {
                //Convert Text File to a String Array 
                lines = File.ReadAllLines(fileName);

            }
            catch (Exception)
            {
                Console.WriteLine("File Name was not Vaild");
                throw;
            }

            int count = 0; //keeps track of depth
            int parentCount = 0;

            //holds on to the list of 
            List<Node> nodesToBeAdded = new List<Node>();

            //going through each specific line
            for (int i = 0; i < lines.Length; i++)
            {
                //stores string line
                string temp = lines[i];

                for (int j = 0; j <= temp.Length; j++)
                {
                    //this is a check for depth
                    if (temp[j].Equals(' '))
                    {
                        count++;
                    }
                    else if (temp[j].Equals('\t'))
                    {
                        count += 8; //1 tab = 8 empty spaces
                    }
                    else
                    {
                        break; //breaks out of for loop thats checking each char
                    }
                }


                if (parentCount == 0) // if it's count of whitespace was 0 then add set the tempNode to the root
                {
                    tempNode = root;
                }

                if (count != parentCount)
                {
                    AddNodesToTree(nodesToBeAdded); //add nodes in list to the tree

                    if (root.children[0] != null)
                    {
                        tempNode = nodesToBeAdded[nodesToBeAdded.Count - 1]; //keep a reference of the last node added
                    }
                    nodesToBeAdded.Clear(); //clear the list
                }

                temp = temp.TrimStart('\t');
                AddNodeToList(count, nodesToBeAdded, temp); // add node to the list with its info

                parentCount = count;
                count = 0; //reset whitespace counter
            }

            AddNodesToTree(nodesToBeAdded);//Add last of the nodes
            //check for IO errors and other exceptions
            return true;

        }

        //Addes a specific node to the list
        private void AddNodeToList(int count, List<Node> nodesToBeAdded, string temp)
        {
            nodesToBeAdded.Add(new Node(temp, count));
            
        }

        //Addes the list of nodes to the tree
        private void AddNodesToTree(List<Node> _siblings)
        {
            foreach (var sib in _siblings)
            {
                //Add To Tree
                tempNode.AddNode(sib);
            }

        }
            //returns empty list or all 
            //matching node instances
        public void WriteOutlineFile(Node Parent)
        {

            using(StreamWriter file = new StreamWriter(@"C:\workspace\Tree.txt"))
	        {
                if (Parent.children[0] == null)
                {
                    return;
                }
                foreach (var child in Parent.children)
                {
                    if (child != null)
                    {
                        file.WriteLine(child.ToString());
                        WriteOutlineFile(child);
                    }
                }
	        }
        }


        //Implement a "GetLeaves" method that returns a List<YourNodeClass>
        public List<Node> GetLeaves(Node Parent)
        {
            List<Node> Leaves = new List<Node>();

            if (Parent.isItALeaf)
            {
                Leaves.Add(Parent);
                return Leaves;
            }
            else
            {
                foreach (var child in Parent.children)
                {
                    if (child != null)
                    {
                        Leaves.AddRange(GetLeaves(child));
                    }
                }

                return Leaves;
            }

        }

        //Implement "GetInternalNodes" that returns a list of List<YourNodeClass> nodes that are not parents and not leaves.  (Might be empty!)
        public List<Node> GetInternalNodes(Node Parent)
        {
            List<Node> Internal = new List<Node>();

            if (!Parent.isItALeaf && !Parent.isParent)
            {
                Internal.Add(Parent);
                return Internal;
            }
            else
            {
                foreach (var child in Parent.children)
                {
                    if (child != null)
                    {
                        Internal.AddRange(GetLeaves(child));
                    }
                }

                return Internal;
            }
        }

    }
}

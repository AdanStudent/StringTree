using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTree
{
    class Node
    {
        //needs 3 other Child Nodes
        public Node [] children;

        //check when adding Child Nodes if those Nodes are all filled
        private bool isFilled;

        //Stores depth of node
        public int depth;

        //Stores String
        public string nodeInfo;

        //constructor
        public Node()
        {
            //children = new Node[3];
        }


        //Traverse
        

        public void AddNode(Node newNode)
        {
            //checks if all children nodes are filled
            if (!isFilled)
            {
                //walks through all childer until an empty one is found
                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] == null)
                    {
                        children[i] = newNode;

                        //if this is the last child to be filled change this Node's isFill to true
                        if (i > 2)
                        {
                            isFilled = true;
                        }
                    }
                }
            }

        }//end of AddNode
    }
}

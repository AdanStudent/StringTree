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
        public Node(String _info, int _depth)
        {
            this.nodeInfo = _info;
            this.children = new Node[3];
            this.depth = _depth;
        }


        //Traverse
        

        public void AddNode(Node newNode)
        {
            //check if children are full
            if (!this.isFilled && newNode.depth == 0)
            {
                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] == null)
                    {
                        children[i] = newNode;
                        break;
                    }
                }
            }
            else
            {
                newNode.depth -= 7;
                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] != null)
                    {
                        this.children[i].AddNode(newNode);
                        break;
                    }
                }
            }

            if (children[children.Length - 1] != null)
            {
                isFilled = true;
            }

        }//end of AddNode
    }
}

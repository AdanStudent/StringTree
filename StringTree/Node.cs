using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTree
{
    class Node
    {
        //needs Child Nodes
        public Node [] children;
        //keeping reference of its parent
        private Node _parent;

        //keeping reference if its a parent or a leaf
        public bool isParent;
        public bool isItALeaf;

        //Stores depth of node
        private int _depth;

        //Stores String
        public string nodeInfo;

        //constructor
        public Node(String _info, int depth)
        {
            this.nodeInfo = _info;
            this.children = new Node[10];
            this._depth = depth;
        }

        public void AddNode(Node newNode)
        {
            //check if children are full
            if (newNode._depth <= 0)
            {
                for (int i = 0; i < this.children.Length; i++)
                {
                    if (this.children[i] == null) //if this child is empty
                    {
                        newNode._parent = this; //keep a reference of its parent
                        newNode.isItALeaf = true; //is currently a leaf
                        this.children[i] = newNode; // add the node as a child
                        this.isItALeaf = false; // after adding a child it is no longer a leaf
                        break;
                    }
                }
            }
            else
            {
                this.isParent = true;
                newNode._depth -= 8; //decrease its "depth"
                newNode.nodeInfo = "        " + newNode.nodeInfo;
                this.AddNode(newNode); //calling addNode here makes this a parent of the node being passed in
            }

        }//end of AddNode

        public override string ToString()
        {
            return this.nodeInfo;
        }
    }
}

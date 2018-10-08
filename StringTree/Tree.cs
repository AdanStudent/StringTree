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
        Node root;

        public bool IsReady { get; private set; }

        public Tree(string _fileName)
        {
            root = new Node("");

            IsReady = LoadText(_fileName);
        }

        public bool LoadText(string fileName)
        {
            //Convert Text File to a String Array 
            string[] lines = File.ReadAllLines(fileName);

            //going through each specific line
            for (int i = 0; i < lines.Length; i++)
            {
                //stores string line
                string temp = lines[i];
                int count = 0; //keeps track of depth

                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[i].Equals(' ') || temp[i].Equals('\t'))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                //Add To Tree
                root.AddNode(new Node(temp));
                
            }
            //check for IO errors and other exceptions
            return false;

        }
    }
}

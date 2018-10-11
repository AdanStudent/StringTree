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
            root = new Node("", 0);

            IsReady = LoadText(_fileName);
        }

        public bool LoadText(string fileName)
        {
            //Convert Text File to a String Array 
            string[] lines = File.ReadAllLines(fileName);

            int count = 0; //keeps track of depth

            //going through each specific line
            for (int i = 0; i < lines.Length; i++)
            {
                //stores string line
                string temp = lines[i];

                for (int j = 0; j < temp.Length; j++)
                {
                    //this is a check for depth
                    if (temp[j].Equals(' '))
                    {
                        count++;
                    }
                    else if (temp[j].Equals('\t'))
                    {
                        count += 7; //1 tab = 8 empty spaces
                    }
                    else
                    {
                        break; //breaks out of for loop thats checking each char
                    }
                }

                //Add To Tree
                root.AddNode(new Node(temp, count));
                count = 0;
            }
            //check for IO errors and other exceptions
            return false;

        }

        private void CheckForDepth(string line, int position)
        {

        }
    }
}

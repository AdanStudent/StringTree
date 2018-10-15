using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTree
{
    class Program
    {
        static void Main(string[] args)
        {

            Tree stringTree = new Tree(@"C:\Users\Adan\Desktop\treeTestData\people.txt");

            List<Node> Leafs = stringTree.GetLeaves(stringTree.root);

            List<Node> Internal = stringTree.GetInternalNodes(stringTree.root);

            stringTree.WriteOutlineFile(stringTree.root);

            Console.ReadKey();
        }
    }
}

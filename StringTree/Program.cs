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
            string fileName;
            Tree tree = null;
            Console.WriteLine(String.Format("Please Enter 0: To Read In a File\n" +
                                            "Enter 1: To Retrieve The Leaves\n" +
                                            "Enter 2: To Retrieve All Internal Nodes\n" +
                                            "Enter 3: To Write Out The Tree To a Txt\n" +
                                            "Enter 4: Exit Program\n"));
            bool running = true;
            while (running)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Please Enter File Location");
                        fileName = Console.ReadLine();
                        tree = new Tree(fileName);
                        break;

                    case "1":
                        try
                        {
                            List<Node> Leafs = tree.GetLeaves(tree.root);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Read in File first");
                            
                        }
                        break;

                    case "2":
                        try
                        {
                            List<Node> Internal = tree.GetInternalNodes(tree.root);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Read in File first");
                            
                        }
                        break;

                    case "3":
                        try
                        {
                            tree.WriteOutlineFile(tree.root);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Read in File first");
                            
                        }
                        break;

                    case "4":
                        Console.WriteLine("Exiting Program");
                        running = false;
                        break;

                    default:
                        break;
                }
            }

        }
    }
}

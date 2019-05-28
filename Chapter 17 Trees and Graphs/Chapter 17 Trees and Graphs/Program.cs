using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_17_Trees_and_Graphs
{

    #region Class
    /// <summary>
    /// Tree data structure.
    /// </summary>
    /// <typeparam name="T">Type of the values of the tree.</typeparam>
    public class Tree<T> where T : IComparable, IComparable<T>
    {
        #region Fields
        private TreeNode<T> root = null;
        #endregion

        #region Constructors
        public Tree(T value)
        {
            this.root = new TreeNode<T>(value);
        }
        public Tree(T value, params Tree<T>[] trees) : this(value)
        {
            if (trees == null)
                return;
            foreach(Tree<T> tree in trees)
            {
                this.root.AddChild(tree.root);
            }
        }
        public Tree(TreeNode<T> node)
        {
            this.root = node ?? throw new NullReferenceException();
        }
        #endregion

        #region Properties
        public bool IsEmpty { get { return this.root == null; } }
        public TreeNode<T> Root { get { return this.root; } }
        #endregion

        #region Methods
        public int FindOcurrencesOfValue(T value)
        {
            int result = 0;
            result = FindOccurencesInNodesDFS(this.root, value);
            return result;
        }
        private int FindOccurencesInNodesDFS(TreeNode<T> node, T value)
        {
            int result = 0;

            if (node.Value.CompareTo(value) == 0)
                result = 1;

            foreach(TreeNode<T> child in node.Childs)
            {
                result += FindOccurencesInNodesDFS(child, value);
            }
            return result;
        }

        public Tree<T>[] GetSubTreesRootWithNChildsNodes(int childsNodesNumber)
        {
            int result = 0;
            List<Tree<T>> subTreesWithNChildsNodes = new List<Tree<T>>();
            Stack<TreeNode<T>> nodesLeft = new Stack<TreeNode<T>>();
            nodesLeft.Push(this.root);
            while(nodesLeft.Count != 0)
            {
                TreeNode<T> currentNode = nodesLeft.Pop();
                result = this.HasChildsNumber(currentNode, childsNodesNumber);
                if(result == -1)
                {
                    //Not enough childs in sub-trees, so we continue on siblings.
                    continue;
                }
                else if(result == 1)
                {
                    foreach(TreeNode<T> child in currentNode.Childs)
                    {
                        nodesLeft.Push(child);
                    }
                }
                else
                {
                    subTreesWithNChildsNodes.Add(new Tree<T>(currentNode));
                }
            }

            return subTreesWithNChildsNodes.ToArray();
        }

        private int HasChildsNumber(TreeNode<T> node, int childsNumber)
        {
            int childs = 0;
            Stack<TreeNode<T>> nodesLeft = new Stack<TreeNode<T>>();
            nodesLeft.Push(node);
            while(childs <= childsNumber && nodesLeft.Count != 0)
            {
                TreeNode<T> currentNode = nodesLeft.Pop();
                childs += currentNode.ChildrenCount;
                foreach(TreeNode<T> child in currentNode.Childs)
                {
                    nodesLeft.Push(child);
                }
            }


            if (childs < childsNumber)
            {
                Console.WriteLine("Node " + node.Value + " has " + childs + " childs in total.");
                return -1;
            }
            else if (childs > childsNumber)
            {
                Console.WriteLine("Node " + node.Value + " has more than " + childs + " childs in total.");
                return 1;
            }
            else
            {
                Console.WriteLine("Node " + node.Value + " has exactly " + childs + " childs in total.");
                return 0;
            }
        }

        // --- DFS ---
        public void PrintDFS()
        {
            this.TraversalPrintDFS(this.root, "");
        }

        private void TraversalPrintDFS(TreeNode<T> node, string indentation)
        {
            foreach (TreeNode<T> child in node.Childs)
            {
                TraversalPrintDFS(child, indentation + "    ");
            }

            //Print Node value
            Console.WriteLine(indentation + node.Value.ToString());
        }

        private void TraversalDFS(TreeNode<T> node, Action<TreeNode<T>> callback)
        {
            callback?.Invoke(node);
            foreach(TreeNode<T> child in node.Childs)
            {
                this.TraversalDFS(child, callback);
            }
        }

        // --- BFS ---
        public void PrintBFS()
        {
            this.TraversalPrintBFS(this.root);
        }

        private void TraversalPrintBFS(TreeNode<T> root)
        {
            string indentation = "";
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            Stack<string> indentations = new Stack<string>();
            stack.Push(root);
            indentations.Push(indentation);

            while(stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();
                indentation = indentations.Pop();
                if (node.ChildrenCount != 0)
                {
                    foreach (TreeNode<T> child in node.Childs)
                    {
                        stack.Push(child);
                        indentations.Push(indentation + "    ");
                    }
                }

                Console.WriteLine(indentation + node.Value);
            }
        }

        #endregion
    }

    /// <summary>
    /// Tree node for the tree data structure.
    /// </summary>
    /// <typeparam name="T">Type of value contained in the node.</typeparam>
    public class TreeNode<T> where T : IComparable, IComparable<T>
    {
        #region Fields
        private bool hasParent = false;

        private T value = default(T);

        private List<TreeNode<T>> childs = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs the tree node.
        /// </summary>
        /// <param name="value">Value to set in the node.</param>
        public TreeNode(T value) 
        {
            this.hasParent = false;
            this.value = value;
            this.childs = new List<TreeNode<T>>();
        }
        #endregion

        #region Properties
        public T Value { get { return this.value; } }
        public int ChildrenCount { get { return this.childs.Count; } }
        public TreeNode<T>[] Childs { get { return this.childs.ToArray(); } }
        #endregion

        #region Methods
        /// <summary>
        /// Add a child on the node.
        /// </summary>
        /// <param name="child">The child to add.</param>
        public void AddChild(TreeNode<T> child)
        {
            if(child == null)
            {
                throw new ArgumentNullException("The node reference is null ref");
            }
            if(child.hasParent)
            {
                throw new InvalidOperationException("Child node already has a parent !");
            }

            child.hasParent = true;
            this.childs.Add(child);
        }

        /// <summary>
        /// Return a child at <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the child to get..</param>
        /// <returns>Child at given idnex.</returns>
        public TreeNode<T> GetChild(int index)
        {
            if(index < 0 || index >= this.childs.Count)
            {
                throw new IndexOutOfRangeException("Node have " + this.childs.Count + " childs, not " + index);
            }

            return this.childs[index];
        }
        #endregion
    }
    #endregion


    public class Program
    {
        static void Main(string[] args)
        {
            //Exo1.Execute();
            Exo2.Execute();
        }
    }

    /// <summary>
    /// Write a program that finds the number of occurrences of a number in a tree of numbers.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Random random = new Random();
            
            Tree<int> integerTree = 
                            new Tree<int>(random.Next(0, 10),
                                new Tree<int>(random.Next(0, 10),
                                    new Tree<int>(random.Next(0, 10)),
                                    new Tree<int>(random.Next(0, 10)),
                                    new Tree<int>(random.Next(0, 10)),
                                    new Tree<int>(random.Next(0, 10))),
                                new Tree<int>(random.Next(0, 10),
                                    new Tree<int>(random.Next(0, 10),
                                        new Tree<int>(random.Next(0, 10)))));

            //integerTree.PrintDFS();
            integerTree.PrintBFS();

            int number = random.Next(0, 10);
            int occurences = integerTree.FindOcurrencesOfValue(number);

            Console.WriteLine(number + " occurs " + occurences + " times in the tree !");
        }
    }

    /// <summary>
    /// Write a program that displays the roots of those sub-trees of a tree, which have exactly k nodes, where k is an integer.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Random random = new Random();

            Tree<int> integerTree =
                            new Tree<int>(random.Next(0, 10),
                                new Tree<int>(random.Next(0, 10),
                                    new Tree<int>(random.Next(0, 10)),
                                    new Tree<int>(random.Next(0, 10)),
                                    new Tree<int>(random.Next(0, 10)),
                                    new Tree<int>(random.Next(0, 10))),
                                new Tree<int>(random.Next(0, 10),
                                    new Tree<int>(random.Next(0, 10),
                                        new Tree<int>(random.Next(0, 10)))));

            //integerTree.PrintDFS();
            integerTree.PrintBFS();

            Console.Write("Display the roots of the sub-trees which have exactly k nodes where k = ");
            int k = int.Parse(Console.ReadLine());

            Tree<int>[] subTrees = integerTree.GetSubTreesRootWithNChildsNodes(k);
            if(subTrees != null && subTrees.Length != 0)
            {
                foreach(Tree<int> subTree in subTrees)
                {
                    Console.WriteLine("Root node : " + subTree.Root.Value.ToString());
                }
            }
            else
            {
                Console.WriteLine("Couldn't find a root node with " + k + " child nodes in total.");
            }
        }
    }
}

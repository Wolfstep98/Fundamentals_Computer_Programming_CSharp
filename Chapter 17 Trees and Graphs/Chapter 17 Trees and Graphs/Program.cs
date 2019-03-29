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
        #endregion

        #region Properties
        public bool isEmpty { get { return this.root == null; } }
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

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_17_Trees_and_Graphs
{

    #region Class
    /// <summary>
    /// Tree data structure.
    /// </summary>
    /// <typeparam name="T">Type of the values of the tree.</typeparam>
    public class Tree<T>
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
    }

    /// <summary>
    /// Tree node for the tree data structure.
    /// </summary>
    /// <typeparam name="T">Type of value contained in the node.</typeparam>
    public class TreeNode<T>
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
            
        }
    }

    /// <summary>
    /// Write a program that finds the number of occurrences of a number in a tree of numbers.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            
        }
    }
}

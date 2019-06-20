using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_17_Trees_and_Graphs
{
    #region Class

    // --- Tree Template ---
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

        // --- Leaves ---
        public int GetNumberOfLeaves()
        {
            if (this.root == null)
                throw new MissingFieldException("Root is missing !");
            return this.root.GetLeaves();
        }
        public int GetNumberOfNodes()
        {
            return this.root.GetChildsNodeNumber();
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

        public int GetLeaves()
        {
            if (this.childs.Count == 0)
                return 1;
            else
            {
                int leaves = 0;
                foreach(TreeNode<T> child in this.childs)
                {
                    leaves += child.GetLeaves();
                }
                return leaves;
            }
        }

        public int GetChildsNodeNumber()
        {
            if (this.childs.Count == 0)
                return 1;
            else
            {
                int childNodes = 0;
                foreach(TreeNode<T> child in this.childs)
                {
                    childNodes += child.GetChildsNodeNumber();
                }
                return childNodes + 1;
            }
        }
        #endregion
    }

    // --- Binary Tree Template ---
    public class BinaryTree<T>
    {
        #region Fields
        private T value;
        private BinaryTree<T> leftChild;
        private BinaryTree<T> rightChild;
        #endregion

        #region Constructors
        public BinaryTree(T value) : this(value, null, null)
        {
            
        }
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
        #endregion

        #region Properties
        public T Value { get { return this.value; } }
        public BinaryTree<T> LeftChild { get { return this.leftChild; } }
        public BinaryTree<T> RightChild { get { return this.rightChild; } }
        #endregion

        #region Methods
        public int GetDepthsSums()
        {
            int maxDepth = this.GetMaxDepth();
            int[] depthsSums = new int[maxDepth];
            
            int nodeLeft = 1;
            int depth = 0;
            int sum = 0;
            string currentIndentation = "";
            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>(10);
            queue.Enqueue(this);

            while(queue.Count != 0)
            {
                BinaryTree<T> currentTree = queue.Dequeue();
                nodeLeft--;
                //sum += currentTree.value;

                if (currentTree.leftChild != null)
                    queue.Enqueue(currentTree.leftChild);
                if (currentTree.rightChild != null)
                    queue.Enqueue(currentTree.rightChild);

                if(nodeLeft == 0)
                {
                    depth++;
                    nodeLeft = queue.Count;
                    currentIndentation += "    ";
                }
            }
            throw new NotImplementedException();
        }
        public int GetMaxDepth()
        {
            int result = 1;

            if(this.leftChild != null && this.rightChild != null)
            {
                int leftDepth = this.leftChild.GetMaxDepth();
                int rightDepth = this.rightChild.GetMaxDepth();
                result = Math.Max(leftDepth, rightDepth) + 1;
            }
            else if(this.leftChild != null && this.rightChild == null)
            {
                result = this.leftChild.GetMaxDepth() + 1;
            }
            else if(this.rightChild != null && this.leftChild == null)
            {
                result = this.rightChild.GetMaxDepth() + 1;
            }

            return result;
        }

        // --- Depth First Search : Left First / Right Second ---
        public void PrintTreeDFS(string indentation)
        {
            Console.WriteLine(indentation + this.value);
            if (this.leftChild != null)
                this.leftChild.PrintTreeDFS(indentation + " ");
            if (this.rightChild != null)
                this.rightChild.PrintTreeDFS(indentation + " ");
        }

        // --- Breadth-first search : Left First / Right Second ---
        public void PrintTreeBFS()
        {
            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>(10);
            queue.Enqueue(this);

            while(queue.Count != 0)
            {
                BinaryTree<T> currentTree = queue.Dequeue();
                Console.WriteLine(currentTree.value);
                if (currentTree.leftChild != null)
                    queue.Enqueue(currentTree.leftChild);
                if (currentTree.rightChild != null)
                    queue.Enqueue(currentTree.rightChild);
            }
        }
        #endregion
    }
    #endregion

    public class Program
    {
        static void Main(string[] args)
        {
            //Exo1.Execute();
            //Exo2.Execute();
            //Exo3.Execute();
            //Exo4.Execute();

            //Exo11.Execute();
            Exo12.Execute();
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

    /// <summary>
    /// Write a program that finds the number of leaves and number of internal vertices of a tree.
    /// </summary>
    public static class Exo3
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

            int leaves = integerTree.GetNumberOfLeaves();
            Console.WriteLine("The tree has : " + leaves + " leave(s).");

            int nodes = integerTree.GetNumberOfNodes();
            Console.WriteLine("The tree has : " + nodes + " node(s).");
        }
    }

    /// <summary>
    /// Write a program that finds in a binary tree of numbers the sum of the vertices of each level of the tree.
    /// </summary>
    public static class Exo4
    {
        public static int[] GetBinaryTreeDepthsSum(BinaryTree<int> binaryTree)
        {
            int maxDepth = binaryTree.GetMaxDepth();
            int[] depthsSums = new int[maxDepth];

            int nodeLeft = 1;
            int depth = 0;
            int sum = 0;
            string currentIndentation = "";
            Queue<BinaryTree<int>> queue = new Queue<BinaryTree<int>>(10);
            queue.Enqueue(binaryTree);

            while (queue.Count != 0)
            {
                BinaryTree<int> currentTree = queue.Dequeue();
                nodeLeft--;
                sum += currentTree.Value;

                Console.WriteLine(currentIndentation + currentTree.Value);

                if (currentTree.LeftChild != null)
                    queue.Enqueue(currentTree.LeftChild);
                if (currentTree.RightChild != null)
                    queue.Enqueue(currentTree.RightChild);

                if (nodeLeft == 0)
                {
                    depthsSums[depth] = sum;
                    sum = 0;
                    depth++;
                    nodeLeft = queue.Count;
                    currentIndentation += "    ";
                }
            }
            return depthsSums;
        }

        public static void Execute()
        {
            BinaryTree<int> binaryIntegerTree = new BinaryTree<int>(1,
                new BinaryTree<int>(10,
                    new BinaryTree<int>(5,
                        new BinaryTree<int>(8, null, null),
                        new BinaryTree<int>(6, null, null)),
                    new BinaryTree<int>(4,
                        new BinaryTree<int>(6, null, null),
                        null)),
                new BinaryTree<int>(5,
                    new BinaryTree<int>(5,
                        new BinaryTree<int>(8,
                            new BinaryTree<int>(8, null, null),
                            null),
                        new BinaryTree<int>(4, null,
                            new BinaryTree<int>(7, null, null))),
                    new BinaryTree<int>(4,
                        new BinaryTree<int>(6,
                            new BinaryTree<int>(2, null,
                                new BinaryTree<int>(5,null,null)),
                            new BinaryTree<int>(3,null,null)),
                        null)));

            binaryIntegerTree.PrintTreeDFS("");
            Console.WriteLine();
            //binaryIntegerTree.PrintTreeBFS();

            int[] depthsSum = GetBinaryTreeDepthsSum(binaryIntegerTree);

            for (int i = 0; i < depthsSum.Length; i++)
            {
                Console.WriteLine("Depth : " + i + " | Sum : " + depthsSum[i]);
            }
        }
    }

    /// <summary>
    /// Write a program that finds and prints all vertices of a binary tree, which have for only leaves successors. ???
    /// Don't understand the question. ("which have for only leaves successors" ????)
    /// Already done BFS and DFS on BinaryTree<T> class.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a program that checks whether a binary tree is perfectly balanced.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a program that searches the directory C:\Windows\ and all its subdirectories recursively and prints all the files which have extension *.exe.
    /// </summary>
    public static class Exo11
    {
        public static readonly string SearchingDirectory = @"C:\Windows\";

        public static void Execute()
        {
            TraverseDirectoryForExeFiles(SearchingDirectory);
        }

        public static void TraverseDirectoryForExeFiles(string directoryPath)
        {
            string[] subDirectories = null;
            try
            {
                subDirectories = Directory.GetDirectories(directoryPath);
            }
            catch(UnauthorizedAccessException e)
            {
                return;
            }

            foreach (string subDirectoryPath in subDirectories)
            {
                TraverseDirectoryForExeFiles(subDirectoryPath);
            }

            foreach(string file in Directory.GetFiles(directoryPath))
            {
                string extension = Path.GetExtension(file);
                if (extension.Equals(".exe"))
                {
                    Console.WriteLine(file);
                }
            }
        }
    }


    /// <summary>
    /// Define classes File {string name, int size} and Folder {string name, File[] files, Folder[] childFolders } . 
    /// Using these classes, build a tree that contains all files and directories on your hard disk, starting from C:\Windows\. 
    /// Write a method that calculates the sum of the sizes of files in a sub-tree and a program that tests this method.
    /// To crawl the directories use recursively crawl depth (DFS).
    /// </summary>
    public static class Exo12
    {
        public static readonly string SearchingDirectory = @"C:\Windows\";

        public static void Execute()
        {
            FileSystem.Folder folder = CreateHierarchy(SearchingDirectory);
            Console.WriteLine("Hierarchy created !");

            for(int i = 0; i < folder.Folders.Length; i++)
            {
                FileSystem.Folder currentFolder = folder.Folders[i];
                if (currentFolder != null)
                {
                    long size = currentFolder.GetFilesSize();
                    int files = currentFolder.GetFileNumber();
                    int folders = currentFolder.GetFolderNumber();
                    Console.WriteLine(currentFolder.Name + " size : " + size);
                    Console.WriteLine(folders + " Folders");
                    Console.WriteLine(files + " Files");
                    Console.WriteLine("--- + ---");
                }
            }
        }

        public static FileSystem.Folder CreateHierarchy(string rootPath)
        {
            string[] subDirectories = null;
            FileSystem.Folder[] subFolders = null;
            try
            {
                subDirectories = Directory.GetDirectories(rootPath);
                subFolders = new FileSystem.Folder[subDirectories.Length];
                for(int i = 0; i < subDirectories.Length; i++)
                {
                    subFolders[i] = CreateHierarchy(subDirectories[i]);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return null;
            }

            string[] filePaths = null;
            FileSystem.File[] files = null;
            try
            {
                filePaths = Directory.GetFiles(rootPath);
                files = new FileSystem.File[filePaths.Length];
                for(int i = 0; i < filePaths.Length; i++)
                {
                    FileInfo currentFile = new FileInfo(filePaths[i]);
                    if (currentFile.Exists)
                    {
                        files[i] = new FileSystem.File(currentFile.Name, (int)currentFile.Length);
                    }
                    else
                    {
                        files[i] = null;
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                
            }

            FileSystem.Folder folder = new FileSystem.Folder(rootPath, files, subFolders);

            return folder;
        }
    }

    namespace FileSystem
    {
        /// <summary>
        /// Base class for a file in the file system.
        /// </summary>
        public class File
        {
            #region Fields
            private string name = "";
            private int size = 0;
            #endregion

            #region Constructor
            public File(string name, int size)
            {
                this.name = name;
                this.size = size;
            }
            #endregion

            #region Properties
            public string Name { get { return this.name; } }
            public int Size { get { return this.size; } }
            #endregion
        }

        /// <summary>
        /// Base class for a folder in the file system.
        /// A folder contains subfolders.
        /// A folder contains files.
        /// </summary>
        public class Folder
        {
            #region Fields
            private const int MinimumFilesBufferSize = 4;
            private const int MinimumSubFoldersBufferSize = 4;

            private string name = "";
            private File[] files = null;
            private Folder[] childFolders = null;
            #endregion

            #region Constructors
            public Folder(string name, File[] files = null, Folder[] subFolders = null)
            {
                this.name = name;
                this.files = files;
                this.childFolders = subFolders;
            }
            #endregion

            #region Properties
            public string Name { get { return this.name; } }
            public File[] Files { get { return this.files; } }
            public Folder[] Folders { get { return this.childFolders; } }
            #endregion

            #region Methods
            #region Files
            public void AddFile(File file)
            {
                if (file == null)
                    throw new ArgumentNullException("[Argument Null Exception] - The parameter file is null ref.");
            }
            public void AddFiles(params File[] files)
            {
                if (files == null)
                    throw new ArgumentNullException("[Argument Null Exception] - The parameter files is null ref.");
            }

            private void AddFileToFolder(File file)
            {
                if(this.files == null)
                {
                    this.files = new File[MinimumFilesBufferSize];
                }
            }
            #endregion
            #region Folders
            public long GetFilesSize()
            {
                long size = 0;

                if (this.childFolders != null)
                {
                    for (int i = 0; i < this.childFolders.Length; i++)
                    {
                        if(this.childFolders[i] != null)
                            size += this.childFolders[i].GetFilesSize();
                    }
                }

                if(this.files != null)
                {
                    for(int i = 0; i < this.files.Length; i++)
                    {
                        if (this.files[i] != null)
                            size += this.files[i].Size;
                    }
                }

                return size;
            }
            public int GetFolderNumber()
            {
                int folderNumber = this.childFolders?.Length ?? 0;

                if (this.childFolders != null)
                {
                    for (int i = 0; i < this.childFolders.Length; i++)
                    {
                        if (this.childFolders[i] != null)
                            folderNumber += this.childFolders[i].GetFolderNumber();
                    }
                }

                return folderNumber;
            }
            public int GetFileNumber()
            {
                int fileNumber = this.files?.Length ?? 0;

                if (this.childFolders != null)
                {
                    for (int i = 0; i < this.childFolders.Length; i++)
                    {
                        if (this.childFolders[i] != null)
                            fileNumber += this.childFolders[i].GetFileNumber();
                    }
                }

                return fileNumber;
            }
            #endregion
            #endregion
        }
    }

    public static class Exo13
    {

    }


}

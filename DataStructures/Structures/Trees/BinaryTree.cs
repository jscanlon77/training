using System;
using DataStructures.Structures.LinkedList;

namespace DataStructures.Structures.Trees
{
    class BinaryTree
{
    public BinaryNode Root { get; set; }
 
    public void Add(int data)
    {
        // 1. If the tree is empty, return a new, single node 
        if (Root == null)
        {
            Root = new BinaryNode() {Data = data};
            return;
        }

        // If this is a duplicate then return - perhaps report an error
        var nodeFound = Find(data);
        if (nodeFound != null)
        {
            return;
        }

        // 2. Otherwise, recursively down the tree comparing the left and right node values to the value we have 
        // and then insert in correct place.
        InsertRec(Root, new BinaryNode() {Data = data});
    }
    private void InsertRec(BinaryNode root, BinaryNode newNode)
    {
        if (root == null)
            root = newNode;
 
        if (newNode.Data < root.Data)
        {
            if (root.LeftNode == null)
                root.LeftNode = newNode;
            else
                InsertRec(root.LeftNode, newNode);
 
        }
        else
        {
            if (root.RightNode == null)
                root.RightNode = newNode;
            else
                InsertRec(root.RightNode, newNode);
        }
    }
    public BinaryNode Find(int value)
    {
        return this.Find(value, this.Root);            
    }
 
    public void Remove(int value)
    {
        Remove(this.Root, value);
    }
 
    private BinaryNode Remove(BinaryNode parent, int key)
    {
        if (parent == null) return parent;
 
        if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key); else if (key > parent.Data)
            parent.RightNode = Remove(parent.RightNode, key);
 
        // if value is same as parent's value, then this is the node to be deleted  
        else
        {
            // node with only one child or no child  
            if (parent.LeftNode == null)
                return parent.RightNode;
            else if (parent.RightNode == null)
                return parent.LeftNode;
 
            // node with two children: Get the inorder successor (smallest in the right subtree)  
            parent.Data = MinValue(parent.RightNode);
 
            // Delete the inorder successor  
            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }
 
        return parent;
    }
 
    private int MinValue(BinaryNode node)
    {
        int minv = node.Data;
 
        while (node.LeftNode != null)
        {
            minv = node.LeftNode.Data;
            node = node.LeftNode;
        }
 
        return minv;
    }
 
    private BinaryNode Find(int value, BinaryNode parent)
    {
        if (parent != null)
        {
            if (value == parent.Data) return parent;
            if (value < parent.Data)
                return Find(value, parent.LeftNode);
            else
                return Find(value, parent.RightNode);
        }
 
        return null;
    }
 
    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.Root);
    }
 
    private int GetTreeDepth(BinaryNode parent)
    {
        return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }
 
    public void TraversePreOrder(BinaryNode parent)
    {
        if (parent != null)
        {
            Console.Write(parent.Data + " ");
            TraversePreOrder(parent.LeftNode);
            TraversePreOrder(parent.RightNode);
        }
    }
 
    public void TraverseInOrder(BinaryNode parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.LeftNode);
            Console.Write(parent.Data + " ");
            TraverseInOrder(parent.RightNode);
        }
    }
 
    public void TraversePostOrder(BinaryNode parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.LeftNode);
            TraversePostOrder(parent.RightNode);
            Console.Write(parent.Data + " ");
        }
    }
}
}
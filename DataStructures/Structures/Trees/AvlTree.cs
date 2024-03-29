﻿using System;

namespace DataStructures.Structures.Trees
{
    internal class AvlTree
    {
        private AvlNode root;

        public void Add(int data)
        {
            var newItem = new AvlNode(data);
            if (root == null)
                root = newItem;
            else
                root = RecursiveInsert(root, newItem);
        }

        private AvlNode RecursiveInsert(AvlNode current, AvlNode n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }

            if (n.data < current.data)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data > current.data)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }

            return current;
        }

        private AvlNode balance_tree(AvlNode current)
        {
            var b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                    current = RotateLL(current);
                else
                    current = RotateLR(current);
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                    current = RotateRL(current);
                else
                    current = RotateRR(current);
            }

            return current;
        }

        public void Delete(int target)
        {
            //and here
            root = Delete(root, target);
        }

        private AvlNode Delete(AvlNode current, int target)
        {
            AvlNode parent;
            if (current == null) return null;

            //left subtree
            if (target < current.data)
            {
                current.left = Delete(current.left, target);
                if (balance_factor(current) == -2) //here
                {
                    if (balance_factor(current.right) <= 0)
                        current = RotateRR(current);
                    else
                        current = RotateRL(current);
                }
            }
            //right subtree
            else if (target > current.data)
            {
                current.right = Delete(current.right, target);
                if (balance_factor(current) == 2)
                {
                    if (balance_factor(current.left) >= 0)
                        current = RotateLL(current);
                    else
                        current = RotateLR(current);
                }
            }
            //if target is found
            else
            {
                if (current.right != null)
                {
                    //delete its inorder successor
                    parent = current.right;
                    while (parent.left != null) parent = parent.left;
                    current.data = parent.data;
                    current.right = Delete(current.right, parent.data);
                    if (balance_factor(current) == 2) //rebalancing
                    {
                        if (balance_factor(current.left) >= 0)
                            current = RotateLL(current);
                        else
                            current = RotateLR(current);
                    }
                }
                else
                {
                    //if current.left != null
                    return current.left;
                }
            }

            return current;
        }

        public void Find(int key)
        {
            if (Find(key, root).data == key)
                Console.WriteLine("{0} was found!", key);
            else
                Console.WriteLine("Nothing found!");
        }

        private AvlNode Find(int target, AvlNode current)
        {
            if (target < current.data)
            {
                if (target == current.data)
                    return current;
                return Find(target, current.left);
            }

            if (target == current.data)
                return current;
            return Find(target, current.right);
        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            InOrderDisplayTree(root);
            Console.WriteLine();
        }

        private void InOrderDisplayTree(AvlNode current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplayTree(current.right);
            }
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int getHeight(AvlNode current)
        {
            var height = 0;
            if (current != null)
            {
                var l = getHeight(current.left);
                var r = getHeight(current.right);
                var m = max(l, r);
                height = m + 1;
            }

            return height;
        }

        private int balance_factor(AvlNode current)
        {
            var l = getHeight(current.left);
            var r = getHeight(current.right);
            var b_factor = l - r;
            return b_factor;
        }

        private AvlNode RotateRR(AvlNode parent)
        {
            var pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }

        private AvlNode RotateLL(AvlNode parent)
        {
            var pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        private AvlNode RotateLR(AvlNode parent)
        {
            var pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private AvlNode RotateRL(AvlNode parent)
        {
            var pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

        
    }
}
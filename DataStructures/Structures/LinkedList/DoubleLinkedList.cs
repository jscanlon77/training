using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.LinkedList
{
    internal class DoubleLinkedList
    {
        internal DoubleNode head;
        
        internal void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)  
        {  
            DoubleNode temp = doubleLinkedList.head;  
            if (temp != null && temp.data == key) {  
                doubleLinkedList.head = temp.next;  
                doubleLinkedList.head.previous = null;  
                return;  
            }  
            while (temp != null && temp.data != key) {  
                temp = temp.next;  
            }  
            if (temp == null) {  
                return;  
            }  
            if (temp.next != null) {  
                temp.next.previous = temp.previous;  
            }  
            if (temp.previous != null) {  
                temp.previous.next = temp.next;  
            }  
        }

        internal DoubleNode GetLastNode(DoubleLinkedList list) {  
            DoubleNode temp = list.head;  
            while (temp.next != null) {  
                temp = temp.next;  
            }  
            return temp;  
        }  

        internal void InsertFront(DoubleLinkedList doubleLinkedList, int data) {  
            DoubleNode newNode = new DoubleNode(data);  
            newNode.next = doubleLinkedList.head;  
            newNode.previous = null;  
            if (doubleLinkedList.head != null) {  
                doubleLinkedList.head.previous = newNode;  
            }  
            doubleLinkedList.head = newNode;  
        }  
        
        internal void InsertAfter(DoubleNode prev_node, int data)  
        {  
            if (prev_node == null) {  
                Console.WriteLine("The given prevoius node cannot be null");  
                return;  
            }  
            DoubleNode newNode = new DoubleNode(data);  
            newNode.next = prev_node.next;  
            prev_node.next = newNode;  
            newNode.previous = prev_node;  
            if (newNode.next != null) {  
                newNode.next.previous = newNode;  
            }  
        }
        
        internal void InsertLast(DoubleLinkedList doubleLinkedList, int data) {  
            DoubleNode newNode = new DoubleNode(data);  
            if (doubleLinkedList.head == null) {  
                newNode.previous = null;  
                doubleLinkedList.head = newNode;  
                return;  
            }  
            DoubleNode lastNode = GetLastNode(doubleLinkedList);  
            lastNode.next = newNode;  
            newNode.previous = lastNode;  
        }  
    }
}

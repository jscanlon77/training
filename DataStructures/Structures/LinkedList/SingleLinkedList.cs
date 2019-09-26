using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.LinkedList
{
    internal class SingleLinkedList
    {
        internal Node head;

        /// <summary>
        /// Here, the first node will be null when creating the linked list
        /// when we add a node we want the head to point at it;
        /// When we create that node the next of the new node will point to the head of the linked list
        /// and then we assign the head to the new node
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newData"></param>
        internal void InsertFront(SingleLinkedList list, int newData)
        {
            Node newNode = new Node(newData);
            newNode.next = list.head;
            list.head = newNode;

        }

        internal void InsertLast(SingleLinkedList list, int newData)    
        {    
            Node new_node = new Node(newData);    
            if (list.head == null) {    
                list.head = new_node;    
                return;    
            }    
            Node lastNode = GetLastNode(list);    
            lastNode.next = new_node;    
        } 

        internal void InsertAfter(Node previousNode, int newData)  
        {  
            if (previousNode == null) {  
                Console.WriteLine("The given previous node Cannot be null");  
                return;  
            }  
            Node new_node = new Node(newData);  
            new_node.next = previousNode.next;  
            previousNode.next = new_node;  
        }

        internal Node FindNode(SingleLinkedList list, int x)  
        {  
            Node current = list.head; // Initialize current  
            while (current != null)
            {
                if (current.data == x)
                    return current;
                current = current.next;
            }

            return null;
        }  

        
       

        internal void DeleteNodebyKey(SingleLinkedList singlyList, int key)  
        {  
            Node temp = singlyList.head;  
            Node prev = null;  
            if (temp != null && temp.data == key) {  
                singlyList.head = temp.next;  
                return;  
            }  
            while (temp != null && temp.data != key) {  
                prev = temp;  
                temp = temp.next;  
            }  
            if (temp == null) {  
                return;  
            }  
            prev.next = temp.next;  
        }  

        public void ReverseLinkedList(SingleLinkedList singlyList)  
        {  
            Node prev = null;  
            Node current = singlyList.head;  
            Node temp = null;  
            while (current != null) {  
                temp = current.next;  
                current.next = prev;  
                prev = current;  
                current = temp;  
            }  
            singlyList.head = prev;  
        }  
        
        internal Node GetLastNode(SingleLinkedList singlyList) {  
            Node temp = singlyList.head;  
            while (temp.next != null) {  
                temp = temp.next;  
            }  
            return temp;  
        }  
    }
}

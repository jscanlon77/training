using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using DataStructures.Model;
using DataStructures.Structures.LinkedList;
using DataStructures.Structures.Trees;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList linkedList = new SingleLinkedList();
            linkedList.InsertFront(linkedList, 2);

            // We add one and the head will have data of 2 in it;
            // the next property will be null as its the end

            linkedList.InsertFront(linkedList, 3);

            // if we add another this becomes the head
            // and next becomes the data node with 2 in it
            // and its next is null

            var node = linkedList.FindNode(linkedList, 3);
            linkedList.InsertAfter(node, 4);


            var myNode = linkedList.FindNode(linkedList, 2);
            linkedList.InsertAfter(myNode, 7);

            linkedList.DeleteNodebyKey(linkedList, 2);

           
            linkedList.ReverseLinkedList(linkedList);


            BinaryTree binaryTree = new BinaryTree();
            

            // this gets added to the root because there are no other nodes
            // if data is less than it goes on the left.
            // if its more then it goes on the right..
            // so as we are searching - if the value of the data < this node then go left
            // if value of data > this node then go right
            // and progress down the tree to find a space for the data
            // Each pass cuts data in half and improves performance..
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);

            // what happens if we already have the value

            binaryTree.Add(1);

            AvlTree tree = new AvlTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            tree.Delete(7);
            tree.DisplayTree();

           
            // LIFO so 
            Stack<FootballTeam> stackOfFootballTeams = new Stack<FootballTeam>();
            stackOfFootballTeams.Push(new FootballTeam() {Name= "Manchester United", ShirtColor = "Red", Stadium = "Old Trafford"});
            stackOfFootballTeams.Push(new FootballTeam() {Name= "Liverpool", ShirtColor = "Red", Stadium = "Anfield"});

            var count = stackOfFootballTeams.Count;

            // so first out will be liverpool
            var item = stackOfFootballTeams.Pop();

            // This is a queue so FIFO 

            Queue<FootballTeam> queueOfFootballTeams = new Queue<FootballTeam>();
            queueOfFootballTeams.Enqueue(new FootballTeam() {Name= "Manchester United", ShirtColor = "Red", Stadium = "Old Trafford"});
            queueOfFootballTeams.Enqueue(new FootballTeam() {Name= "Liverpool", ShirtColor = "Red", Stadium = "Anfield"});

            // This will be man united.
            var footballTeam = queueOfFootballTeams.Dequeue();
            Console.ReadLine();
        }

        
       
    }
    
}

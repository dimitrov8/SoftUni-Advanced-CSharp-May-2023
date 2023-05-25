﻿using System;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private class ListNode
        {
            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListNode newHead = new(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            ListNode newTail = new(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            T removedElement = this.head.Value;
            ListNode newHead = this.head.NextNode;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;
            return removedElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            T removedElement = this.tail.Value;
            ListNode newTail = this.tail.PreviousNode;
            
            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                newTail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var currentNode = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }
    }
}
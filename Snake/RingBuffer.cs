using System;
using System.ComponentModel;

namespace Snake
{

    /// <summary>
    /// Represents a ring buffer that stores Position objects and has a fixed capacity.
    /// </summary>
    public class RingBuffer
    {
        public Node head { get; set; }
        private Node tail;

        public class Node
        {
            public Position p;
            public Node next;
            public Node prev;

            public Node(Position p)
            {
                this.p = p;
            }
        }

        public void Add(Position p)
        {
            if (head == null)
            {
                head = new Node(p);
            }
            else
            {
                head.next = new Node(p);
                head.next.prev = head;
                head = head.next;
            }
        }

        public void Remove()
        {
            tail = tail.next;
            tail.prev = null;
        }

        /// <summary>
        /// Draws all the Position objects in the buffer on the console using the given background color.
        /// </summary>
        /// <param name="color">The color to use as the background.</param>
        public void Draw(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Node curr = head;
            while(curr != null)
            {
                //Console.SetCursorPosition(curr.p.X + 26, curr.p.Y + 16);
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.White;
                curr = curr.prev;
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}

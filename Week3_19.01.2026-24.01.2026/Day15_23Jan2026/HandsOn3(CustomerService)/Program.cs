using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> ticketQueue = new Queue<string>();

        ticketQueue.Enqueue("Ticket 1: Login Issue");
        ticketQueue.Enqueue("Ticket 2: Payment Failed");
        ticketQueue.Enqueue("Ticket 3: Account Locked");

        Stack<string> actionStack = new Stack<string>();

        Console.WriteLine("Processing Tickets...\n");

        for (int i = 0; i < 3; i++)
        {
            string ticket = ticketQueue.Dequeue();
            Console.WriteLine("Processing " + ticket);

            actionStack.Push("Opened " + ticket);
            actionStack.Push("Investigated " + ticket);
            actionStack.Push("Resolved " + ticket);

            Console.WriteLine("Actions performed for " + ticket);

            string undoneAction = actionStack.Pop();
            Console.WriteLine("Undo action: " + undoneAction + "\n");
        }

        Console.WriteLine("Remaining Tickets in Queue:");
        if (ticketQueue.Count == 0)
        {
            Console.WriteLine("No pending tickets.");
        }
        else
        {
            foreach (string t in ticketQueue)
                Console.WriteLine(t);
        }
    }
}

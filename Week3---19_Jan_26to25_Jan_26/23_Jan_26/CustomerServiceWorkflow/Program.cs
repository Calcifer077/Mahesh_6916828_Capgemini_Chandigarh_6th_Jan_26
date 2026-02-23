using System;
using System.Collections.Generic;

class CustomerServiceWorkflow
{
    internal class Program{
    static void Main()
    {
        // Queue for incoming support tickets (FIFO)
        Queue<string> ticketQueue = new Queue<string>();

        ticketQueue.Enqueue("Ticket #101 - Login issue");
        ticketQueue.Enqueue("Ticket #102 - Payment failure");
        ticketQueue.Enqueue("Ticket #103 - Account locked");

        // Stack for agent action history (LIFO)
        Stack<string> actionHistory = new Stack<string>();

        Console.WriteLine("Initial Ticket Queue:");
        DisplayQueue(ticketQueue);
        Console.WriteLine();

        // Process tickets
        for (int i = 0; i < ticketQueue.Count; i++)
        {
            string currentTicket = ticketQueue.Dequeue();
            Console.WriteLine($"Processing {currentTicket}");

            // Perform actions
            actionHistory.Push("Checked customer details");
            actionHistory.Push("Reset password");
            actionHistory.Push("Sent confirmation email");

            Console.WriteLine("Actions performed:");
            DisplayStack(actionHistory);

            // Undo last action
            string undoneAction = actionHistory.Pop();
            Console.WriteLine($"Undo last action: {undoneAction}");

            Console.WriteLine("Remaining actions:");
            DisplayStack(actionHistory);
            Console.WriteLine("--------------------------------");
        }

        // Show remaining queue
        Console.WriteLine("Remaining Ticket Queue:");
        DisplayQueue(ticketQueue);
    }

    static void DisplayQueue(Queue<string> queue)
    {
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }
    }

    static void DisplayStack(Stack<string> stack)
    {
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}}

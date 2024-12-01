using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCalculator;

public class MyStack<T>
{
    // Node class for the stack
    private class Node
    {
        public T Data { get; }
        public Node? Next { get; }

        public Node(T data, Node? next)
        {
            Data = data;
            Next = next;
        }
    }

    private Node? top; // Top of the stack
    private int count; // Number of elements in the stack

    public MyStack()
    {
        top = null;
        count = 0;
    }

    /// <summary>
    /// Pushes an item onto the stack.
    /// </summary>
    /// <param name="item">The item to push onto the stack.</param>
    public void Push(T item)
    {
        top = new Node(item, top);
        count++;
    }

    /// <summary>
    /// Removes and returns the item from the top of the stack.
    /// </summary>
    /// <returns>The item at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        T item = top!.Data;
        top = top.Next;
        count--;
        return item;
    }

    /// <summary>
    /// Returns the item at the top of the stack without removing it.
    /// </summary>
    /// <returns>The item at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return top!.Data;
    }

    /// <summary>
    /// Checks if the stack is empty.
    /// </summary>
    /// <returns>True if the stack is empty, otherwise false.</returns>
    public bool IsEmpty()
    {
        return count == 0;
    }

    /// <summary>
    /// Gets the number of items in the stack.
    /// </summary>
    public int Count => count;
}

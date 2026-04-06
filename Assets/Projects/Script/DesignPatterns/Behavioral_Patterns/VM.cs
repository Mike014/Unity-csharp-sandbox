using System.Diagnostics;

public class VM 
{
    private const int MAX_STACK = 128;
    private int[] _stack = new int[MAX_STACK];
    private int _stackSize = 0;

    private void Push(int value)
    {
        Debug.Assert(_stackSize < MAX_STACK, "Stack overflow!");
        _stack[_stackSize++] = value;
    }

    private int Pop()
    {
        Debug.Assert(_stackSize > 0, "Stack underflow!");
        return _stack[--_stackSize];
    }
}
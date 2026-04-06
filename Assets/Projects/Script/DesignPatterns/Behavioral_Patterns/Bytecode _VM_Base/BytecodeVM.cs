using UnityEngine;
using System;
using Unity.VisualScripting;

namespace BytecodePattern
{
    /// <summary>
    /// Set di istruzioni supportate dalla VM.
    /// Ogni istruzione è codificata come un byte (0-255).
    /// </summary>
    /// 
    public enum OpCode : byte
    {
        // Push un valore letterale sullo stack
        LITERAL = 0x00,

        // Operazioni aritmetiche
        ADD = 0x01, // Pop 2 valori, push (a + b)
        SUBTRACT = 0x02, // Pop 2 valori, push (a - b)
        MULTIPLY = 0x03, // Pop 2 valori, push (a * b)
        DIVIDE = 0x04, // Pop 2 valori, push (a / b)

        // Stampa il valore in cima allo stack (per debug)
        PRINT = 0x05,

        // Termina l'esecuzione
        HALT = 0xFF
    }
}

/*
Perché enum : byte?

Forza ogni valore a occupare esattamente 1 byte in memoria
In Unity, questo è importante per serializzare bytecode in ScriptableObjects o salvare in file
*/

namespace BytecodePattern
{
    public class BytecodeVM
    {
        // Dimensione massima dello stack
        private const int MAX_STACK = 256;

        // Lo stack interno della VM
        private int[] _stack;

        // Puntatore alla cima dello stack (stack pointer)
        private int _stackPointer;

        // Puntatore all'istruzione corrente (instruction pointer)
        private int _instructionPointer;

        public BytecodeVM()
        {
            _stack = new int[MAX_STACK];
            _stackPointer = 0;
            _instructionPointer = 0;
        }

        /// <summary>
        /// Esegue un array di bytecode.
        /// </summary>
        public void Execute(byte[] bytecode)
        {
            // Reset VM state
            _stackPointer = 0;
            _instructionPointer = 0;

            // Loop principale della VM
            while (_instructionPointer < bytecode.Length)
            {
                OpCode instruction = (OpCode)bytecode[_instructionPointer];
                _instructionPointer++; // Avanza subito dopo aver letto l'opcode

                switch (instruction)
                {
                    case OpCode.LITERAL:
                        ExecuteLiteral(bytecode);
                        break;
                    case OpCode.ADD:
                        ExecuteAdd();
                        break;
                    case OpCode.SUBTRACT:
                        ExecuteSubtract();
                        break;
                    case OpCode.MULTIPLY:
                        ExecuteMultiply();
                        break;
                    case OpCode.DIVIDE:
                        ExecuteDivide();
                        break;
                    case OpCode.PRINT:
                        ExecutePrint();
                        break;
                    case OpCode.HALT:
                        Debug.Log("VM halted.");
                        return;
                    default:
                        Debug.LogError($"Unknown opcode: 0x{instruction:X2}");
                        return;
                }
            }
        }

        #region Stack Operations
        private void Push(int value)
        {
            if (_stackPointer >= MAX_STACK)
            {
                Debug.LogError("Stack Overflow");
                return;
            }

            _stack[_stackPointer] = value;
            _stackPointer++;
        }

        private int Pop()
        {
            if (_stackPointer <= 0)
            {
                Debug.LogError("Stack underflow");
                return 0;
            }
            _stackPointer--;
            return _stack[_stackPointer];
        }

        private int Peek()
        {
            if (_stackPointer <= 0)
            {
                Debug.LogError("Stack is empty!");
                return 0;
            }
            return _stack[_stackPointer - 1];
        }
        #endregion

        #region Instruction Implementations

        private void ExecuteLiteral(byte[] bytecode)
        {
            // LITERAL richiede 1 byte aggiuntivo: il valore da pushare
            if (_instructionPointer >= bytecode.Length)
            {
                Debug.LogError("LITERAL instruction missing value!");
                return;
            }

            int value = bytecode[_instructionPointer];
            _instructionPointer++;

            Push(value);
        }

        private void ExecuteAdd()
        {
            int b = Pop();
            int a = Pop();
            Push(a + b);
        }

        private void ExecuteSubtract()
        {
            int b = Pop();
            int a = Pop();
            Push(a - b);
        }

        private void ExecuteMultiply()
        {
            int b = Pop();
            int a = Pop();
            Push(a * b);
        }

        private void ExecuteDivide()
        {
            int b = Pop();
            int a = Pop();

            if (b == 0)
            {
                Debug.LogError("Division by zero");
                Push(0);
                return;
            }

            Push(a / b);
        }

        private void ExecutePrint()
        {
            int value = Peek();
            Debug.Log(($"[VM OUTPUT] {value}"));
        }
        #endregion
    }
}

/*
Perché Pop in ordine inverso nelle operazioni?

b = Pop(); // Secondo operando
int a = Pop(); // Primo operando
Push(a - b);   // a - b (NON b - a!)

Motivo: Lo stack è LIFO. Se pushiamo [5, 3], poppiamo [3, 5]. Per mantenere l'ordine corretto dell'operazione, dobbiamo popparli al contrario.
*/
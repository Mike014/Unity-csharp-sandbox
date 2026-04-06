using UnityEngine;
using BytecodePattern;

public class BytecodeVMTester : MonoBehaviour
{
    private void Start()
    {
        BytecodeVM vm = new BytecodeVM();

        // Test 1: 5 + 3 = 8
        Test_Addition(vm);

        // Test 2: 10 - 2 = 8
        Test_Subtraction(vm);

        // Test 3: (5 + 3) * 2 = 16
        Test_ComplexExpression(vm);
        
    }

    private void Test_Addition(BytecodeVM vm)
    {
        Debug.Log("=== Test: 5 + 3 ===");

        byte[] bytecode = new byte[]
        {
            (byte)OpCode.LITERAL, 5,  // Push 5
            (byte)OpCode.LITERAL, 3,  // Push 3
            (byte)OpCode.ADD,         // Pop 3, Pop 5, Push 8
            (byte)OpCode.PRINT,       // Stampa 8
            (byte)OpCode.HALT  
        };

        vm.Execute(bytecode);
        
    }

    private void Test_Subtraction(BytecodeVM vm)
    {
        Debug.Log("=== Test: 10 - 2 ===");

        byte[] bytecode = new byte[]
        {
            (byte)OpCode.LITERAL, 10,  
            (byte)OpCode.LITERAL, 2,  
            (byte)OpCode.SUBTRACT,         
            (byte)OpCode.PRINT,       
            (byte)OpCode.HALT  
        };

        vm.Execute(bytecode);
        
    }

    private void Test_ComplexExpression(BytecodeVM vm)
    {
        Debug.Log("=== Test:(5 + 3) * 2 ===");

        byte[] bytecode = new byte[]
        {
            (byte)OpCode.LITERAL, 5,  
            (byte)OpCode.LITERAL, 3,  
            (byte)OpCode.ADD,         
            (byte)OpCode.LITERAL, 2,
            (byte)OpCode.MULTIPLY,
            (byte)OpCode.PRINT,     
            (byte)OpCode.HALT  
        };

        vm.Execute(bytecode);
    }
}

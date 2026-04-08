using UnityEngine;

public class Employee
{
    public string name; // Istanza - ogni dipendente ha il suo
    public static int employeeCounter; // Static - condiviso tra tutti

    public Employee(string name)
    {
        this.name = name;
        employeeCounter++;
    }
}

public class Execute : MonoBehaviour
{
    Employee emp1 = new Employee("Alice");
    Employee emp2 = new Employee("Bob");
    Employee emp3 = new Employee("Charlie");

    void Start()
    {
        Debug.Log(Employee.employeeCounter);
    }
}

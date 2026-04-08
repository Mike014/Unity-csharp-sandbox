using UnityEngine;

class Base
{
    public void Method() => Debug.Log("Do something");
}

class DervedWithNew : Base
{
    new public void Method() => Debug.Log("DerivedWithNew.Method");
}

// class DerivedWithoutNew : Base
// {
//     public void Method() => Debug.Log("DerivedWithoutNew.Method");
//     // Warning CS0108: 'DerivedWithoutNew.Method()' hides inherited member
//     // Use 'new' keyword if hiding was intended
// }
using UnityEngine;
class Animal
{
    public virtual void MakeSound()
    {
        Debug.Log("Generic animal sound");
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Debug.Log("Woof");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Debug.Log("Miao");
        }
    }
}
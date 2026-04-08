using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected string interactText = "Press E";

    // Virtual 
    public virtual void ShowUI()
    {
        UIManager.Instance.ShowPrompt(interactText);
    }

    // Abstract - ogni oggetto interagisce diversamente
    public abstract void Interact(PlayerController player);

    public virtual void OnInteractEnd()
    {
        UIManager.Instance.HidePrompt();
    }
}

public class Door : Interactable
{
    private bool _isOpen;
    protected Animator animator;

    public override void Interact(PlayerController player)
    {
       _isOpen = !_isOpen;
       animator.SetBool("Open", _isOpen);
    }
}

public class Chest : Interactable
{
    // [SerializeField] private Item[] contents;

    public override void ShowUI()
    {
        base.ShowUI();
    }

    public override void Interact(PlayerController player)
    {
        throw new System.NotImplementedException();
    }
}


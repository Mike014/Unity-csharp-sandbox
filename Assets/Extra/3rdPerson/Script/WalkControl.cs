using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class WalkControl : MonoBehaviour
{
    // Variabili Private
    private Animator _animator;
    private AnimatorStateInfo _info;

    // Variabili Pubbliche
    public Transform spawnPoint1, spawnPoint2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        if (_animator == null)
        {
            Debug.LogError("❌ Animator NON trovato sul GameObject!");
            return;
        }
        Debug.Log("✓ Animator trovato correttamente");
    }

    public void LeftFootImpact()
    {
        if (spawnPoint1 == null)
        {
            Debug.LogError("❌ spawnPoint1 NON è assegnato nell'Inspector!");
            return;
        }

        Debug.Log($"🔵 LEFT FOOT IMPACT - Frame: {Time.frameCount}");
    }

    public void RightFootImpact()
    {
        if (spawnPoint2 == null)
        {
            Debug.LogError("❌ spawnPoint2 NON è assegnato nell'Inspector!");
            return;
        }

        Debug.Log($"🟢 RIGHT FOOT IMPACT - Frame: {Time.frameCount}");
    }
}
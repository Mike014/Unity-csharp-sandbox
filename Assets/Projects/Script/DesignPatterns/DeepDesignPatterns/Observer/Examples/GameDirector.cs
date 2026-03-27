using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private PhysicsSystem _physicsSystem;
    [SerializeField] private Achievements _achievements;

    private void Start()
    {
        _physicsSystem.AddObserver(_achievements);
    }

    private void Oestroy()
    {
        // Regola fondamentale: deregistra sempre
        _physicsSystem.RemoveObserver(_achievements);
    }
}

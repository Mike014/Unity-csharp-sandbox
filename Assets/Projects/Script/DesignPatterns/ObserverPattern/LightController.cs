using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRend;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;

    void OnEnable()
    {
        LightManager.Instance.OnTurnOn += TurnOn;
        LightManager.Instance.OnTurnOff += TurnOff;
    }

    void OnDisable()
    {
        LightManager.Instance.OnTurnOn -= TurnOn;
        LightManager.Instance.OnTurnOff -= TurnOff;
    }

    void TurnOn()
    {
        meshRend.material = onMaterial;
    }

    void TurnOff()
    {
        meshRend.material = offMaterial;
    }
}

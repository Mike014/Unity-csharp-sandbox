using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; // Necessario per visualizzare le scritte (Handles) nella Scene View
#endif

public class AStarVisualizer : MonoBehaviour
{
    [Header("Settings")]
    public Vector2Int gridSize = new Vector2Int(5, 5); // Dimensione griglia
    public float nodeSize = 1f; // Spaziatura nodi
    
    [Header("Targets")]
    public Transform startPoint; // Trascina qui un cubo verde
    public Transform endPoint;   // Trascina qui un cubo rosso

    // Disegna i Gizmos nella Scene View
    void OnDrawGizmos()
    {
        if (startPoint == null || endPoint == null) return;

        // Loop attraverso una griglia immaginaria
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                // Calcoliamo la posizione del nodo nel mondo 3D
                Vector3 nodePos = transform.position + new Vector3(x * nodeSize, 0, y * nodeSize);
                
                // 1. Calcolo G (Distanza dallo Start)
                // In A* vero, questo seguirebbe il percorso. Qui usiamo la distanza diretta per semplicità.
                float gCost = Vector3.Distance(startPoint.position, nodePos);

                // 2. Calcolo H (Euristica: Distanza all'End)
                float hCost = Vector3.Distance(nodePos, endPoint.position);

                // 3. Calcolo F (Totale)
                float fCost = gCost + hCost;

                // --- VISUALIZZAZIONE ---
                
                // Disegna il nodo (piccola sfera)
                Gizmos.color = Color.Lerp(Color.green, Color.red, fCost / 20f); // Gradiente colore basato sul costo
                Gizmos.DrawWireSphere(nodePos, 0.2f);

#if UNITY_EDITOR
                // Mostra i valori numerici sopra ogni nodo
                // G = Verde, H = Rosso, F = Bianco (in grassetto)
                string text = $"G:{gCost:F1}\nH:{hCost:F1}\n<b>F:{fCost:F1}</b>";
                
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                style.fontSize = 10;
                style.alignment = TextAnchor.MiddleCenter;
                style.richText = true;

                Handles.Label(nodePos + Vector3.up * 0.5f, text, style);
#endif
            }
        }
    }
}


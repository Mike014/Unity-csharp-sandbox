using UnityEngine;
using UnityEngine.ProBuilder;

public class ProceduralCylinderGenerator : MonoBehaviour
{
    [SerializeField] private int segments = 8;      // Quanti spigoli attorno?
    [SerializeField] private float radius = 1f;     // Raggio
    [SerializeField] private float height = 2f;     // Altezza

    // Bottone nell'inspector
    [ContextMenu("Generate Cylinder")]

    public void GenerateCylinder()
    {
        // 1. CREA LISTA DI VERTICI
        var vertices = new System.Collections.Generic.List<Vector3>();
        var faces = new System.Collections.Generic.List<Face>();

        // 2. BOTTOM CIRCLE (Base inferiore)
        // Perché? Abbiamo bisogno di un punto centrale + vertici perimetrali
        int bottomCenterIndex = vertices.Count;
        vertices.Add(new Vector3(0, 0, 0)); // Centro base
        
        // Aggiungi vertici attorno al perimetro (base)
        int bottomStartIndex = vertices.Count;
        for (int i = 0; i < segments; i++)
        {
            float angle = (i / (float)segments) * Mathf.PI * 2f;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices.Add(new Vector3(x, 0, z));
        }

        // 3. TOP CIRCLE (Cerchio superiore)
        int topCenterIndex = vertices.Count;
        vertices.Add(new Vector3(0, height, 0)); // Centro top
        
        int topStartIndex = vertices.Count;
        for (int i = 0; i < segments; i++)
        {
            float angle = (i / (float)segments) * Mathf.PI * 2f;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices.Add(new Vector3(x, height, z));
        }

        // 4. CREA LE FACCE
        
        // Bottom cap (faccia piatta inferiore)
        for (int i = 0; i < segments; i++)
        {
            int current = bottomStartIndex + i;
            int next = bottomStartIndex + ((i + 1) % segments);
            
            // Triangolo: centro -> next -> current (ordine importante per le normali!)
            faces.Add(new Face(new int[] { bottomCenterIndex, next, current }));
        }

        // Top cap (faccia piatta superiore)
        for (int i = 0; i < segments; i++)
        {
            int current = topStartIndex + i;
            int next = topStartIndex + ((i + 1) % segments);
            
            // Triangolo: centro -> current -> next (inverso rispetto a bottom per le normali esterne)
            faces.Add(new Face(new int[] { topCenterIndex, current, next }));
        }

        // Side faces (le pareti laterali)
        for (int i = 0; i < segments; i++)
        {
            int bottomCurrent = bottomStartIndex + i;
            int bottomNext = bottomStartIndex + ((i + 1) % segments);
            
            int topCurrent = topStartIndex + i;
            int topNext = topStartIndex + ((i + 1) % segments);
            
            // Quad = 2 triangoli
            // Triangolo 1
            faces.Add(new Face(new int[] { bottomCurrent, bottomNext, topCurrent }));
            // Triangolo 2
            faces.Add(new Face(new int[] { bottomNext, topNext, topCurrent }));
        }

        // 5. CREA LA PROBUILDERMESH
        ProBuilderMesh pbMesh = ProBuilderMesh.Create(vertices.ToArray(), faces.ToArray());
        pbMesh.gameObject.name = $"Cylinder_S{segments}_R{radius}_H{height}";

        // 6. SINCRONIZZA CON UNITY
        pbMesh.ToMesh();
        pbMesh.Refresh();

        Debug.Log($"Cilindro creato: {vertices.Count} vertici, {faces.Count} facce");
    }
}
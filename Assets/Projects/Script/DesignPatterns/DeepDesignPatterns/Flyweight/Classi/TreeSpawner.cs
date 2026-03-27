// Il riferimento condiviso vive fuori, nel MonoBehaviour
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public TreeModelSO sharedModel; // UN solo modello per tutti
    public TreeInstance[] treeInstances; // N istanze con solo dati primitivi
}

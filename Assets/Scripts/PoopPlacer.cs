using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    // Instantiate can only create prefabs
    // Prefabs are of type GameObject
    public GameObject PoopPrefab;
    
    public void Place(Vector3 corgiPosition)
    {
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
    }
}

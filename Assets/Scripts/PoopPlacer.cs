using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    // Instantiate can only create prefabs
    // Prefabs are of type GameObject
    public GameObject PoopPrefab;
    public Sounds Sounds;
    
    public void Place(Vector3 corgiPosition)
    {
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
        Sounds.PlayPoopSound();
    }
    
    public void CleanUpPlacedObjects()
    {
        List<GameObject> placedObjects =
            GameObject.FindGameObjectsWithTag(PoopPrefab.tag).ToList();

        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }
}

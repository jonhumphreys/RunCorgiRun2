using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;

    private bool isOkToCreate = true;
    private bool isActive = false;
    private Coroutine countdownCoroutine;
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;
    
    void Update()
    {
        if (!isActive) 
            return;
        
        if (isOkToCreate)
        {
            // place somewhere randomly on screen
            countdownCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait,
            maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        
        isOkToCreate = true;
    }

    public virtual void Place()
    {
        Instantiate(Prefab, 
            SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
    
    public void StartPlacing()
    {
        isActive = true;
        isOkToCreate = true;
    }
    
    public void StopPlacing()
    {
        isActive = false;
        CleanUpPlacedObjects();
        
        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);
    }
    
    public void CleanUpPlacedObjects()
    {
        List<GameObject> placedObjects =
            GameObject.FindGameObjectsWithTag(Prefab.tag).ToList();

        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;

    private bool isOkToCreate = true;
    private Coroutine countdownCoroutine;
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;
    
    void Update()
    {
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
}
using System.Collections;
using UnityEngine;

public class BeerPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;
    
    void Update()
    {
        StartCoroutine(CountdownUntilCreation());
    }

    IEnumerator CountdownUntilCreation()
    {
        float secondsToWait = Random.Range(minimumSecondsToWait,
            maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
    }

    public virtual void Place()
    {
        Instantiate(Prefab, 
            SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}

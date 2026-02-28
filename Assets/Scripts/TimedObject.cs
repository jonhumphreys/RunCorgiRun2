using System.Collections;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public float secondsOnScreen = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        // start a timer to remove it
        StartCoroutine(CountdownUntilDeath());
    }

    IEnumerator CountdownUntilDeath()
    {
        yield return new WaitForSeconds(secondsOnScreen);
        Destroy(gameObject);
    }
}

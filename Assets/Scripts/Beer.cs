using System.Collections;
using UnityEngine;

public class Beer : TimedObject
{
    public float pulseSpeed = 10f;    
    public float pulseAmount = 0.4f; 
    
    public void Start()
    {
        secondsOnScreen = GameParameters.BeerSecondsOnScreen;
        base.Start();
    }
    
    void Update()
    {
        float scale = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}

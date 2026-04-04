using UnityEngine;

public class Pill : TimedObject
{
        
    public float spinDegreesPerSecond = 360f; 
    
    public void Start()
    {
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        base.Start();
    }


    void Update()
    {
        transform.Rotate(0f, 0f, spinDegreesPerSecond * Time.deltaTime);
    }
}

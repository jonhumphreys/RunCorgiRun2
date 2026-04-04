using UnityEngine;

public class Bone : TimedObject
{
    public float waggleSpeed = 3f;
    public float waggleAngle = 45f;
    
    public void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
    }
    
    void Update()
    {
        float angle = Mathf.Sin(Time.time * waggleSpeed) * waggleAngle;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

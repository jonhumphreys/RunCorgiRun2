using UnityEngine;

public class Moonshine : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
    }
}

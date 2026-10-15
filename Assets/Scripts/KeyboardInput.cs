using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    public PoopPlacer PoopPlacer;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        
        if (keyboard.wKey.isPressed)
        {
            Corgi.MoveManually(Vector2.up);
        }
        else if (keyboard.sKey.isPressed)
        {
            Corgi.MoveManually(Vector2.down);
        }
        else if (keyboard.aKey.isPressed)
        {
            Corgi.MoveManually(Vector2.left);
        }
        else if (keyboard.dKey.isPressed)
        {
            Corgi.MoveManually(Vector2.right);
        }
        
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            PoopPlacer.Place(Corgi.GetPosition());
        }
    }
}

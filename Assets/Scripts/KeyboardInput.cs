using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    public PoopPlacer PoopPlacer;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        // wasPressedThisFrame v isPressed
        
        if (keyboard.wKey.isPressed)
        {
            Corgi.Move(Vector2.up);
        }
        else if (keyboard.sKey.isPressed)
        {
            Corgi.Move(Vector2.down);
        }
        else if (keyboard.aKey.isPressed)
        {
            Corgi.Move(Vector2.left);
        }
        else if (keyboard.dKey.isPressed)
        {
            Corgi.Move(Vector2.right);
        }
        
        if (keyboard.spaceKey.isPressed)
        {
            PoopPlacer.Place(Corgi.GetPosition());
        }
    }
}

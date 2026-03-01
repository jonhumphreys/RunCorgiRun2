using System;
using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    
    private SpriteRenderer corgiSpriteRenderer;
    private Coroutine soberUpCoroutine;
    private bool isDrunk = false;
    
    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        
        FaceCorrectDirection(direction);
        
        Vector2 movement = direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        corgiSpriteRenderer.transform.Translate(movement.x, movement.y, 0f);
        
        // simple v. good
        corgiSpriteRenderer.transform.position = 
            SpriteTools.ConstrainToScreen(corgiSpriteRenderer); 
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Beer")
        {
            GetDrunk();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Pill")
        {
            SoberUp();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Bone")
        {
            Destroy(other.gameObject);
        }
        
    }
    
    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }
        
        return direction;
    }
    
    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void ChangeToDrunkSprite()
    {
        corgiSpriteRenderer.sprite = DrunkSprite;
    }

    private void StartSoberingUp()
    {
        if (soberUpCoroutine != null)
            StopCoroutine(soberUpCoroutine);
        soberUpCoroutine = StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        ChangeToSoberSprite();
    }

    private void ChangeToSoberSprite()
    {
        corgiSpriteRenderer.sprite = SoberSprite;
    }
    
    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
            corgiSpriteRenderer.flipX = false;
        else if (direction.x < 0)
            corgiSpriteRenderer.flipX = true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

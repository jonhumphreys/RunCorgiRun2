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
    private bool isPlastered = false;
    
    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;
    
    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
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
        
        if (other.gameObject.tag == "Moonshine")
        {
            GetPlastered();
            Destroy(other.gameObject);
        }
        
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;
        
        Move(direction);
    }
    
    private void MoveRandomly()
    {
        int direction = lastRandomDirection;

        if (randomMoveCounter == 0)
        {
            direction = UnityEngine.Random.Range(0, 4);
            randomMoveCounter = UnityEngine.Random.Range(20, 40);
            lastRandomDirection = direction;
        }
        
        switch (direction)
        {
            case 0:
                Move(new Vector2(1, 0));
                break;
            case 1:
                Move(new Vector2(-1, 0));
                break;
            case 2:
                Move(new Vector2(0, 1));
                break;
            case 3:
                Move(new Vector2(0, -1));
                break;
        }
        
        randomMoveCounter--;
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
    
    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void Inebriate()
    {
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void GetDrunk()
    {
        if (isPlastered)
            return;
        
        isDrunk = true;
        Inebriate();
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
        isPlastered = false;
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

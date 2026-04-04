using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip Falling;
    public AudioClip Plop;
    public AudioClip Ding;
    public AudioClip Gulp;
    public AudioClip Pickup;
    public AudioClip BottleBreak;
    
    private AudioSource audioSource;
    
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }
    
    public void PlayFallingSound()
    {
        audioSource.PlayOneShot(Falling);
    }
    
    public void PlayPoopSound()
    {
        audioSource.PlayOneShot(Plop);
    }
    
    public void PlayBoneSound()
    {
        audioSource.PlayOneShot(Pickup);
    }
    
    public void PlayBeerSound()
    {
        audioSource.PlayOneShot(Gulp);
    }
    
    public void PlayPillSound()
    {
        audioSource.PlayOneShot(Ding);
    }
    
    public void PlayMoonshineSound()
    {
        audioSource.PlayOneShot(BottleBreak);
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
    }

}

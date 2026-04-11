using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public AudioClip GameMusic;
    public AudioClip MenuMusic;

    public AudioSource CurrentSource;
    public AudioSource IncomingSource;

    private float fadeDuration = 2f;
    private float maxVolume = 0.4f;

    void Awake()
    {
        CurrentSource.loop = true;
        IncomingSource.loop = true;
    }

    public void PlayMenuMusic()
    {
        if (CurrentSource.clip == null)
        {
            CurrentSource.clip = MenuMusic;
            CurrentSource.Play();
            return;
        }
        
        if (CurrentSource.clip == MenuMusic) 
            return;
        StartCoroutine(Crossfade(MenuMusic));
    }

    public void PlayGameMusic()
    {
        if (CurrentSource.clip == GameMusic) 
            return;
        StartCoroutine(Crossfade(GameMusic));
    }

    private IEnumerator Crossfade(AudioClip newClip)
    {
        IncomingSource.clip = newClip;
        IncomingSource.volume = 0f;
        IncomingSource.Play();

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            CurrentSource.volume = maxVolume - t;  
            IncomingSource.volume = t;       

            yield return null;
        }
        
        CurrentSource.Stop();
        CurrentSource.volume = maxVolume;
        
        (CurrentSource, IncomingSource) = (IncomingSource, CurrentSource);
    }
}
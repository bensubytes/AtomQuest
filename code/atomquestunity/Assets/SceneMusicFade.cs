using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicFade : MonoBehaviour
{
    public AudioSource musicSource;
    public float fadeOutTime = 2.0f;
    public float delayBeforeFade = 10.0f;

    private float elapsedTime;

    private void Start()
    {
        if (musicSource == null)
        {
            musicSource = GetComponent<AudioSource>();
        }
        
        elapsedTime = 0.0f;
    }

    private void Update()
    {
       
        elapsedTime += Time.deltaTime; 
        if (elapsedTime >= delayBeforeFade)
        {
            if (musicSource.isPlaying)
            {
                FadeOut();
            }
        }
    }

    private void FadeOut()
    {
       
        musicSource.volume -= Time.deltaTime / fadeOutTime;
        
        if (musicSource.volume <= 0.0f)
        {
            musicSource.Stop();
        }
    }
}

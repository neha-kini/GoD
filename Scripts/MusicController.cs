using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    public AudioSource levelMusic, victoryMusic, defeatMusic, explosionMusic, bossMusic;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopMusic()
    {
        levelMusic.Stop();
        victoryMusic.Stop();
        defeatMusic.Stop();
        explosionMusic.Stop();
        bossMusic.Stop();
    }

    public void PlayVictory()
    {
        StopMusic();
        victoryMusic.Play();
    }

    public void PlayDefeat()
    {
        StopMusic();
        defeatMusic.Play();
    }

    public void PlayExplosion()
    {
        StopMusic();
        explosionMusic.Play();
    }

    public void PlayBoss()
    {
        StopMusic();
        bossMusic.Play();
    }
}

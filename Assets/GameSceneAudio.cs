using UnityEngine;

public class GameSceneAudio : MonoBehaviour
{
    [Header("Game Scene Audio Settings")]
    [Tooltip("Ensures the background music continues playing in this scene")]
    public bool ensureMusicPlaying = true;
    public AudioSource bgmSource;
    void Start()
    {
        // Check if AudioManager exists and ensure music is playing
        if (AudioManager.instance != null && ensureMusicPlaying)
        {
            AudioManager.instance.PlayBGM();
        }
        if (AudioManager.instance == null && bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }
}
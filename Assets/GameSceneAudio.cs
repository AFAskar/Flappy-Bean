using UnityEngine;

public class GameSceneAudio : MonoBehaviour
{
    [Header("Game Scene Audio Settings")]
    [Tooltip("Ensures the background music continues playing in this scene")]
    public bool ensureMusicPlaying = true;

    void Start()
    {
        // Check if AudioManager exists and ensure music is playing
        if (AudioManager.instance != null && ensureMusicPlaying)
        {
            AudioManager.instance.PlayBGM();
        }
    }
}
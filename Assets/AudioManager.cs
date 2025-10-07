using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;

    void Awake()
    {
        // Singleton pattern - ensures only one AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // If no audio source is assigned, try to get one from this GameObject
            if (bgmSource == null)
                bgmSource = GetComponent<AudioSource>();

            // Ensure the audio source loops
            if (bgmSource != null)
            {
                bgmSource.loop = true;
                // If not already playing, start playing
                if (!bgmSource.isPlaying)
                {
                    bgmSource.Play();
                }
            }
        }
        else
        {
            // If another AudioManager already exists, destroy this one
            Destroy(gameObject);
        }
    }

    public void PlayBGM()
    {
        if (bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = Mathf.Clamp01(volume);
        }
    }

    public void PauseBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Pause();
        }
    }

    public void UnpauseBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.UnPause();
        }
    }
}
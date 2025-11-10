using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    private AudioSource music;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        music = gameObject.GetComponent<AudioSource>();
    }

    public void ToggleAudio()
    {
        if (music.isPlaying)
            music.Pause();
        else
            music.Play();
    }
}

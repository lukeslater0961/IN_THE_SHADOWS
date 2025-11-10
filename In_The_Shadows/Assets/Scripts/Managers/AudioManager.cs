using UnityEngine;
using UnityEngine.EventSystems;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSource music;

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

    public void ToggleAudio()
    {
		if (music.isPlaying)
            music.Pause();
        else
            music.Play();
		EventSystem.current.SetSelectedGameObject(null);
    }
}

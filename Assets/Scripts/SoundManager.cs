using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    
    public void SetMusicEnable(bool value)
    {
        if (value)
        {
            _music.Play();
        }
        else
        {
            _music.Pause();
        }
        
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}

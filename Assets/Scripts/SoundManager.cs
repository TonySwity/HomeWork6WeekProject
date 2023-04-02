using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    
    public void SetMusicEnable(bool value)
    {
        _music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}

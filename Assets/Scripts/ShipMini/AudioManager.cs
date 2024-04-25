using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource soundEffect;

    public void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }

    public void PlaySoundEffect()
    {
        soundEffect.Play();
    }
}

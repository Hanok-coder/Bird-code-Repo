using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("_____Audio Source_____")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("_____Audio Clip_____")]
    public AudioClip Background;
    public AudioClip Death;
    public AudioClip Fly;
    public AudioClip Cherry;

    void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
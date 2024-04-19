using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfxEffect;

    public AudioClip BackroundMusic;

    public AudioClip Walking;
    public AudioClip Sword;
    public AudioClip Jumping;
    public AudioClip CheckIn;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        music.clip = BackroundMusic;
        music.Play();
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxEffect.PlayOneShot(clip);
    }
}

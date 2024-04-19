using UnityEngine;

public class AudioController : MonoBehaviour
{
    //public AudioClip soundEventGameOver;
    public AudioClip soundEventReveal;
    public AudioClip soundEventYes;
    public AudioClip soundEventNo;
    
    [SerializeField] private CardManager cardManager;
    [SerializeField] private SceneController sceneController;
    
    private AudioSource audioSrc;
    

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    //TODO fix sound before destroy scene
    // public void PlaySoundGameOver()
    // {
    //     audioSrc.clip = soundEventGameOver;
    //     audioSrc.PlayOneShot(soundEventGameOver, 1f);
    // }
    [ContextMenu("Play Game Over Sound")]
    public void PlaySoundGameOver()
    {
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc.isPlaying) audioSrc.Stop();
        audioSrc.Play();
    }
    public void PlaySoundReveal()
    {
        audioSrc.clip = soundEventReveal;
        audioSrc.Play();
    }
    public void PlaySoundEventYes()
    {
        audioSrc.clip = soundEventYes;
        audioSrc.Play();
    }

    public void PlaySoundEventNo()
    {
        audioSrc.clip = soundEventNo;
        audioSrc.Play();
    }

    public void StopSound()
    {
        audioSrc.Stop();
    }
    
    private void OnEnable()
    {
        sceneController.OnMatchesGameOverSound += PlaySoundGameOver;
        cardManager.OnMatchesRevealSound += PlaySoundReveal;
        cardManager.OnMatchesYesSound += PlaySoundEventYes;
        cardManager.OnMatchesNoSound += PlaySoundEventNo;
    }

    private void OnDisable()
    {
        sceneController.OnMatchesGameOverSound -= PlaySoundGameOver;
        cardManager.OnMatchesRevealSound -= PlaySoundReveal;
        cardManager.OnMatchesYesSound -= PlaySoundEventYes;
        cardManager.OnMatchesNoSound -= PlaySoundEventNo;
    }
}


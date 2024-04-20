using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip soundEventGameOver;
    public AudioClip soundEventReveal;
    public AudioClip soundEventYes;
    public AudioClip soundEventNo;
    
    [SerializeField] private CardManager cardManager;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    
    private AudioSource audioSource;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //TODO consider for the refactor
    // public void PlaySoundByName(soundName)
    // {
    //     audioSource.clip = soundName;
    //     audioSource.Play();
    // }
    public void PlaySoundReveal()
    {
        audioSource.clip = soundEventReveal;
        audioSource.Play();
    }
    public void PlaySoundEventYes()
    {
        audioSource.clip = soundEventYes;
        audioSource.Play();
    }

    public void PlaySoundEventNo()
    {
        audioSource.clip = soundEventNo;
        audioSource.Play();
    }

    public void PlaySoundGameOver()
    {
        audioSource.clip = soundEventGameOver; 
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
    
    private void OnEnable()
    {
        cardManager.OnAllMatchesFound += PlaySoundGameOver;
        cardManager.OnMatchesRevealSound += PlaySoundReveal;
        cardManager.OnMatchesYesSound += PlaySoundEventYes;
        cardManager.OnMatchesNoSound += PlaySoundEventNo;
    }

    private void OnDisable()
    {
        cardManager.OnAllMatchesFound -= PlaySoundGameOver;
        cardManager.OnMatchesRevealSound -= PlaySoundReveal;
        cardManager.OnMatchesYesSound -= PlaySoundEventYes;
        cardManager.OnMatchesNoSound -= PlaySoundEventNo;
    }
    
    public IEnumerator PlayEndGameSound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        sceneSwitcher.NextScene();
    }
}


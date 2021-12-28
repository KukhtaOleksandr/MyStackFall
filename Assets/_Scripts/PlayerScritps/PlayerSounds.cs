using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    enum Sound
    {
        Off=0,
        On=1
    }
    private bool isSoundOn;
    [SerializeField] private AudioClip bounceOffClip, deadClip, winClip, destroyClip, invincibleDestroyClip;
    private AudioSource audioSource;
    private void Start()
    {
        if(PlayerPrefs.GetInt("Sound", (int) Sound.On)==(int) Sound.On)
        {
            isSoundOn=true;
        }
        else
        {
            isSoundOn=false;
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void OnSoundStateChanged(bool IsSoundOn)
    {
        isSoundOn=IsSoundOn;
    }
    public void OnBounceOffPlay()
    {
        if(isSoundOn)
        audioSource.PlayOneShot(bounceOffClip, .5f);
    }
    public void OnPlayerDeadPlay()
    {
        if(isSoundOn)
        audioSource.PlayOneShot(deadClip, .5f);
    }
    public void OnWinPlay()
    {
        if(isSoundOn)
        audioSource.PlayOneShot(winClip, .75f);
    }
    public void OnTileDestroyedPlay()
    {
        if(isSoundOn)
        audioSource.PlayOneShot(destroyClip, .5f);
    }
    public void OnInvincibleDestroyPlay()
    {
        if(isSoundOn)
        audioSource.PlayOneShot(invincibleDestroyClip, .5f);
    }

}

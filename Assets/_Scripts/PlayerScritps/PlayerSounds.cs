using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip bounceOffClip, deadClip, winClip, destroyClip, invincibleDestroyClip;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnBounceOffPlay()
    {
        audioSource.PlayOneShot(bounceOffClip, .5f);
    }
    public void OnPlayerDeadPlay()
    {
        audioSource.PlayOneShot(deadClip, .5f);
    }
    public void OnWinPlay()
    {
        audioSource.PlayOneShot(winClip, .75f);
    }
    public void OnTileDestroyedPlay()
    {
        audioSource.PlayOneShot(destroyClip, .5f);
    }
    public void OnInvincibleDestroyPlay()
    {
        audioSource.PlayOneShot(invincibleDestroyClip, .5f);
    }

}

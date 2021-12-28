using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoundUI : MonoBehaviour
{
    enum Sound
    {
        Off=0,
        On=1
    }
    public UnityEvent<bool> ChangedSoundState;
    private bool isSoundOn;
    [SerializeField] Sprite SoundOff,SoundOn;
    private void Awake() 
    {
        //isSoundOn=PlayerPrefs.GetInt("Sound", (int) Sound.On);
        if(PlayerPrefs.GetInt("Sound", (int) Sound.On)==(int)Sound.On)
        {
            isSoundOn=true;
            GetComponent<Image>().sprite=SoundOn;
        }
        else
        {
            isSoundOn=false;
            GetComponent<Image>().sprite=SoundOff;
        }
    }
    public void ChangeSpriteToOpposite()
    {
        if(isSoundOn)
        {
            isSoundOn=false;

            ChangedSoundState?.Invoke(isSoundOn);

            GetComponent<Image>().sprite=SoundOff;
            PlayerPrefs.SetInt("Sound", (int) Sound.Off);
        }
        else
        {
            isSoundOn=true;

            ChangedSoundState?.Invoke(isSoundOn);
            
            GetComponent<Image>().sprite=SoundOn;
            PlayerPrefs.SetInt("Sound", (int) Sound.On);
        }
    }

}

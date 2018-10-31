using UnityEngine;
using UnityEngine.UI;


public  class GameAudio : MonoBehaviour {

    [SerializeField]
    private GameObject muteButton;
    public Sprite audioOff;
    public Sprite audioOn;
    public static bool isPlaying = false;
    private new AudioSource audio;


   

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        if (!isPlaying)
        {
            audio.Stop();
            muteButton.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            audio.Play();
            muteButton.GetComponent<Image>().sprite = audioOn;
        }

    }

    public bool IsAudioPlaying()
    {
        return isPlaying;
    }

   
    public void SoundControl()
    {
        if (isPlaying)
        {
            audio.Stop();
            muteButton.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            audio.Play();
            muteButton.GetComponent<Image>().sprite = audioOn;
        }
        isPlaying = !isPlaying;
       
    }


}

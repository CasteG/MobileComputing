using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
   [SerializeField] private AudioMixer myMixer;
   [SerializeField] private Slider musicSlider;
   [SerializeField] private Slider soundEffects;

   public void SetMusicVolume() 
   {
      float volume = musicSlider.value;
      myMixer.SetFloat("music", Mathf.Log10(volume)*20);
   }
}

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderMusic, sliderSFX;
    private void Start() { LoadSliders(); }
    private void LoadSliders()
    {
        sliderMusic.value = AudioManager.instance.GetVolumenMusic();
        sliderSFX.value = AudioManager.instance.GetVolumenSFX();
    }
    public void SetVolumeMusic(float sliderValue)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
        AudioManager.instance.SetVolumenMusic(sliderValue);
    }
    public void SetVolumeSFX(float sliderValue)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
        AudioManager.instance.SetVolumenSFX(sliderValue);
    }
}

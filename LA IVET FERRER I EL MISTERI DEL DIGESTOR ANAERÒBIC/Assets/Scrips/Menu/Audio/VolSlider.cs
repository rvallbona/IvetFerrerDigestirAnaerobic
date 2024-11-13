using UnityEngine;
using UnityEngine.UI;

public class VolSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource feedbackSound;
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    private void OnVolumeChanged(float volume) { feedbackSound.Play(); }
}

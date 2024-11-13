using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioMixer audioMixer;
    private float volumenMusic = 1, volumenSFX = 1;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(this.gameObject); }
    }
    private void Start(){ LoadAudio(); }
    private void LoadAudio()
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volumenMusic) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(volumenSFX) * 20);        
    }
    public void SetVolumenMusic(float vol) { volumenMusic = vol; Debug.Log("Music: " + volumenMusic); }
    public void SetVolumenSFX(float vol) { volumenSFX = vol; Debug.Log("SFX: " + volumenSFX); }
    public float GetVolumenMusic() { return volumenMusic; }
    public float GetVolumenSFX() { return volumenSFX; }
}

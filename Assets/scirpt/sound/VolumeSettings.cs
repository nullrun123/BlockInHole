
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider SFXslider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else //เช็คว่ามีการปรับค่ายัง ถ้ายังกํจะใช้ setmusic , setsfx
        {
            SetMusicVolume();
            SetSFXVolume(); 
        }
   
    }
    public void SetMusicVolume()
    {
        float volume = musicslider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);//ค่าที่ให้slider ตรงกับmusic
        PlayerPrefs.SetFloat("musicVolume", volume); // เก้บค่าที่ปรับไว้่ลงplayerPrefs ไว้ใช้หน้าอื่น หรือเริ่มscene ใหท่ก็จะใช้ค่าที่เราปรับ
    }

    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);//ค่าที่ให้slider ตรงกับmusic
        PlayerPrefs.SetFloat("SFXVolume", volume); // เก้บค่าที่ปรับไว้่ลงplayerPrefs ไว้ใช้หน้าอื่น หรือเริ่มscene ใหท่ก็จะใช้ค่าที่เราปรับ


    }

    public void LoadVolume()
    {
        musicslider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXslider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}

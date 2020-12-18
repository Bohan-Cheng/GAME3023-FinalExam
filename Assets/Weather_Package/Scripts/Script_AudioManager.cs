using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource AmbientAudio;
    [SerializeField] AudioSource RainAudio;
    [SerializeField] AudioSource ThunderAudio;
    [SerializeField] AudioSource OtherAudio;


    [Header("Audio Clips")]
    [SerializeField] AudioClip clip_birds;
    [SerializeField] AudioClip clip_wind;
    [SerializeField] AudioClip clip_snowWind;
    [SerializeField] AudioClip clip_lightRian;
    [SerializeField] AudioClip clip_HeavyRian;
    [SerializeField] AudioClip clip_CloseTunder;
    [SerializeField] AudioClip clip_FarTunder;
    [SerializeField] Script_WeatherSystem WS;

    [SerializeField] Animator LightningAnim;

    Script_AudioManager instance;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null) { instance = this; }
        else { Destroy(this); }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) { PlayThunder(); }

        if (!IsInvoking() && WS.Weather == EWeather.Strom) 
        { Invoke("PlayThunder", Random.Range(8, 15)); }
        else if(IsInvoking() && WS.Weather != EWeather.Strom) 
        { CancelInvoke(); }
    }

    void PlayThunder()
    {
        LightningAnim.SetTrigger("Thunder");
        ThunderAudio.Play();
    }

    public void UpdateWeather(EWeather weather)
    {
        switch (weather)
        {
            case EWeather.Sunny:
                AmbientAudio.clip = clip_birds;
                AmbientAudio.Play();
                break;
            case EWeather.Rainy:
                RainAudio.clip = clip_lightRian;
                RainAudio.Play();
                break;
            case EWeather.Strom:
                AmbientAudio.clip = clip_wind;
                OtherAudio.clip = clip_HeavyRian;
                ThunderAudio.clip = clip_FarTunder;
                AmbientAudio.Play();
                OtherAudio.Play();
                break;
            case EWeather.Snow:
                OtherAudio.clip = clip_snowWind;
                OtherAudio.Play();
                break;
        }
    }

}

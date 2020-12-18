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

        // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            PlayThunder();
        }
        if (!IsInvoking() && WS.Weather == EWeather.Strom)
        {
            int RandSec = Random.Range(8, 15);
            Invoke("PlayThunder", RandSec);
        }
        else if(IsInvoking() && WS.Weather != EWeather.Strom)
        {
            CancelInvoke();
        }
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
                StopAllAudio();
                AmbientAudio.clip = clip_birds;
                AmbientAudio.Play();
                break;
            case EWeather.Rainy:
                StopAllAudio();
                RainAudio.clip = clip_lightRian;
                RainAudio.Play();
                break;
            case EWeather.Strom:
                StopAllAudio();
                AmbientAudio.clip = clip_wind;
                OtherAudio.clip = clip_HeavyRian;
                ThunderAudio.clip = clip_FarTunder;
                AmbientAudio.Play();
                OtherAudio.Play();
                break;
            case EWeather.Snow:
                StopAllAudio();
                OtherAudio.clip = clip_snowWind;
                OtherAudio.Play();
                break;
        }
    }

    void StopAllAudio()
    {
        //AmbientAudio.Stop();
        //RainAudio.Stop();
        //ThunderAudio.Stop();
        //OtherAudio.Stop();
    }
}

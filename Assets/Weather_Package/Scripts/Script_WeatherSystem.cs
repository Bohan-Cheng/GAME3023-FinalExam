using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWeather 
{
    Sunny,
    Rainy,
    Strom,
    Snow,
    None
};

public class Script_WeatherSystem : MonoBehaviour
{
    [Header("Defualt")]
    public Animator anim;
    [SerializeField] Script_ParticleManager ParticleMana;
    [SerializeField] Script_AudioManager AudioMana;

    [Header("WeatherContorl")]
    public bool IsPlaying = false;
    public EWeather Weather = EWeather.Sunny;
    private EWeather lastWeather = EWeather.None;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (lastWeather != Weather)
        {
            ParticleMana.UpdateWeather(Weather, lastWeather);
            AudioMana.UpdateWeather(Weather);
            lastWeather = Weather;
        }

        if(IsPlaying)
        {
            Invoke("ResetIsPlaying", 5.0f);
        }
    }

    void ResetIsPlaying()
    {
        IsPlaying = false;
    }
}

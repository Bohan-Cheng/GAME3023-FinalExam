using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem Rain;
    [SerializeField] ParticleSystem Storm;
    [SerializeField] ParticleSystem Snow;
    [SerializeField] ParticleSystem Leaf;
    [SerializeField] SpriteRenderer OvercastCover;
    [SerializeField] SpriteRenderer SnowCover;
    [SerializeField] Script_Daynight Sunlight;
    [SerializeField] Script_WeatherSystem WS;


    public void UpdateWeather(EWeather weather, EWeather last)
    {
        WS.IsPlaying = true;
        switch (weather)
        {
            case EWeather.Sunny:
                StopAllParticles(last);
                Invoke("StartSunny", 5.0f);
                break;
            case EWeather.Rainy:
                StopAllParticles(last);
                if(!(last == EWeather.Strom))
                    Invoke("StartRainy", 5.0f);
                break;
            case EWeather.Strom:
                if(!(last == EWeather.Rainy))
                    StopAllParticles(last);
                WS.anim.Play("Anim_StormStart");
                break;
            case EWeather.Snow:
                StopAllParticles(last);
                Invoke("StartSnow", 5.0f);
                break;
        }
    }

    void StopAllParticles(EWeather weather)
    {
        switch (weather)
        {
            case EWeather.Sunny:
                WS.anim.Play("Anim_SunnyEnd");
                break;
            case EWeather.Rainy:
                WS.anim.Play("Anim_lightRainEnd");
                break;
            case EWeather.Strom:
                WS.anim.Play("Anim_StormEnd");
                break;
            case EWeather.Snow:
                WS.anim.Play("Anim_SnowEnd");
                break;
        }
    }
    void StartSunny()
    {
        if (Sunlight.IsDayTime())
        {
            WS.IsPlaying = true;
            WS.anim.Play("Anim_SunnyStart");
        }
    }

    void StartRainy()
    {
        WS.IsPlaying = true;
        WS.anim.Play("Anim_lightRainStart");
    }

    void StartSnow()
    {
        WS.IsPlaying = true;
        WS.anim.Play("Anim_SnowStart");
    }

}

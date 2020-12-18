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
    [SerializeField] float MinTime = 10;
    [SerializeField] float MaxTime = 50;
    public bool IsPlaying = false;
    public EWeather Weather = EWeather.Sunny;
    private EWeather lastWeather = EWeather.None;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(ChangeWeather());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 10;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1;
        }

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

    IEnumerator ChangeWeather()
    {
        while (true)
        {
            int weather = Random.Range(0, (int)EWeather.None);
            float sec = Random.Range(10+MinTime, 10+MaxTime);
            yield return new WaitForSeconds(sec);

            switch ((EWeather)weather)
            {
                case EWeather.Sunny:
                    if (Weather != EWeather.Strom)
                    {
                        Weather = (EWeather)weather;
                    }
                    else
                    {
                        Weather = EWeather.Rainy;
                    }
                    break;
                case EWeather.Rainy:
                    Weather = (EWeather)weather;
                    break;
                case EWeather.Strom:
                    if (Weather == EWeather.Rainy)
                    {
                        Weather = (EWeather)weather;
                    }
                    else
                    {
                        Weather = EWeather.Rainy;
                    }
                    break;
                case EWeather.Snow:
                    if (Weather != EWeather.Strom)
                    {
                        Weather = (EWeather)weather;
                    }
                    else
                    {
                        Weather = EWeather.Rainy;
                    }
                    break;
            }
        }

    }
}

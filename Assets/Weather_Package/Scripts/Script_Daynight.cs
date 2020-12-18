using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Script_Daynight : MonoBehaviour
{
    private Light2D light;
    private bool ReachedDay = false;
    [SerializeField] float TimeSpeed;
    [SerializeField] float MinIntensity;
    [SerializeField] float MaxIntensity;

    [SerializeField] bool StartFromDay = false;
    [SerializeField] Script_WeatherSystem WS;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        if(StartFromDay)
        { light.intensity = MaxIntensity; }
        else
        { light.intensity = MinIntensity; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ReachedDay)
        {
            if (light.intensity < MaxIntensity) { light.intensity += TimeSpeed * Time.deltaTime; }
            else { ReachedDay = true; }
        }
        else
        {
            if (light.intensity > MinIntensity) { light.intensity -= TimeSpeed * Time.deltaTime; }
            else { ReachedDay = false; }
        }

        if (WS && WS.Weather == EWeather.Sunny)
        {
            if (light.intensity >= 0.5f)
            {
                if (!WS.IsPlaying)
                {
                    WS.IsPlaying = true;
                    WS.anim.Play("Anim_SunnyStart");
                }
            }
            else if(ReachedDay)
            {
                if (!WS.IsPlaying)
                {
                    WS.IsPlaying = true;
                    WS.anim.Play("Anim_SunnyEnd");
                }
            }
        }
    }


    public bool IsDayTime()
    {
        return light.intensity >= 0.5f;
    }
}

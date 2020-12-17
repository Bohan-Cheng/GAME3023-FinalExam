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
    [SerializeField] AudioClip clip_lightRian;
    [SerializeField] AudioClip clip_HeavyRian;
    [SerializeField] AudioClip clip_CloseTunder;
    [SerializeField] AudioClip clip_FarTunder;

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
        
    }
}

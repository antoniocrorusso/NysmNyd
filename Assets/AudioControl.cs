using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    //float m_MySliderValue;
    public bool toggleSong;

    void Start()
    {
        //Initiate the Slider value to half way
        //m_MySliderValue = 1.0f;
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Play the AudioClip attached to the AudioSource on startup
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (toggleSong == true)
            {
                m_MyAudioSource.pitch = 0.8f;
                toggleSong = false;
            }
            else if (toggleSong == false)
            {
                m_MyAudioSource.pitch = 1.0f;
                toggleSong = true;
            }
        }
    }
}

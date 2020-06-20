using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] float fadeSceconds = 1.0f;

    bool is_fade = false;

    float fade_time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (is_fade)
        {
            fade_time += Time.deltaTime;
            if (fade_time > fadeSceconds)
            {
                is_fade = false;
                fade_time = fadeSceconds;
            }
            audioSource.volume = 1 - (float)(fade_time / fadeSceconds);
        }
    }

    public void Fadeout(float fade_seconds = 0){
        if(fade_seconds>0)fadeSceconds = fade_seconds;
        is_fade = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SoundFade : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] int waitMSeconds = 1000;
    [SerializeField] float fadeSceconds = 1.0f;
    bool is_fade_in = false;
    bool is_fade_out = false;
    float fade_time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (is_fade_in)
        {
            fade_time += Time.deltaTime;
            if (fade_time > fadeSceconds)
            {
                is_fade_in = false;
                fade_time = fadeSceconds;
            }
            float test = 0 + (float)(fade_time / fadeSceconds);

            audioSource.volume = 0 + (float)(fade_time / fadeSceconds);
        }
        if (is_fade_out)
        {
            fade_time += Time.deltaTime;
            if (fade_time > fadeSceconds)
            {
                is_fade_out = false;
                fade_time = fadeSceconds;
            }
            audioSource.volume = 1 - (float)(fade_time / fadeSceconds);
        }
    }

    public async void Fadein(int wait_mseconds = 0, float fade_seconds = 0)
    {
        audioSource.volume = 0;
        if (wait_mseconds > 0) waitMSeconds = wait_mseconds;
        if (fade_seconds > 0) fadeSceconds = fade_seconds;
        if (waitMSeconds > 0)
        {
            await Task.Delay(waitMSeconds);
        }
        fade_time = 0;
        is_fade_in = true;
        is_fade_out = false;
    }

    public async void Fadeout(int wait_mseconds = 0, float fade_seconds = 0)
    {
        if (wait_mseconds > 0) waitMSeconds = wait_mseconds;
        if (fade_seconds > 0) fadeSceconds = fade_seconds;
        if (waitMSeconds > 0)
        {
            await Task.Delay(waitMSeconds);
        }
        fade_time = 0;
        is_fade_in = false;
        is_fade_out = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    float speed = 0.01f;  //透明化の速さ
    float red, green, blue;  //RGBを操作するための変数

    bool is_fade_in = false;
    bool is_fade_out = false;

    [SerializeField] float fadeSeconds = 1;
    [SerializeField] int waitMSeconds = 1000;
    float fade_time = 0;
    [SerializeField] Image image = null;

    System.Action callback_ = null;
    public System.Action FadeinCallback{
        set { callback_ = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(image == null) image = gameObject.GetComponent<Image>();
        //Panelの色を取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_fade_in)
        {
            fade_time += speed;
            float a = (float)(fade_time / fadeSeconds);
            // fadein finish
            if (fade_time > fadeSeconds)
            {
                is_fade_in = false;
                fade_time = 0;

                if(callback_ !=null){
                    callback_();
                }
                return;
            }
            image.color = new Color(red, green, blue, a);
        }

        if(is_fade_out){
            fade_time += speed;
            // fadein finish
            if (fade_time > fadeSeconds)
            {
                is_fade_out = false;
                fade_time = 0;

                if (callback_ != null)
                {
                    callback_();
                }
                return;
            }
            float a = 1 - (float)(fade_time / fadeSeconds);
            image.color = new Color(red, green, blue, a);
        }
    }

    public async void Fadein(int wait_mseconds = 0, float fade_seconds = 0){

        if(wait_mseconds>0) waitMSeconds = wait_mseconds;
        if (fade_seconds > 0) fadeSeconds = fade_seconds;
        if(waitMSeconds > 0){
            await Task.Delay(waitMSeconds);
        }
        is_fade_in = true;
        is_fade_out = false;
    }

    public async void Fadeout(int wait_mseconds = 0, float fade_seconds = 0)
    {

        if (wait_mseconds > 0) waitMSeconds = wait_mseconds;
        if (fade_seconds > 0) fadeSeconds = fade_seconds;
        if (waitMSeconds > 0)
        {
            await Task.Delay(waitMSeconds);
        }
        is_fade_out = true;
        is_fade_in = false;
    }
}

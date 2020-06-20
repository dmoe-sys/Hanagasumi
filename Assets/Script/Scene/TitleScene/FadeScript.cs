using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class FadeScript : MonoBehaviour
{
    public float speed = 0.01f;  //透明化の速さ
    float red, green, blue;  //RGBを操作するための変数

    bool is_fade = false;
    [SerializeField] float fadeSeconds = 1;
    [SerializeField] int waitMSeconds = 1000;
    float fade_time = 0;
    [SerializeField] Image image = null;

    // Start is called before the first frame update
    void Start()
    {
        //Panelの色を取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);

            alfa += speed;
        }
        */

        if (is_fade)
        {
            //if(Time.deltaTime > 1)return;
            fade_time += speed;
            if (fade_time > fadeSeconds)
            {
                is_fade = false;
                fade_time = fadeSeconds;
            }
            float a = (float)(fade_time / fadeSeconds);

            image.color = new Color(red, green, blue, a);

            //Debug.LogFormat("alpha {0}",a);

        }
    }

    public async void Fadein(int wait_mseconds = 0 , float fade_seconds = 0){

        if(wait_mseconds>0) waitMSeconds = wait_mseconds;
        if (fade_seconds > 0) fadeSeconds = fade_seconds;
        if(waitMSeconds > 0){
            await Task.Delay(waitMSeconds);
        }
        is_fade = true;
    }
}

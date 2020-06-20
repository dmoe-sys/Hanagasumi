using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Threading.Tasks;

public class FireMovie : MonoBehaviour
{
    public VideoPlayer vplayer1 = null;
    public VideoPlayer vplayer2 = null;

    bool isInit = false;
    int count = 5;
    // Start is called before the first frame update
    void Start()
    {
        vplayer2.gameObject.SetActive(false);
    }

    void init()
    {
        if (vplayer1.renderMode == UnityEngine.Video.VideoRenderMode.CameraFarPlane)
        {
            vplayer1.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        }
        if (vplayer2.renderMode == UnityEngine.Video.VideoRenderMode.CameraFarPlane)
        {
            vplayer2.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            count--;
            return;
        }

        if (!isInit)
        {
            init();
        }
    }

    public async void ChangeVideo()
    {
        vplayer2.gameObject.SetActive(true);
        //vplayer1.gameObject.SetActive(false);
        await Task.Delay(500);
        vplayer1.gameObject.SetActive(false);
    }
}

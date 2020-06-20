using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Fire_01 : MonoBehaviour
{
    public VideoClip videoClip;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        var videoPlayer = screen.AddComponent<VideoPlayer>(); //videoPlayerコンポーネント

        videoPlayer.source = VideoSource.VideoClip; //動画ソースの設定
        videoPlayer.clip = videoClip;

        videoPlayer.isLooping = true; //ループの設定
    }
    public void VPControl()
    {
        var videoPlayer = GetComponent<VideoPlayer>();

        if (Input.GetMouseButtonUp(0)) //ボタンを押した時の処理
        {
            videoPlayer.Stop(); //動画を停止する
        }



    }
}

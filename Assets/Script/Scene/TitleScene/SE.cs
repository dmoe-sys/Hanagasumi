using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip SE01;
    AudioSource audioSource;
    bool actevate = false;
    // Start is called before the first frame update
    void Start()
    {
        actevate = true;
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //マウス左クリック押したら音が鳴る
        if (Input.GetMouseButtonUp(0) && actevate)
        {
            actevate = false;
            audioSource.PlayOneShot(SE01);
        }
    }
}

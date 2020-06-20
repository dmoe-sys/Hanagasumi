using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] FireMovie fire_movie = null;
    [SerializeField] Sound sound = null;
    [SerializeField] FadeScript black = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //ボタンを押した時の処理
        {
            fire_movie.ChangeVideo();
            sound.Fadeout(1);
            black.Fadein();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] FireMovie fire_movie = null;
    [SerializeField] Sound sound = null;
    [SerializeField] FadeScript black = null;

    bool is_click = false;

    // Start is called before the first frame update
    void Start()
    {
        black.FadeinCallback = Activate;
        black.Fadeout();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && is_click == true) //ボタンを押した時の処理
        {
            fire_movie.ChangeVideo();
            sound.Fadeout(1);
            black.Fadein();
        }
    }

    void Activate(){
        is_click = true;
        black.FadeinCallback = ChangeMenuScene;
    }

    void ChangeMenuScene(){
        SceneManager.LoadScene("MenuScene");
    }
    
}


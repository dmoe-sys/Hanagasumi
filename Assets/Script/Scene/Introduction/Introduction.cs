using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    const int START_DELAY_SECONDS = 3000;
    [SerializeField] TextController text = null;
    [SerializeField] FadeScript fade = null;
    [SerializeField] GameObject first_content_bg = null;
    [SerializeField] VideoPlayer movie = null;
    [SerializeField] SoundFade audio = null;

    bool is_movie_complete_call = false;


    // Start is called before the first frame update
    void Start()
    {
        ContentDelayStart(START_DELAY_SECONDS);

    }

    // Update is called once per frame
    void Update()
    {
        if(movie.gameObject.activeSelf != true) return;
        if ((ulong)movie.frame == movie.frameCount -10 && is_movie_complete_call == false)
        {
            is_movie_complete_call = true;
            MovieComplete();
            return;
        }
    }

    public async void ContentDelayStart(int wait_mseconds = 0)
    {
        if (wait_mseconds > 0)
        {
            await Task.Delay(wait_mseconds);
        }
        text.Show(FirstContentEnd);
    }

    void FirstContentEnd()
    {
        fade.FadeinCallback = StartSecondContent;
        fade.Fadein(0, 2);
        audio.Fadeout(0, 2);
    }

    void StartSecondContent()
    {
        fade.FadeinCallback = null;
        text.Hide();
        first_content_bg.SetActive(false);
        fade.Fadeout(500, 0.1f);

        // play movie
        movie.gameObject.SetActive(true);
    }

    void MovieComplete(){
        SceneManager.LoadScene("PlayScene");
    }

}

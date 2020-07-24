using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScene : MonoBehaviour
{
    [SerializeField] FadeScript fade = null;
    [SerializeField] SoundFade sound_fade = null;
    string change_scene_name_ = "";

    bool is_click = false;
    public bool IsClick
    {
        get { return is_click; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(sound_fade != null){
            sound_fade.Fadein();
        }
        if(fade != null){
            fade.FadeinCallback = Activate;
            fade.Fadeout();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Activate()
    {
        is_click = true;
    }

    public void ChangeScene(string scene_name)
    {
        if (!is_click) return;
        fade.FadeinCallback = InnerChangeScene;
        change_scene_name_ = scene_name;
        if (fade != null) fade.Fadein();
        if (sound_fade != null) sound_fade.Fadeout();
    }

    void InnerChangeScene()
    {
        if (change_scene_name_ != "")
        {
            SceneManager.LoadScene(change_scene_name_);
        }
    }
}

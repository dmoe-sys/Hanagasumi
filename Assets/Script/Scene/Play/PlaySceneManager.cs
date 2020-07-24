using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneManager
{
    private static PlaySceneManager instance_ = null;
    public static PlaySceneManager Instance {
        get {
            if(instance_ == null) instance_ = new PlaySceneManager();
            return instance_;
        }
    }

    private static readonly string PLAY_SCENE_PLEFAB_PATH = "PlayScene/Scene/Scene";
    private int play_scene_id_ = 1;
    private PlaySceneBase play_scene_ = null;
    private Transform play_scene_trans_ = null;
    System.Action finish_callback_ = null;
    public System.Action FinishCallback
    {
        set { finish_callback_ = value; }
    }

    public void Start(Transform play_scene_trans){
        play_scene_trans_ = play_scene_trans;
        play_scene_id_ = 1;
        play_scene_ = CreateScene(play_scene_id_, play_scene_trans_);
    }

    public void ChangeScene(int scene_id){
        DeleteScene(play_scene_);
        play_scene_id_ = scene_id;
        play_scene_ = CreateScene(play_scene_id_, play_scene_trans_);
    }

    public void  Finish(){
        DeleteScene(play_scene_);
        if(finish_callback_ != null) finish_callback_();
    }

    private PlaySceneBase CreateScene(int scene_id, Transform trans){
        GameObject prefab = Resources.Load(PLAY_SCENE_PLEFAB_PATH + scene_id) as GameObject;
        return MonoBehaviour.Instantiate(prefab, trans).GetComponent<PlaySceneBase>();
    }

    private void DeleteScene(PlaySceneBase scene){
        if(scene == null) return;
        GameObject.Destroy(scene.gameObject);
    }
}

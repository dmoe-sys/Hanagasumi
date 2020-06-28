using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuScene : MonoBehaviour
{
    private float title_time;  //経過時間カウント用
    private bool flg = false;
    // Start is called before the first frame update
    void Start()
    {
        title_time = 0.0f;  //経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        if(flg == true){
            title_time += Time.deltaTime;  //経過時間をカウント
            if (title_time >= 3.0f)
            {
                flg = false;
                SceneManager.LoadScene("MenuScene"); //３秒後に画面遷移（MenuSceneへ移動）
            }
        }
        if (Input.GetMouseButtonUp(0)) //ボタンを押した時の処理
        {
            flg = true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene1 : PlaySceneBase
{
    void Finish()
    {
        PlaySceneManager.Instance.ChangeScene(2);
    }
}

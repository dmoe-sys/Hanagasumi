using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene2 : PlaySceneBase
{
    void Finish()
    {
        PlaySceneManager.Instance.ChangeScene(3);
    }
}

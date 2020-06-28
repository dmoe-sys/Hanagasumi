using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartB : MonoBehaviour
{
    public void PushButton()
    {
        Camera.main.GetComponent<BaseScene>().ChangeScene("IntroductionScene");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

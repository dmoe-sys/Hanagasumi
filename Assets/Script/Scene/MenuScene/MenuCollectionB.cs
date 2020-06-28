using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCollectionB : MonoBehaviour
{
    public void PushButton()
    {
        Camera.main.GetComponent<BaseScene>().ChangeScene("CollectionScene");
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

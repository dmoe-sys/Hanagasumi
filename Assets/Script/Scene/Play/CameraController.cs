using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera camera_ = null;
    [SerializeField] Vector3 start_postion_ = new Vector3();

    Transform camera_trans_ = null;

    [SerializeField] float speed_ = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        camera_trans_ = camera_.transform;
        camera_trans_.position = start_postion_;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = camera_trans_.position;
        if (Input.GetButton("Left"))
        {
            pos.x -= speed_;
        }
        if (Input.GetButton("Right"))
        {
            pos.x += speed_;
        }
        if (Input.GetButton("Front"))
        {
            pos.z += speed_;
        }
        if (Input.GetButton("Back"))
        {
            pos.z -= speed_;
        }
        camera_trans_.position = pos;
    }
}

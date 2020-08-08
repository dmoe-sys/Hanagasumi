using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 start_postion_ = new Vector3();
    [SerializeField] Animator animator_ = null;
    [SerializeField] Animator head_animator_ = null;
    [SerializeField] Animator haed_turn_animator_ = null;


    Transform player_trans_ = null;

    [SerializeField] float speed_ = 0.1f;
    [SerializeField] float run_speed_ = 0.2f;

    bool is_squat_ = false;
    bool is_turn_ = false;



    // Start is called before the first frame update
    void Start()
    {
        player_trans_ = gameObject.transform;
        player_trans_.position = start_postion_;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player_trans_.position;
        bool is_move_key_press = false;
        bool is_run_key_press = false;
        float speed = speed_;

        if (Input.GetButton("Run"))
        {
            if (is_squat_ == false)
            {
                is_run_key_press = true;
                speed = run_speed_;
            }
        }

        if (Input.GetButton("Left"))
        {
            pos.x -= speed;
            is_move_key_press = true;
        }
        if (Input.GetButton("Right"))
        {
            pos.x += speed;
            is_move_key_press = true;
        }
        if (Input.GetButton("Front"))
        {
            pos.z += speed;
            is_move_key_press = true;
        }
        if (Input.GetButton("Back"))
        {
            pos.z -= speed;
            is_move_key_press = true;
        }
        if (Input.GetButton("Squat"))
        {
            head_animator_.SetBool("Squat", true);
            is_squat_ = true;
        }
        else
        {
            head_animator_.SetBool("Squat", false);
            is_squat_ = false;
        }
        if (Input.GetButton("Turn"))
        {
            haed_turn_animator_.SetBool("Turn", true);
            is_turn_ = true;
            Debug.Log("Turn");


        }
        else
        {
            haed_turn_animator_.SetBool("Turn", false);
            is_turn_ = false;
        }

        player_trans_.position = pos;
        if (is_run_key_press == false)
        {
            animator_.SetBool("Walk", is_move_key_press);
        }
        else
        {
            animator_.SetBool("Walk", false);
        }
        animator_.SetBool("Run", is_run_key_press && is_move_key_press);

    }
}

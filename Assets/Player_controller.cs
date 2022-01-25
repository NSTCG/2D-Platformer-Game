using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_controller : MonoBehaviour
{

    public float speed_walk;
    public float speed_run;
    public float jump_intensity;
    public bool is_running;
    public bool hasExitTime;

    public static bool Float_to_bool(float num)
    {
        return Mathf.Approximately(Mathf.Min(num, 1), 1);
    }


    public Animator animator;
    private Rigidbody2D body;



    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");                     // 1 -1 0

        Input.GetKeyDown(KeyCode.Space);


        //changing parameters when running 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontal = 2 * horizontal;
            is_running = true;

        }
        is_running = false;


        //apply movement
        //playing animation

        move_player(horizontal,jump, is_running);
        player_animation(horizontal, jump);


        //how to know 

       // Debug.Log("");




    }




    public void  move_player(float horizonal,float jump,bool is_running)
    {
        Vector3 position = transform.position;
        position.x+=horizonal* ((is_running)?speed_run:speed_walk) *Time.deltaTime;     //1 * 2 * 1
        transform.position = position;


        if (jump > 0)
        {
            body.AddForce(new Vector2(0f, jump_intensity), ForceMode2D.Force);

        }
    }




    public void player_animation(float horizontal, float jump )
    {

        

        Debug.Log(horizontal);


        animator.SetFloat("speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;





        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        


        animator.SetBool((jump < 0) ? "is_crouching" : "jump", true);

        if (jump == 0)
        {
            animator.SetBool("jump", false);
            animator.SetBool("is_crouching", false);
        }




        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("has_gun", true);
        }
        if (!Input.GetKey(KeyCode.F))
        {
            animator.SetBool("has_gun", false);
        }






        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("attack", true);
        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("attack", false);
        }

    }
}

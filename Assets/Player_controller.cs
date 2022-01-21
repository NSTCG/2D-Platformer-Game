using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal"); 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2*speed;

        }

        Debug.Log(speed);


        animator.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;



        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);     
        }
        else if (speed > 0)
        {       
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        
        float jump= Input.GetAxisRaw("Jump");  // 1 then 0



        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump",true);         
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", false);
        }




        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("is_crouching", true);
        }
        if (!Input.GetKey(KeyCode.C))
        {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float gravity = 50;
    [SerializeField] float jumpForce = 30;
    Animator anim;
    Vector3 direction;
    bool isRun = false;
    [SerializeField] AudioSource steps;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded) 
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;

            if (Input.GetKey(KeyCode.Space)) 
            {
                direction.y = jumpForce;
                anim.SetTrigger("Jump");
            }
        }

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - 5;
        }

        if (controller.velocity.magnitude > 0.001f) {
            if (isRun == false) {
                anim.SetBool("Run", true);
                steps.Play();
                isRun = true;
            }
            
        }
        else {
            if (isRun == true) {
                anim.SetBool("Run", false);
                steps.Stop();
                isRun = false;
            }
            
        }
    }
}


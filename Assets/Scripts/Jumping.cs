using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpHeight;
    public bool isGrounded; //Can't figure out how to make this work 
    Animator anim;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpHeight);
            anim.SetTrigger("Jump");
        }

    }

    // None of this works
    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other){
        if (other.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
}

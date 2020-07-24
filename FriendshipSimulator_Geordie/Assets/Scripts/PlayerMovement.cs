using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float blendAnim = 0.1f;
    public float rotateSpeed = 3.0f;
    

    public Animator animator;
    public Animator NPCAnimator;
    public Animator NPCAnimator2;
    public CharacterController controller;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Waving();
        
    }

    void Movement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        

        

        Vector3 pMovement = new Vector3(0f, 0f, inputY).normalized * speed * Time.deltaTime;
        transform.Translate(pMovement, Space.Self);
        transform.Rotate(0, Input.GetAxisRaw("Horizontal"), 0);
        animator.SetFloat("Speed", inputY, blendAnim, Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackwards", true);
        }
        else
        {
            animator.SetBool("isBackwards", false);
        }
        
    }

    void Waving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Waving");
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

       
        if (other.gameObject.CompareTag("NPC"))
        {
            SetAnimation();  
        }
        if (other.gameObject.CompareTag("NPC2"))
        {
            SetAnimation2();
        }
    }
    void SetAnimation()
    {
        if (Input.GetMouseButton(0))
        {
            NPCAnimator.SetTrigger("isWaved");
        }
    }
    void SetAnimation2()
    {
        if (Input.GetMouseButton(0))
        {
            NPCAnimator2.SetTrigger("isWaved2");
        }
    }
}

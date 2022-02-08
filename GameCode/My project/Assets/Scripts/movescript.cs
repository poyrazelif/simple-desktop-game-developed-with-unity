using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript : MonoBehaviour
{
    
    public float speed = 2;
    float rotationspeed = 200;
    float rotation = 0;
    public timectrl timeCtrl;
    
    Vector3 movedir = Vector3.zero;
    CharacterController control;
    Animator animator;
    float gravity = 10;
    public Rigidbody rgdbody;
    public bool fallState = false;
    public bool winState = false;

    //Start is called before the first frame update
    void Start()
    {
        control =GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
        rgdbody = GetComponent<Rigidbody>();
        timeCtrl = GetComponent<timectrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCtrl.timecounter > 0)
        {   if (fallState == false)
            {
                if (control.isGrounded)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        movedir = speed * (new Vector3(0, 0, 1));
                        animator.SetInteger("move", 1);
                        movedir = transform.TransformDirection(movedir);
                    }

                    else if (Input.GetButtonDown("Jump"))
                    {
                        rgdbody.AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
                    }

                    else
                    {
                        movedir = Vector3.zero;
                        animator.SetInteger("move", 0);
                    }

                }

                rotation += Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime; // string büyük harfe duyarlý
                transform.eulerAngles = new Vector3(0, rotation, 0);  // x'i y de döndürecek
                movedir.y -= gravity * Time.deltaTime;
                control.Move(movedir * Time.deltaTime);
            }
            else 
            {
                movedir = Vector3.zero;
                animator.SetInteger("move", 0);

            }
            

        }

       
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    string objname = collision.gameObject.name;
    //    // if (objname.Equals("win")) { Debug.Log("oyun tamamlandi"); }
    //    Debug.Log(collision.gameObject.name);
    //}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Objects we touch, move them to position (0, 0, 0)
        string st = hit.gameObject.name;
        if(st.Equals("WinPlatform"))
        {
            Debug.Log("hit");
            winState = true;
        }
        
        if (st.Equals("Water"))
        {
            fallState = true;
            Debug.Log("düþtü");
        }
       
    }

    
}

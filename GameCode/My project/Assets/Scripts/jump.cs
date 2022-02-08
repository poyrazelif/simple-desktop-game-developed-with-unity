using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    string objname = collision.gameObject.name;
    //    // if (objname.Equals("win")) { Debug.Log("oyun tamamlandi"); }
    //    Debug.Log(collision.gameObject.name);
    //}
}

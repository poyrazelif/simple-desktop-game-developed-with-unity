using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isgrounded : MonoBehaviour
{
    CharacterController control;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (control.isGrounded == false)
        //{
        //    Debug.Log("Game Over");
        //}

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Objects we touch, move them to position (0, 0, 0)
        string st = hit.gameObject.name;
        if (!st.Equals("Plane") || !st.Equals("Walls") || !st.Equals("WinPlatform") || !st.Equals("WinPlatform2"))
        {
            Debug.Log("Game Over");
        }
    }
}

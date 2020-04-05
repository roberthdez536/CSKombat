using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float SPEED = 5.0f;
    [SerializeField]
    private float JUMP = 10.0f;
    [SerializeField]
    private float GRAVITY = 25.0f;

    CharacterController cc;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded)
        {
            movement = transform.right * Input.GetAxis("Horizontal");
            movement = transform.TransformDirection(movement);
            movement *= SPEED;

            if (Input.GetAxis("Jump") > 0)
            {
                movement += Vector3.up * JUMP;
            }

        }
        else
        {
            float buff = movement.y;
            movement = transform.right * Input.GetAxis("Horizontal");
            movement = transform.TransformDirection(movement);
            movement *= SPEED;    
            movement.y = buff;
        }
        movement += Vector3.down * GRAVITY * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        cc.Move(movement * Time.deltaTime);
    }
}

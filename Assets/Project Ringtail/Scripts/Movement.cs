using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Animator playerAnim;

    [SerializeField]
    Rigidbody playerRB;

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float speedRun = 10f;

    private bool walking;

    private Vector3 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector3>();
    }

    private void PlayerMovement()
    {
        if (moveInput.z > 0)
        {
            playerRB.velocity = playerTransform.forward * speedRun * Time.deltaTime;
            playerAnim.SetTrigger("Run");
            playerAnim.ResetTrigger("Idle");
        }
        
        if (moveInput.z < 0) 
        {
            playerRB.velocity = -playerTransform.forward * speedRun * Time.deltaTime;
            playerAnim.SetTrigger("Run");
            playerAnim.ResetTrigger("Idle");
        }

        if (moveInput.magnitude == 0)
        {
            playerAnim.SetTrigger("Idle");
            playerAnim.ResetTrigger("Run");
        }
    }

}

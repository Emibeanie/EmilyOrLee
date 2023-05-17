using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float speed = 10;

    private float horizontalInput;
    private float verticalInput;

    Vector3 velocity;

    private void Update()
    {
        PlayerInput();

        //if (horizontalInput != 0 || verticalInput != 0)
        //{
        //    anim.SetFloat("speed", speed);
        //}
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        velocity = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        transform.Translate(velocity * Time.deltaTime);

    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        print(horizontalInput);
        print(verticalInput);
    }

}

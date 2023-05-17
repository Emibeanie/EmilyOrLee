using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Animator animController;
    [SerializeField] float speed = 10;

    private float horizontalInput;
    private float verticalInput;

    Vector3 velocity;

    private void Update()
    {
        PlayerInput();
        PlayerMovement();
        DanceAnim();
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

    public void DanceAnim()
    {
        bool fIsPressed = Input.GetKey(KeyCode.F);
        if (fIsPressed)
        {
            animController.SetBool("IsDancing", true);
           print( animController.GetBool("IsDancing"));
           
        }
        if (!fIsPressed)
        {
            animController.SetBool("IsDancing", false);
            print(animController.GetBool("IsDancing"));
        }
    }

}

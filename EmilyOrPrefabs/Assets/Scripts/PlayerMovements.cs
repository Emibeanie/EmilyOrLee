using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Animator animController;
    [SerializeField] float speed;

    private float horizontalInput;
    private float verticalInput;

    Vector3 velocity;

    private void Update()
    {
        PlayerInput();
        PlayerMovement();
        DanceAnim();
        RunAnim();
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
    }

    public void DanceAnim()
    {
        bool fIsPressed = Input.GetKey(KeyCode.F);
        if (fIsPressed)
        {
            animController.SetBool("IsDancing", true);
           print("Is Dancing");
           
        }
        if (!fIsPressed)
        {
            animController.SetBool("IsDancing", false);
            print("Is Not Dancing");
        }
    }

    public void RunAnim()
    {
       

        if (horizontalInput !=0 || verticalInput != 0)
        {
            animController.SetFloat("speed", speed);
            print("Is Running");
        }

        else
        {
            animController.SetFloat("speed", 0);
            print("Is Not Running");
        }
    }

}

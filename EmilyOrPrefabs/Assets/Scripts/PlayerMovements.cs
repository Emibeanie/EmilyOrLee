using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Animator animController;
    [SerializeField] float speed;
    [SerializeField] GameObject particle;
    [SerializeField] float speedModifier = 1.1f;

    private float horizontalInput;
    private float verticalInput;
    float adjustedSpeed;

    Vector3 velocity;

    private void Update()
    {
        PlayerInput();
        PlayerMovement();
        DanceAnim();
        RunAnim();
        
    }

    private void FixedUpdate()
    {
        AdjustedSpeed();
    }

    private void AdjustedSpeed()
    {
        adjustedSpeed = speed * speedModifier;
    }
    private void PlayerMovement()
    {
        velocity = new Vector3(horizontalInput * adjustedSpeed, 0, verticalInput * adjustedSpeed);
        transform.Translate(velocity * Time.deltaTime);

        
    }

    public void SetParticle(bool isOn)
    {
        particle.SetActive(isOn);
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

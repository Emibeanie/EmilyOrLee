using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterController controller;
    [SerializeField] Animator anim;
    [SerializeField] float Speed;
    private float horizontalInput;
    private float verticalInput;
    Vector3 velocity;

    private void Update()
    {
        Move();
        if (horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetFloat("running", Speed);
        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        velocity = new Vector3(horizontalInput, 0, verticalInput);
        controller.Move(transform.position + velocity * Time.deltaTime);
    }

}

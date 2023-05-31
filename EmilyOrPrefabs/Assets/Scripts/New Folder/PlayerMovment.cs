using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float runningSpeed = 1.5f;

    private bool isWalking;
    private bool isRunning;
    private bool isCrouching;

    private void Update()
    {
        Vector3 inputVector = new Vector3(0, 0, 0);

        // Walk Speed + Controlls
        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            inputVector.z = +1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            inputVector.z = -1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        // Rotate the player towards the input direction
        if (inputVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(inputVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Move the player
        transform.position += inputVector * speed * Time.deltaTime;

        // isWalking for animation 

        if (UnityEngine.Input.GetKey(KeyCode.W) || UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.S) || UnityEngine.Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        //Running Speed + Controlls, isRunning for animation.
        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += inputVector * speed * runningSpeed * Time.deltaTime;
            isRunning = true;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.position += inputVector * speed * Time.deltaTime;
            isRunning = false;
        }
        Vector3 moveDir = transform.position;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);

        // Jumping
        /*
        if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            inputVector.y = jumpHeight * Time.deltaTime;
            if(transform.position != Vector3.zero)
            {
                
            }
        }
        */

        // isCrouching for animation.

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    public bool IsRunning()
    {
        return isRunning;
    }
    public bool IsCrouching()
    {
        return isCrouching;
    }
}

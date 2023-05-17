using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Animator anim;
    public float forwardSpeed;

    private void Update()
    {
        if (Input.) {
            anim.SetFloat("running", forwardSpeed);
        }
    }

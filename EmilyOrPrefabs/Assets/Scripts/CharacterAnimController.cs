using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    Animator animController;
    void Start()
    {
        animController = GetComponent<Animator>();
    }

    void Update()
    {
        bool fIsPressed = Input.GetKey("f");
        if (fIsPressed)
        {
            animController.SetBool("IsDancing", true);
        }
        if (!fIsPressed)
        {
            animController.SetBool("IsDancing", false);
        }
    }
}

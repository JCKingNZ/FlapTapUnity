using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Press the up space key to reset the trigger and set another one
        if (Input.GetKey(KeyCode.Space))
        {
            //Send the message to the Animator to activate the trigger parameter named "Flap"
            m_Animator.SetTrigger("Flap");
        }
    }
}

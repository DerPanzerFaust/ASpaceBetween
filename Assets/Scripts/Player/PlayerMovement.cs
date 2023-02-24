using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float mSpeed = 12f;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Locale position i.p.v. World position over as X en as Z
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * mSpeed * Time.deltaTime);
    }
}

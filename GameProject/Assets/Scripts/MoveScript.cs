using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    public CharacterController con;
    public float speed;

    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);

        con.SimpleMove(moveDirection * magnitude * speed);
    }
}

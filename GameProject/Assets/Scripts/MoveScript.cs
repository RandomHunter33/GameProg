using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MoveScript : MonoBehaviour
{
    public CharacterController con;
    public float speed; 
    private float ThisNumber;

    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        moveDirection = Quaternion.AngleAxis(45, Vector3.up) * moveDirection;
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        con.SimpleMove(moveDirection * magnitude * speed);
        ThisNumber = Mathf.Min(1.5f, transform.position.y);
        transform.position = new Vector3(transform.position.x, ThisNumber, transform.position.z);

    }
}

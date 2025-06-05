using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class CursurPointer : MonoBehaviour
{
    public GameObject Player;
    public Camera Camera;
    private Vector3 hitpoint;
    public GameObject Attack;

    private void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue()); //raycast line from cam to mouse
        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)) //check if it hit a collider
        {
            hitpoint = rayHit.point; //make a vector3 of the position where it hit
        }

        Vector3 relativePos = hitpoint - transform.position; //turn it relative to player position
        Quaternion toRotate = Quaternion.LookRotation(relativePos, Vector3.up); //coordinate in quaternion
        Player.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 100000 * Time.deltaTime); //function to rotate player
        Player.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w); //function to lock variable x and z

        
    }

    public void basicAttack (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 relativePos = hitpoint - transform.position; //turn it relative to player position
            Quaternion toRotate = Quaternion.LookRotation(relativePos, Vector3.up); //coordinate in quaternion

             //= Vector3.MoveTowards(Player.transform.position, hitpoint, 5 * Time.deltaTime);

            GameObject temp = Instantiate(Attack, Player.transform.position, new Quaternion(0, 0, 0, 0));
            temp.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 100000 * Time.deltaTime); //function to rotate player
            temp.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w); //function to lock variable x and z
            
        }
        
    }
}

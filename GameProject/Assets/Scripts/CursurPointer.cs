using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CursurPointer : MonoBehaviour
{
    public GameObject Player;
    public Camera Camera;
    private Vector3 hitpoint;
    private Vector3 relativePos;
    private Quaternion toRotate;
    public MoveScript MS;

    private float timer = 1;
    private float bulletTime;
    public GameObject Bullet;

    private float timer1 = 5;
    private float Time1;
    public GameObject Bomb;


    private void Update()
    {
        if (MS.InputOn)
        {
            Ray ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue()); // raycast line from cam to mouse
            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)) // check if it hit a collider
            {
                hitpoint = rayHit.point; // make a vector3 of the position where it hit
            }

            relativePos = hitpoint - transform.position; // turn it relative to player position
            toRotate = Quaternion.LookRotation(relativePos, Vector3.up); // coordinate in quaternion
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 16.0f); // function to rotate player
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w); // function to lock variable x and z
        }

        bulletTime -= Time.deltaTime; // update time
        Time1 -= Time.deltaTime;
    }

    public void basicAttack (InputAction.CallbackContext context)
    {
        if (context.performed && MS.InputOn)
        {

            if (bulletTime > 0) return;
            bulletTime = timer;

            GameObject temp = Instantiate(Bullet, Player.transform.position, Quaternion.Euler(90f, 0f, 0f));
            temp.transform.rotation = Quaternion.RotateTowards(temp.transform.rotation, toRotate, 100000 * Time.deltaTime); //function to rotate
            temp.transform.rotation = new Quaternion(0, temp.transform.rotation.y, 0, temp.transform.rotation.w); //function to lock variable x and z
            temp.transform.Translate(0, -0.5f, 1.0f);
            Rigidbody bulletRig = temp.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * 1000);
            Destroy(temp, 2f);
        }
        
    }

    public void skill1(InputAction.CallbackContext context)
    {
        if (context.performed && MS.InputOn)
        {
            if(Time1 > 0) return;
            Time1 = timer1;

            GameObject temp = Instantiate(Bomb, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
            temp.transform.rotation = Quaternion.RotateTowards(temp.transform.rotation, toRotate, 100000 * Time.deltaTime); //function to rotate
            temp.transform.rotation = new Quaternion(0, temp.transform.rotation.y, 0, temp.transform.rotation.w); //function to lock variable x and z
            temp.transform.Translate(0, -0.5f, 1.0f);
            temp.GetComponent<Bomb>().HitPoint = hitpoint;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    public int health;
    public Transform pos;
    public Transform enemy;
    public Transform targetObj;
    private float ThisNumber;

    private void Start()
    {
        pos.position = enemy.transform.position;
    }
    private void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
        pos.position = Vector3.MoveTowards(enemy.transform.position, targetObj.position, 5 * Time.deltaTime);

        ThisNumber = Mathf.Min(1f, pos.position.y);
        enemy.transform.position = new Vector3(pos.position.x, ThisNumber, pos.position.z);


        Vector3 relativePos = targetObj.position - transform.position;
        Quaternion toRotate = Quaternion.LookRotation(relativePos, Vector3.up);

        enemy.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 100000 * Time.deltaTime);
        enemy.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    public int health;
    public GameObject pos;
    public GameObject enemy;
    public GameObject targetObj;
    private float ThisNumber;
    public CameraScript CS;

    private float timer = 1;
    private float bulletTime;

    private void Start()
    {
        pos.transform.position = enemy.transform.position;
    }
    private void Update()
    {
        if (health < 0)
        {
            CS.CurrC1--;
            Destroy(this.gameObject);
        }
        pos.transform.position = Vector3.MoveTowards(enemy.transform.position, targetObj.transform.position, 5 * Time.deltaTime);

        ThisNumber = Mathf.Min(1f, pos.transform.position.y);
        enemy.transform.position = new Vector3(pos.transform.position.x, ThisNumber, pos.transform.position.z);


        Vector3 relativePos = targetObj.transform.position - transform.position;
        Quaternion toRotate = Quaternion.LookRotation(relativePos, Vector3.up);

        enemy.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 100000 * Time.deltaTime);
        enemy.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

        attack(relativePos);
    }

    private void attack(Vector3 relativePos)
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;
        
        if (relativePos.x < 1  && relativePos.x > -1 || relativePos.z < 1 && relativePos.z > -1)
        {
            targetObj.GetComponent<MoveScript>().HP--; 
        }
    }
    
}

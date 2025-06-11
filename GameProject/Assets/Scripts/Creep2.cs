using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Creep2 : MonoBehaviour
{
    public int health;
    public GameObject pos;
    public GameObject enemy;
    public GameObject targetObj;
    private float ThisNumber;
    public CameraScript CS;

    private float timer = 3;
    private float bulletTime;
    public GameObject Bullet;

    private void Start()
    {
        pos.transform.position = enemy.transform.position;
    }
    private void Update()
    {
        if (health < 0)
        {
            CS.CurrC2--;
            Destroy(this.gameObject);
        }
        pos.transform.position = Vector3.MoveTowards(enemy.transform.position, targetObj.transform.position, 5 * Time.deltaTime);

        ThisNumber = Mathf.Min(1f, pos.transform.position.y);
        enemy.transform.position = new Vector3(pos.transform.position.x, ThisNumber, pos.transform.position.z);


        Vector3 relativePos = targetObj.transform.position - transform.position;
        Quaternion toRotate = Quaternion.LookRotation(relativePos, Vector3.up);

        enemy.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 100000 * Time.deltaTime);
        enemy.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

        Invoke("ShootAtPlayer", 1f);
    }
    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(90f, 0f, 0f));
        Vector3 relativePos = targetObj.transform.position - transform.position; // turn it relative to player position
        Quaternion toRotate = Quaternion.LookRotation(relativePos, Vector3.up); // coordinate in quaternion
        temp.transform.rotation = Quaternion.RotateTowards(temp.transform.rotation, toRotate, 100000 * Time.deltaTime); //function to rotate
        temp.transform.rotation = new Quaternion(0, temp.transform.rotation.y, 0, temp.transform.rotation.w); //function to lock variable x and z
        temp.transform.Translate(0, -0.5f, 1.0f);
        Rigidbody bulletRig = temp.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * 1000);
        Destroy(temp, 2f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float shotFroce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotFroce);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 1);
            }
        }
    }
}



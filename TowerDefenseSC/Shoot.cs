using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawnpose;
    float turnspeed=1f;
    GameObject goob;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag== "TargetObject" && goob == null)
        {
            goob = obj.gameObject;
            InvokeRepeating("shootBullet", 0, 2f);
        }
    }
    void Start()
    {
      //  InvokeRepeating("shootBullet", 1f, 1f);

    }
    void shootBullet()
    {
        Instantiate(bullet, spawnpose.transform.position, spawnpose.transform.rotation);
        this.GetComponent<AudioSource>().Play();
        if (goob.GetComponent<Move>().dead)
        {
            goob = null;
            CancelInvoke("shootBullet");
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject == goob)
        {
            goob = null;
            CancelInvoke("ShootBullet");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (goob != null)
        {
            if (goob)
            {
                Vector3 direction = goob.transform.position - this.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), turnspeed * Time.smoothDeltaTime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 0.5f;
    float turnspeed = 1.0f;
    private GameObject Home;
    public bool dead = false;
    Animator anim;
    bool lookingforhome = true;
    float HP = 2;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        InvokeRepeating("findHome", 0, 1.5f);
    }

    void findHome()
    {
        Home = GameObject.FindGameObjectWithTag("Home");
        if (Home != null)
        {
            CancelInvoke();
            lookingforhome = true;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag =="Bullet")
        {
            Hit();
        }
       else if (col.gameObject.tag == "Home")
        {
            Destroy(this.gameObject, 1);
            this.GetComponent<AudioSource>().Play();
        }
    }
    void Hit()
    {
        dead = true;
        anim.SetTrigger("IsDying");
        Destroy(this.GetComponent<Collider>(), 1f);
        Destroy(this.GetComponent<Rigidbody>(), 1f);
        Destroy(this.gameObject, 4f);
    }
    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            return;
        }
        if (Home != null)
        {
            Vector3 direction = Home.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), turnspeed * Time.smoothDeltaTime);
        }
        else if (lookingforhome)
        {
            InvokeRepeating("findHome", 0, 1);
            lookingforhome = false;
        }
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        
    }

}

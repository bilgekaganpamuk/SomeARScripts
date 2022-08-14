using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PositionController : MonoBehaviour
{
    //Up 0 down 1 left 2 right 3
    
    public GameObject Plane;
    private float speed = 0.015f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void up()
    {
        Plane.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y + speed, Plane.transform.position.z);
    }
    public void down()
    {
        Plane.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y - speed, Plane.transform.position.z);
    }
   public void come()
    {
        Plane.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y, Plane.transform.position.z-speed);
    }
    public void go()
    {
        Plane.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y, Plane.transform.position.z + speed);
    }
}


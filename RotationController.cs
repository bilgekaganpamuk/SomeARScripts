using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotationController : MonoBehaviour
{
    private float speed = 45;
    public Slider slidex;
    public Slider slidery;
    public GameObject Plane;
    private float previusValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slidex.onValueChanged.AddListener(rotateX);
        slidery.onValueChanged.AddListener(rotateY);
    }
    void rotateX(float value) 
    {
        float delta = value - previusValue;
        Plane.transform.Rotate(Vector3.right * delta*-360);
        this.previusValue = value;
    }
    void rotateY(float value)
    {
        float delta = value - previusValue;
        
        Plane.transform.Rotate(Vector3.up * delta * -360);
        this.previusValue = value;
    }

}

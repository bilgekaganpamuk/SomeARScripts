using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Joystick joystick;

    public float speed=1f;

    private Rigidbody RB;

    public float maxvelocityChange = 3f;

    public float tiltamount = 10f;

    private Vector3 VelocityVector = Vector3.zero; // inital velocity
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        //For inputs in x and y
        float _xMovementInput = joystick.Horizontal;
        float _yMovementInput = joystick.Vertical;

        Vector3 _movementHorizontal = transform.right * _xMovementInput;
        Vector3 _movemnetVertical = transform.forward * _yMovementInput;

        Vector3 _movementVelocityVector = (_movementHorizontal + _movemnetVertical).normalized *10;
        Move(_movementVelocityVector);


        transform.rotation = Quaternion.Euler(joystick.Vertical * speed * tiltamount, 0, -1 * joystick.Horizontal * speed * tiltamount);
    }
    void Move(Vector3 MovementVelocityVector)
    {
        VelocityVector = MovementVelocityVector;
    }
    private void FixedUpdate()
    {
     if(VelocityVector != Vector3.zero)
        {
            Vector3 velocity = RB.velocity;
            Vector3 VelocityChange = (VelocityVector - velocity);

            VelocityChange.x = Mathf.Clamp(VelocityChange.x,-maxvelocityChange,maxvelocityChange);
            VelocityChange.z = Mathf.Clamp(VelocityChange.z, -maxvelocityChange, maxvelocityChange);
            VelocityChange.y = 0;
            RB.AddForce(VelocityChange, ForceMode.Acceleration);
        }

    }
}

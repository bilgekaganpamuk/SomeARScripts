using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityVolumeRendering;

public class RotationWithtouch : MonoBehaviour
{
    public GameObject Dicom;
    private bool CanRotate = false;
    private float startingPositionX;
    private float startingPositiony = 0f;
    private float rotatespeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dicom = GameObject.FindGameObjectWithTag("rendered");
        if(Dicom != null)
        {
            CanRotate = true;
        }
        
        if (Input.touchCount ==1 && CanRotate)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPositionX = touch.position.x;
                    startingPositiony = touch.position.y;
                    break;
                case TouchPhase.Moved:
                    if (startingPositionX > touch.position.x )
                    {
                        Dicom.transform.Rotate(Vector3.forward, rotatespeed);
                    }
                    else if (startingPositionX < touch.position.x)
                    {
                        Dicom.transform.Rotate(Vector3.forward, -rotatespeed );
                    }
                   /* if (startingPositiony > touch.position.y)
                    {
                        Dicom.transform.Rotate(Vector3.right, rotatespeed * Time.deltaTime);
                    }
                    else if (startingPositiony < touch.position.y)
                    {
                        Dicom.transform.Rotate(Vector3.right, -rotatespeed * Time.deltaTime);
                    }*/
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
                case TouchPhase.Stationary:
                    startingPositionX = touch.position.x;
                    startingPositiony = touch.position.y;
                    break;
            }

        }
    }
}

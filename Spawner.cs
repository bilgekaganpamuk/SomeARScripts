using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ReticleBehaviour Reticle;
    public SurfaceManager SurfaceManager;
    public GameObject Controllers;
    public GameObject dicom;

    private void Start()
    {
        
    }
    private void Update()
    {
        
        if ( WasTapped() && Reticle.CurrentPlane != null)
        {
            // Spawn our car at the reticle location.
           
            dicom.SetActive(true);
            dicom.transform.position = Reticle.transform.position;
            SurfaceManager.LockPlane(Reticle.CurrentPlane);
            Reticle.gameObject.SetActive(false);
            Controllers.SetActive(true);
        }
    }

    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}

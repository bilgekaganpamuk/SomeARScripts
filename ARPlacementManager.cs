using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{

    ARRaycastManager m_ARRaycastManager;
    static List<ARRaycastHit> raycast_Hits= new List<ARRaycastHit>();
    public Camera ArCamera;
    public GameObject BattleArenaGameObject;
    private void Awake()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CentreOfScreen = new Vector3(Screen.width/2,Screen.height/2);

        Ray ray = ArCamera.ScreenPointToRay(CentreOfScreen);

        if (m_ARRaycastManager.Raycast(ray,raycast_Hits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitpose = raycast_Hits[0].pose;
            Vector3 positionToBePlaced = hitpose.position;

            BattleArenaGameObject.transform.position = positionToBePlaced;
        }
    }
}

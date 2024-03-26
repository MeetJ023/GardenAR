using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TreePlacement : MonoBehaviour
{
    [SerializeField] GameObject[] trees;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    private List<ARRaycastHit> raycastHit=new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool collision=raycastManager.Raycast(Input.mousePosition,raycastHit,TrackableType.PlaneWithinPolygon);
            if (collision)
            {
                GameObject _object = Instantiate(trees[Random.Range(0, trees.Length-1)]);
                _object.transform.position = raycastHit[0].pose.position;
            }
            foreach(var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled= false;
        }
    }
}

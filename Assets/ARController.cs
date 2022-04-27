using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{

    public ARRaycastManager RaycastManager;

    public GameObject PerformHitTest() {
        List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
        RaycastManager.Raycast(
            new Vector2(Screen.width / 2, Screen.height / 2), hitResults, TrackableType.PlaneWithinPolygon);

        if (hitResults.Count > 0) {
            var hitPose = hitResults[0].pose;
            var obj = new GameObject();
            obj.transform.position = hitPose.position;
            obj.transform.rotation = hitPose.rotation;
            return obj;
        }
        return null;
    }
}

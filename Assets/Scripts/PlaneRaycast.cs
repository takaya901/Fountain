using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using NativeUtil;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaneRaycast : MonoBehaviour
{
    ARRaycastManager _raycastManager;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    void Awake()
    {
        Input.backButtonLeavesApp = true;
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount <= 0) return;
        
        var touchPosition = Input.GetTouch(0).position;
        if (!_raycastManager.Raycast(touchPosition, _hits, TrackableType.Planes)) return;
        
        // Raycastの衝突情報は距離によってソートされるため、0番目が最も近い場所でヒットした情報となります
        var hitPose = _hits[0].pose;
        
        AndroidUtil.Vibrate((long)5f);
    }
}
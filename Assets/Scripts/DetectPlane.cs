using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DetectPlane : MonoBehaviour
{
    PlaneRaycast _planeRaycast;
    ARPlaneManager _arPlaneManager;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    
    void Start()
    {
        _planeRaycast = GetComponent<PlaneRaycast>();
        _arPlaneManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        if (_planeRaycast.Raycast(out _hits)) {
            OnPlaneTouched();
        }
    }

    void OnPlaneTouched()
    {
        PlaneManager.arPlane = _arPlaneManager.GetPlane(_hits[0].trackableId);
        // Debug.Log(PlaneManager.arPlane.size);
        
        // イベントに登録
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene("Main");
    }
    
    void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        //平面検出を停止
        GetComponent<ARPlaneManager>().detectionMode = PlaneDetectionMode.None;

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
        enabled = false;
    }
}

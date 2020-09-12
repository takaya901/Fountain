using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // Debug.Log(_arPlaneManager.trackables);
        if (_planeRaycast.Raycast(out _hits)) {
            OnPlaneTouched();
        }
    }

    void OnPlaneTouched()
    {
        //タッチされた平面を保存
        PlaneManager.arPlane = _arPlaneManager.GetPlane(_hits[0].trackableId);
        //それ以外の平面を破棄
        foreach (var plane in _arPlaneManager.trackables) {
            if (plane != PlaneManager.arPlane) {
                Destroy(plane.gameObject);
            }
        }
        // Debug.Log(PlaneManager.arPlane.size);
        
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene("Main");
    }
    
    void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        //平面検出を停止
        GetComponent<ARPlaneManager>().detectionMode = PlaneDetectionMode.None;
        //このコンポーネントを無効に
        enabled = false;

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}

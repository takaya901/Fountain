using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapManager : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] float _ballSize = 0.1f;
    
    ARSessionOrigin _sessionOrigin;
    PlaneRaycast _planeRaycast;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    Rigidbody _ballRigidbody;
    
    void Start()
    {
        _sessionOrigin = GameObject.FindGameObjectWithTag("SessionOrigin").GetComponent<ARSessionOrigin>();
        _planeRaycast = _sessionOrigin.GetComponent<PlaneRaycast>();
        _ballRigidbody = _ball.GetComponent<Rigidbody>();
        _ballRigidbody.isKinematic = true;
    }

    void Update()
    {
        if (!_planeRaycast.Raycast(out _hits)) {
            _ball.SetActive(false);
            return;
        }
        
        _ball.SetActive(true);
        // _ball.transform.position = _hits[0].pose.position;
        _ballRigidbody.MovePosition(_hits[0].pose.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    public static ARPlane arPlane { get; set; }
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Debug.Log(arPlane?.center);
    }
}

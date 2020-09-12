using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(PlaneManager.arPlane?.extents);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _interval = 0.5f;

    ARPlane _arPlane;
    
    void Start()
    {
        _arPlane = PlaneManager.arPlane;
        InvokeRepeating(nameof(Generate), 0f, _interval);
    }

    void Update()
    {
        // Debug.Log(_arPlane?.extents);
    }

    void Generate()
    {
        var pos = Vector3.zero;
        //平面上に落とす
        do {
            pos = _arPlane.center + new Vector3(
                Random.Range(-_arPlane.extents.x, _arPlane.extents.x),
                0.5f, // _arPlane.center.y, 
                Random.Range(-_arPlane.extents.y, _arPlane.extents.y));
        } while (!Physics.Raycast(pos, Vector3.down, out var hitInfo));
        
        var rot = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up);

        Instantiate(_enemyPrefab, pos, rot);
    }
}

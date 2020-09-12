using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeUtil;

public class Enemy : MonoBehaviour
{
    AudioSource _voice;
    
    void Start()
    {
        _voice = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < -3f) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        _voice.Play();
        AndroidUtil.Vibrate((long)8f);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<MainCharacter>().transform;
    }

    private void Update()
    {
        Vector3 position = target.position; position.z = -10.0F; position.y = 0 ;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform CameraPosition;

    private void Update()
    {
        transform.position = CameraPosition.position;
    }
}

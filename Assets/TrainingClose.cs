using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingClose : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Saw.Instance.isTouched)
        {
            Destroy(gameObject);
        }
    }
}

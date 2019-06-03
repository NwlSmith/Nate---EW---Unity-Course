using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraRotationADDON : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.eulerAngles = Vector3.zero;
    }
}

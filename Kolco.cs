using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolco : MonoBehaviour
{

    //public float x, y, z;
    public GameObject deM;

    void FixedUpdate()
    {
        transform.RotateAround(deM.transform.position, new Vector3(0.0f, 0.0f, 0.1f), 100 * Time.deltaTime);
        transform.Rotate(new Vector3(0f, 0f, -2f));
    }
}

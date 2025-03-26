using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCube : MonoBehaviour
{

    public Vector3 RotateAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print("passe ici");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateAmount);
    }

}

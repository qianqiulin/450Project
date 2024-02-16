using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkunder2D : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    void Update()
    {
        if (objectA.position.z < objectB.position.z)
        {
            Debug.Log("Object A is under Object B");
        }
        else
        {
            Debug.Log("Object A is not under Object B");
        }
    }
}

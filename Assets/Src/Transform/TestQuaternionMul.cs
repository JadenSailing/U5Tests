using UnityEngine;
using System.Collections;

// Moves the object along relativeDirection
// Usually you would use transform.Translate for this
public class TestQuaternionMul : MonoBehaviour
{
    public Vector3 relativeDirection = Vector3.forward;
    void Update()
    {
        Vector3 absoluteDirection = transform.rotation * relativeDirection;
        transform.position += absoluteDirection * Time.deltaTime;
    }
}
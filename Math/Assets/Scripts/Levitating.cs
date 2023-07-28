using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitating : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up);
        float y = Mathf.PingPong(Time.time / 2, 1) + 1.2f;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}

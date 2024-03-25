using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinWheelController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float Veer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(0, 0, Veer * rotationSpeed * Time.deltaTime);
        transform.rotation =transform.rotation * deltaRotation;
    }
}

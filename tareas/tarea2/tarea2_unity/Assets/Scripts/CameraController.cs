using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(xAxisValue, 0, zAxisValue);

        transform.position += moveVec * rotationSpeed * 5 * Time.deltaTime;        
    }
}

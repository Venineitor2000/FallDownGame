using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCelu : MonoBehaviour
{
    float speed = 50;
    public TouchAxis touchAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * touchAxis.GetTouchAxis() * Time.deltaTime * speed);
    }
}

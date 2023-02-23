using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAxis : MonoBehaviour
{
    public float sensibilidad;
    float duracion = 0;
    float touchAxis = 0;
    int lastTouchDirection; //-1 izquierda, 1 derecha
    public float GetTouchAxis()
    {
        float touch = 0;
        if (Input.GetMouseButton(0))
        {
            touchAxis = sensibilidad * duracion;
            touchAxis *= touchAxis;//Para hacer el crecimiento cuadratico
            if (touchAxis < 1)
                duracion += Time.deltaTime;
            else
                touchAxis = 1;

            if (Input.mousePosition.x <= Screen.width / 2)
            {
                //Izquierda
                if (lastTouchDirection == 1)
                    ResetTouch();
                lastTouchDirection = -1;
                touch = -touchAxis;
            }

            else
            {
                //Derecha
                if (lastTouchDirection == -1)
                    ResetTouch();
                lastTouchDirection = 1;
                touch = touchAxis;
            }
        }       
        return touch;

    }

    public void ResetTouch()
    {
        touchAxis = 0;
        duracion = 0;
    }
}

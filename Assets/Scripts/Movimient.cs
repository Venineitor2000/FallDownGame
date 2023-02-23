using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimient : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb = null;
    float speedX = 15; //Esta velociad ya no se usa para el movimiento, solo para animaciones, dejarla como esta
    [SerializeField] AnimationCurve speedY;
    [SerializeField] Animator animator = null;
    [SerializeField] float maxDistCostados = 0;
    [SerializeField] TouchAxis touchAxis;
    [SerializeField] bool DebugCelu = true; //Quiero simular q estoy en un celular
    float time;
    bool detener;
    // Update is called once per frame
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        
        if(!detener)
        {
            if (Input.anyKey) 
            {
                animator.SetBool("Moviendose", true);
                float velocityX = GetInput() * speedX;
                int direction = 0;

                if (GetInput() < 0)
                {
                    direction = -1;
                    animator.SetFloat("Speed", direction);
                }
                else if (GetInput() > 0)
                {
                    direction = 1;
                    animator.SetFloat("Speed", direction);
                }

                if (ComprobarDistanciaBordes(speedX * direction))
                    EstablecerVelocidad(velocityX, speedY.Evaluate(time));
                else
                    EstablecerVelocidad(0, speedY.Evaluate(time));
            }
             
            else
            {
                animator.SetBool("Moviendose", false);
                EstablecerVelocidad(0, speedY.Evaluate(time));
                touchAxis.ResetTouch();
            }
        }       
    }

    void EstablecerVelocidad(float velocidadX, float velocidadY)
    {
        rb.velocity = new Vector2(velocidadX, velocidadY);
    }

    bool ComprobarDistanciaBordes(float speed)
    {
        bool movimientoPermitido = true;
        if (Mathf.Abs(transform.position.x + speed * Time.fixedDeltaTime) >= maxDistCostados)
            movimientoPermitido = false;
        return movimientoPermitido;
    }

    void Detener()
    {
        EstablecerVelocidad(0, 0);
        detener = true;
    }

    void Reanudar()
    {
        detener = false;
    }

    float GetInput()
    {
        float input;
        if (SystemInfo.deviceType != DeviceType.Desktop || DebugCelu)//Se activa si quiero simular q estoy en un celu o si lo estoy posta
            input = touchAxis.GetTouchAxis();
        else
            input = Input.GetAxis("Horizontal");
        return input;
    }
}

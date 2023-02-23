using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    
    [SerializeField] float maxDist = 5;
    // Update is called once per frame
    void Update()
    {
        


        if(!Jugador.GetMuerto())
        {
            float posMouseX;

            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                 posMouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            else
                posMouseX = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x;

            if (Mathf.Abs(posMouseX) >= maxDist)
            {
                if (posMouseX >= 0)
                    posMouseX = maxDist;
                else
                    posMouseX = -maxDist;
            }              
            transform.position = new Vector3(posMouseX, transform.position.y, transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento : MonoBehaviour
{
    [SerializeField] Transform jugador = null;
    [SerializeField] float margenY = -5.85f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, jugador.position.y + margenY, transform.position.z);
    }
}

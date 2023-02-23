using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlayerSckin : MonoBehaviour
{
    [SerializeField] List<Sprite> sckins = new List<Sprite>();
    [SerializeField] int sckinActual = 0;
    public static ControladorPlayerSckin self;

    private void Awake()
    {
        if (self == null)
            self = this;
    }

    public void SetSckinActual(int sckin)
    {
        sckinActual = sckin;
    }

    public int GetSckinActual()
    {
        return sckinActual;
    }

    public Sprite ObtenerSckin()
    {
        if (sckins.Count - 1 < sckinActual)
        {
            Debug.Log("ERROR AL OBTENER SCKIN, ESA SCKIN NO EXISTE");
            return sckins[0];
        }
        return sckins[sckinActual];
    }   
}

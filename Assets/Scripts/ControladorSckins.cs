using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSckins : MonoBehaviour
{
    [SerializeField] List<PaqueteSckins> paquetes = new List<PaqueteSckins>();
    [SerializeField] int paqueteActual = 0;
    public static ControladorSckins self;

    private void Awake()
    {
        if(self == null)
            self = this;
    }

    public int GetPaqueteActual()
    {
        return paqueteActual;
    }

    public void SetPaqueteActual(int paquete)
    {
        paqueteActual = paquete;
    }

    public Color32 ObtenerSckin(Sckin sckinDeseada)
    {
        if(paquetes.Count - 1 < paqueteActual)
        {
            Debug.Log("ERROR AL OBTENER PAQUETE, ESE PAQUETE NO EXISTE");
            return Color.red;
        }
        return paquetes[paqueteActual].DevolverSckin(sckinDeseada);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sckin
{
    Jugador,
    Fondo,
    Bloques1,
    Bloques2,
}

public class PaqueteSckins:MonoBehaviour
{
    //Poner los colores en el orden correcto
    [SerializeField] List<Color32> colores = new List<Color32>();
    int cantidadSckins = 4;

    public Color32 DevolverSckin(Sckin sckinDeseada)
    {
        
        if (colores.Count < cantidadSckins)
        {
            Debug.Log("PAQUETE INCOMPLETO DETECTADO, TIENE MENOS DE: "+ cantidadSckins + " SCKINS");
            return Color.red;
        }
            
        return colores[(int)sckinDeseada];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [SerializeField] TMP_Text contador = null;
    int puntuacion = 0;
    static Contador self;
    // Start is called before the first frame update
    void Start()
    {
        self = this;
        byte opacity = ((Color32)contador.color).a;
        Color32 sckin = ControladorSckins.self.ObtenerSckin(Sckin.Fondo);
        sckin.a = opacity;
        contador.color = sckin;
    }

    public void ActualizarValor()
    {
        puntuacion++;
        contador.text = puntuacion.ToString();
    }

    public static int GetPuntuacion()
    {
        return self.puntuacion;
    }

    public static void GameOver()
    {        
        GameManager.SetNewHighScore(self.puntuacion);
        Debug.Log(GameManager.GetHighScore());
    }
    
}

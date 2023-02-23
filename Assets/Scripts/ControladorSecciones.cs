using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSecciones : MonoBehaviour
{
    float time = 0;
    [SerializeField] AnimationCurve dificultadMargenY; //En el inspector elegis como queres q inicie, despues se cambia solo, tambie ahi elegis cuanto queres q demoren los cambios
    [SerializeField] List<Seccion> seccionesReference = new List<Seccion>();
    public static ControladorSecciones self;
    int seccionesSuperadas = 0;
    [SerializeField] float minMargenY, maxMargenY;
    float margenY = 5;//Si le das valor 0 se bugea, dejalo asi
    [SerializeField] float margenReinicio = 5;
    Seccion ultimaSeccionSuperada = null;
    [SerializeField] Contador contador = null;
    [SerializeField] AudioSource audioSuperarSeccion;
    // Start is called before the first frame update
    void Start()
    {
        self = this;
        ActualizarMargen();
        IniciarSecciones();       
    }

    private void Update()
    {
        ActualizarMargen();

        if(Input.GetKeyDown(KeyCode.A))
        {
            ReiniciarSecciones();
        }
    }

    public static void PlayAudio()
    {
        self.audioSuperarSeccion.Play();
    }

    void IniciarSecciones()
    {
        for (int i = 0; i < seccionesReference.Count; i++)
        {
            seccionesReference[i].ActualizarBloques();
            if(i != 0)
                seccionesReference[i].ActualizarPosicion(seccionesReference[i - 1].transform.position.y - margenY);
        }
    }

    public void ReiniciarSecciones()
    {
        int i;
        if (seccionesSuperadas < 4)
            i = seccionesSuperadas;
        else
            i = 3;
        for (; i < seccionesReference.Count; i++)//Arranca en el 3 max para que siempre queden secciones atras deljugador cuando el las supera
        {
            seccionesReference[i].ActualizarBloques();
            seccionesReference[i].ActualizarPosicion(seccionesReference[i].transform.position.y - margenReinicio - margenY);
        }
    }

    void ActualizarPuntuacion()
    {
        contador.ActualizarValor();       
    }

    public void SeccionSuperada(Seccion seccion)
    {
        if(ultimaSeccionSuperada != seccion) //Evita que por algun fallo se actualize mas de una vez por la misma seccion
        {
            ActualizarPuntuacion();
            ultimaSeccionSuperada = seccion;
            int seccionesParaActualizar = 4; //Cuantas seccion hay q superar para empezar a actualizar
            seccionesSuperadas++;

            if (seccionesSuperadas >= seccionesParaActualizar)
            {
                seccionesReference[0].ActualizarBloques();
                seccionesReference[0].ActualizarPosicion(seccionesReference[seccionesReference.Count - 1].transform.position.y - margenY);
                Seccion seccionAux = seccionesReference[0];
                seccionesReference.Remove(seccionesReference[0]);
                seccionesReference.Add(seccionAux);
            }
        }
    }    

    void AjustarDificultad()
    {
        if (time > dificultadMargenY[1].time)
        {
            float nuevoValor = Random.Range(minMargenY, maxMargenY);
            time = 0;
            Debug.Log(dificultadMargenY.length);
            Keyframe aux1 = new Keyframe(dificultadMargenY[0].time, dificultadMargenY[1].value);
            Keyframe aux2 = new Keyframe(dificultadMargenY[1].time, nuevoValor);
            dificultadMargenY.MoveKey(0, aux1);
            dificultadMargenY.MoveKey(1, aux2);
        }
    }

    void ActualizarMargen()
    {
        AjustarDificultad();
        margenY = dificultadMargenY.Evaluate(time);
        time += Time.deltaTime; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seccion : MonoBehaviour
{
    [SerializeField] ParticulasSeccion particulas;
    [SerializeField] List<SpriteRenderer> bloques = new List<SpriteRenderer>(); //0 izquierda, 1 medio, 2 derecha
    static int BloquesDerechaSeguidos = 0, BloquesIzquierdaSeguidos = 0, BloquesDobleCostadoSeguidos = 0, BloquesMedioSeguidos = 0, BloquesMedioIzqSeguidos = 0, BloquesMedioDerSeguidos = 0;
    static int UltimoCostadoColocado = 2; //0 = izquierda, 1 = derecha, 2 = ninguno
    static Sckin sckinSeccion = Sckin.Jugador;//Es para q no este inicializada correctamente, asi en ActualizarSckin la inicializa como se debe
    int maxBloquesDerechaSeguidos = 1, maxBloquesIzquierdaSeguidos = 1, maxBloquesDobleCostadoSeguidos = 1, maxBloquesMedioSeguidos = 1, maxBloquesMedioIzqSeguidos = 1, maxBloquesMedioDerSeguidos = 1;
    Camara camara = null;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.transform.position.y < transform.position.y)
        {
            ControladorSecciones.self.SeccionSuperada(this);
            particulas.transform.position = new Vector3(collision.transform.position.x, transform.position.y, transform.position.z);
            particulas.gameObject.SetActive(false);
            particulas.gameObject.SetActive(true);
            if (camara == null)
                camara = Camera.main.transform.GetComponent<Camara>();
            ControladorSecciones.PlayAudio();
        }
    }

    public void ActualizarPosicion(float posicionY)
    {
        transform.position = new Vector3(transform.position.x, posicionY);
    }

    void DesactivarBloques()
    {
        foreach (var bloque in bloques)
        {
            bloque.gameObject.SetActive(false);
        }
    }

    public void ActualizarBloques()
    {
        ActualizarSckin();
        DesactivarBloques();


        bool bloqueColocado = false;
        while (!bloqueColocado)
        {
            int colocarBloqueCostado = Random.Range(0, 6); //0 = doble costado, 1 = izquierda, 2 = derecha, 3 = medio, 4 medioIzq, 5 = medioDer

            if (colocarBloqueCostado == 0 && BloquesDobleCostadoSeguidos < maxBloquesDobleCostadoSeguidos)
            {
                bloqueColocado = true;
                ColocarBloque(0, sckinSeccion);
                ColocarBloque(2, sckinSeccion);
                BloquesDobleCostadoSeguidos++;

                if (UltimoCostadoColocado == 0)
                    BloquesDerechaSeguidos = 0;
                else if (UltimoCostadoColocado == 1)
                    BloquesIzquierdaSeguidos = 0;
                else
                {
                    BloquesIzquierdaSeguidos = 0;
                    BloquesDerechaSeguidos = 0;
                }

                BloquesMedioSeguidos = 0;
                BloquesMedioIzqSeguidos = 0;
                BloquesMedioDerSeguidos = 0;
            }

            else if (colocarBloqueCostado == 1 && BloquesIzquierdaSeguidos < maxBloquesIzquierdaSeguidos)
            {
                bloqueColocado = true;
                ColocarBloque(0, sckinSeccion);
                BloquesIzquierdaSeguidos++;
                BloquesDobleCostadoSeguidos = 0;
                BloquesDerechaSeguidos = 0;
                BloquesMedioSeguidos = 0;
                BloquesMedioIzqSeguidos = 0;
                BloquesMedioDerSeguidos = 0;
                UltimoCostadoColocado = 0;
            }

            else if (colocarBloqueCostado == 2 && BloquesDerechaSeguidos < maxBloquesDerechaSeguidos)
            {
                bloqueColocado = true;
                ColocarBloque(2, sckinSeccion);
                BloquesDerechaSeguidos++;
                BloquesDobleCostadoSeguidos = 0;
                BloquesIzquierdaSeguidos = 0;
                BloquesMedioSeguidos = 0;
                BloquesMedioIzqSeguidos = 0;
                BloquesMedioDerSeguidos = 0;
                UltimoCostadoColocado = 1;
            }

            else if (colocarBloqueCostado == 3 && BloquesMedioSeguidos < maxBloquesMedioSeguidos)
            {
                bloqueColocado = true;
                ColocarBloque(1, sckinSeccion);
                BloquesMedioSeguidos++;
                BloquesDobleCostadoSeguidos = 0;
                BloquesIzquierdaSeguidos = 0;
                BloquesDerechaSeguidos = 0;
                BloquesMedioIzqSeguidos = 0;
                BloquesMedioDerSeguidos = 0;
            }

            else if (colocarBloqueCostado == 4 && BloquesMedioIzqSeguidos < maxBloquesMedioIzqSeguidos)
            {
                bloqueColocado = true;
                ColocarBloque(0, sckinSeccion);
                ColocarBloque(1, sckinSeccion);
                BloquesMedioIzqSeguidos++;
                BloquesDobleCostadoSeguidos = 0;
                BloquesIzquierdaSeguidos = 0;
                BloquesDerechaSeguidos = 0;
                BloquesMedioSeguidos = 0;
                BloquesMedioDerSeguidos = 0;
            }

            else if (colocarBloqueCostado == 5 && BloquesMedioDerSeguidos < maxBloquesMedioDerSeguidos)
            {
                bloqueColocado = true;
                ColocarBloque(1, sckinSeccion);
                ColocarBloque(2, sckinSeccion);
                BloquesMedioDerSeguidos++;
                BloquesDobleCostadoSeguidos = 0;
                BloquesIzquierdaSeguidos = 0;
                BloquesDerechaSeguidos = 0;
                BloquesMedioSeguidos = 0;
                BloquesMedioIzqSeguidos = 0;
            }
        }                                                                  
    }

    bool RandomBool()
    {
        return Random.Range(0, 2) == 1 ? true : false;
    }

    void ColocarBloque(int bloqueIndex, Sckin sckin)
    {
        bloques[bloqueIndex].gameObject.SetActive(true);       
        bloques[bloqueIndex].color = ControladorSckins.self.ObtenerSckin(sckin);
    }

    void ActualizarSckin()
    {
        bool isSckinInicializada = sckinSeccion == Sckin.Bloques1 || sckinSeccion == Sckin.Bloques2;

        if (!isSckinInicializada)
        {
            sckinSeccion = Random.Range(0, 2) == 0 ? Sckin.Bloques1 : Sckin.Bloques2;
        }    

        else
        {
            sckinSeccion = sckinSeccion == Sckin.Bloques1 ? Sckin.Bloques2 : Sckin.Bloques1;
        }

        particulas.EstablecerSckin(sckinSeccion);
    }

}

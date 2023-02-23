using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] Camera camara = null;
    [SerializeField] Animator animator = null;
    [SerializeField] bool isFondoMenu; //Para solucionar el problema de tener un comportamiento diferente para el fondo del menu
    [SerializeField] Color32 fondoMenuColor;
    // Start is called before the first frame update
    void Start()
    {
        EstablecerSckin();
    }

    void EstablecerSckin()
    {
        if (!isFondoMenu)
            camara.backgroundColor = ControladorSckins.self.ObtenerSckin(Sckin.Fondo);
        else
            camara.backgroundColor = fondoMenuColor;
    }

    public void Temblar()
    {
        animator.Play(0);
    }
}

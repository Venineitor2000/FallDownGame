using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer = null;
    [SerializeField] float speed = 0;
    [SerializeField] bool isFondoMenu; //Para solucionar el problema de tener un comportamiento diferente para el fondo del menu
    [SerializeField] Color32 fondoMenuColor;
    // Start is called before the first frame update
    void Start()
    {
        EstablecerSckin();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 fondoPos = new Vector2(0, Time.deltaTime * speed);
        meshRenderer.material.mainTextureOffset += fondoPos;
    }

    void EstablecerSckin()
    {
        Color32 sckin;
        byte opacity = ((Color32)meshRenderer.material.color).a;
        if(!isFondoMenu)
        {
            sckin = ControladorSckins.self.ObtenerSckin(Sckin.Fondo);
        }
        
        else
        {
            sckin = fondoMenuColor;
        }

        sckin.a = opacity;
        meshRenderer.material.color = sckin;
    }
}

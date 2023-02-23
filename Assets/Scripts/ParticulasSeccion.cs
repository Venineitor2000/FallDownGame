using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasSeccion : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> particulas = new List<ParticleSystem>();

    public void EstablecerSckin(Sckin sckinPadre)
    {
        foreach (var particula in particulas)
        {
            var sckin = particula.main;
            sckin.startColor = (Color)ControladorSckins.self.ObtenerSckin(sckinPadre);
        }
        
    }
}

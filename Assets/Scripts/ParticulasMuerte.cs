using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasMuerte : MonoBehaviour
{
    [SerializeField] ParticleSystem particulas = null;
    // Start is called before the first frame update
    void Start()
    {
        var sckin = particulas.main;
        sckin.startColor = (Color)ControladorSckins.self.ObtenerSckin(Sckin.Jugador);
    }
}

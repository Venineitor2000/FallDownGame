using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [SerializeField] SpriteRenderer sckin = null;
    [SerializeField] TrailRenderer sckinTrial = null;
    [SerializeField] Animator animator = null;
    [SerializeField] ParticleSystem particulasMovimiento = null;
    [SerializeField] Camara camara = null;
    [SerializeField] GameObject pausa;
    [SerializeField] GameObject revivirMenu;
    [SerializeField] GameObject reiniciarInterfaz;
    bool revivido = false; //Cambiar a false cuando vuelvas a laburar, pora ahora deje en true para q siga andando como antes
    static bool muerto;

    private void OnApplicationPause(bool pause)
    {
        if (pause && SceneManager.GetActiveScene().buildIndex == 1 && !GetMuerto())
        {
            Time.timeScale = 0;
            pausa.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        muerto = false; //Como es estatica se mantiene el valor cambiado incluso despues de reiniciar la escena 
        sckin.sprite = ControladorPlayerSckin.self.ObtenerSckin();
        sckin.color = ControladorSckins.self.ObtenerSckin(Sckin.Jugador);
        sckinTrial.startColor = ControladorSckins.self.ObtenerSckin(Sckin.Jugador);

        var sckinParticulasMovimiento = particulasMovimiento.main;
        sckinParticulasMovimiento.startColor = (Color)ControladorSckins.self.ObtenerSckin(Sckin.Jugador);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("KillObject"))
        {
            camara.Temblar();
            animator.SetTrigger("JugadorMurio");
            muerto = true;
        }
    }

    void Morir() 
    {
        
            GameOver();
        
    }

    public void GameOver()
    {
        muerto = true;
        reiniciarInterfaz.SetActive(true);
        GameManager.GameOver();
    }

   

    

    public static bool GetMuerto()
    {
        return muerto;
    }
}

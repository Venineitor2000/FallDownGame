using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SckinAdministrator : MonoBehaviour
{
    [SerializeField] List<SckinUI> sckins = new List<SckinUI>();
    [HideInInspector] public SckinUI selectedSckin;
    [SerializeField] bool tiendaColores = true; //Es para elegir en q tienda estas usando, asi el script se adapta
    int sckinDesbloqueadas = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var sckin in sckins)
        {
            if (sckin.GetPrice() <= GameManager.GetHighScore())
            {
                sckin.Unlock();
                sckinDesbloqueadas++;
            }
        }
        Inicializate();

    }

    
    void Inicializate()
    {
        if(sckinDesbloqueadas <= 1)//Si tenes desbloqueada solo la sckin de base, te pone esa y lo marca en la tienda
        {
            selectedSckin = sckins[0];
            Equip();
        }
        //Si tenes mas sckins te deja la q tenes puesta y lo marca en la tienda
        else
        {
            int id = 0;
            if (tiendaColores)
                id = ControladorSckins.self.GetPaqueteActual();
            else
                id = ControladorPlayerSckin.self.GetSckinActual();
            selectedSckin = sckins.Find(x => x.GetId() == id);
            Equip(); 
        }
    }

    public void SetSelectedSckin(SckinUI sckin)
    {
        selectedSckin = sckin;
    }

    public void Equip()
    {
        if(!selectedSckin.GetIsLock())
        {
            foreach (var sckin in sckins)
            {               
                sckin.Unequip();            
            }
            selectedSckin.Equip();
            if (tiendaColores)
                ControladorSckins.self.SetPaqueteActual(selectedSckin.GetId());
            else
                ControladorPlayerSckin.self.SetSckinActual(selectedSckin.GetId());
        }
    }
}

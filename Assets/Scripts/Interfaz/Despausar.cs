using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despausar : MonoBehaviour
{

    public void QuitarPausa()
    {
        Time.timeScale = 1;
    }
}

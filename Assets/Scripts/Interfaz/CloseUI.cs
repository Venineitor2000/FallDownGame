using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    [SerializeField] GameObject UI = null;
    public void Close()
    {
        UI.SetActive(false);
    }
}

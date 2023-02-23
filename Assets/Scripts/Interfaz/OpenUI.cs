using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField] GameObject UI = null;
    public void Open()
    {
        UI.SetActive(true);
    }
}

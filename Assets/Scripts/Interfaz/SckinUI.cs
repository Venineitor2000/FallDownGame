using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SckinUI : MonoBehaviour
{
    [SerializeField] int id = 0;
    [SerializeField] Button sckin;
    [SerializeField] GameObject block;
    [SerializeField] GameObject equiped;
    [SerializeField] TextMeshProUGUI precio;
    SckinAdministrator sckinAdministrator;
    bool isLock = true;

    private void Start()
    {
        sckinAdministrator = transform.parent.GetComponent<SckinAdministrator>();
    }

    public void Selected()
    {
        sckinAdministrator.SetSelectedSckin(this);
    }

    public void Unlock()
    {
        isLock = false;
        block.SetActive(false);
        ChangeNormalColor(0);
    }

    public void Equip()
    {
        if(!isLock)
        {
            equiped.SetActive(true);
        }
    }

    public void Unequip()
    {
        if (!isLock)
        {
            equiped.SetActive(false);
        }
    }

    public int GetPrice()
    {
        return int.Parse(precio.text);
    }

    public bool GetIsLock()
    {
        return isLock;
    }

    public int GetId()
    {
        return id;
    }

    void ChangeNormalColor(int alpha)
    {
        ColorBlock cb = sckin.colors;
        Color color = sckin.colors.normalColor;
        color.a = alpha;
        cb.normalColor = color;
        sckin.colors = cb;
    }
}

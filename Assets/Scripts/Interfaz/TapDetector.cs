using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TapDetector : MonoBehaviour
{
    [SerializeField] CloseUI closeUI = null;
    [SerializeField] OpenUI openUI = null;
    [SerializeField] GraphicRaycaster m_Raycaster = null;    
    [SerializeField] EventSystem m_EventSystem = null;
    PointerEventData m_PointerEventData;
    [SerializeField] UnityEvent OnTap = new UnityEvent();

    //no sirve para ui, hay q usar el graphicraycaster
    bool DetectTap()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        if (results.Count == 0)
            return true;
        else
            return false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(DetectTap())
            {
                OnTap.Invoke();
            }
        }          
    }
}

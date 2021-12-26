using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class exit : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData e)//necessary
    {
        Debug.Log("endddd");
        Application.Quit();
    }
}

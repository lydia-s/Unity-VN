using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text;
    

    public void OnPointerEnter(PointerEventData eventData) {
        text.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData) {
        text.SetActive(false);
    }
   


}

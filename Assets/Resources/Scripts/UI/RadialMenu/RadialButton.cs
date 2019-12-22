using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image circle;
    public Image icon;
    public string title;
    public RadialMenu myMenu;
    string clickedObj;
    public float speed = 8f;
    Color defaultColor;

    public void Anim()
    {
        StartCoroutine(AnimateButtonIn());
    }

    IEnumerator AnimateButtonIn() {
        transform.localScale = Vector3.zero;
        float timer = 0f;
        while (timer < (1/speed)) {
            timer += Time.deltaTime;
            transform.localScale = Vector3.one * timer*speed;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
    private void Start()
    {
        clickedObj = myMenu.label.text;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        myMenu.selected = this;
        defaultColor = circle.color;
        circle.color = Color.grey;
        myMenu.label.text = title.ToUpper();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selected = null;
        circle.color = defaultColor;
        myMenu.label.text = clickedObj;
    }

}

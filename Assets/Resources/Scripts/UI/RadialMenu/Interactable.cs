using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Interactable : MonoBehaviour, IPointerDownHandler
{ 

    [System.Serializable]
    public class Action {
        public Color color;
        public Sprite sprite;
        public string title;
    }
    public string title;
    public Action[] options;

    void Start() {
        if (title == "" || title ==null) {
            title = gameObject.name;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //tell the canvas to spawn a menu
        RadialMenuSpawner.ins.SpawnMenu(this);
        
    }
}

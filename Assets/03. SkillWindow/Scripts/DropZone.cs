using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
	}
	
	public void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
            //d.parentToReturnTo = transform;
            if(name == "SkillBook")
            {
                CoolDownManager.Instance.Delete(d.gameObject);
                Destroy(d.gameObject);
            }
            else
            {
                d.GetDraggable().parentToReturnTo = transform;
            }
		}

        /*
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
            Debug.Log("Draggable.name : " + d.name);
			d.parentToReturnTo = transform;
		}
        */
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public Transform parentToReturnTo = null;

    private Vector3 originScale;
    private Draggable draggableObject = null;
    public Draggable GetDraggable()
    {
        return draggableObject;
    }

	public void OnBeginDrag(PointerEventData eventData) {
        if(transform.parent.name == "SkillBook")
        {
            originScale = transform.localScale;
            draggableObject = Instantiate(gameObject).GetComponent<Draggable>();
            draggableObject.parentToReturnTo = transform.parent;
            draggableObject.transform.SetParent(transform.parent.parent);
            draggableObject.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        /*
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent( this.transform.parent.parent );
		GetComponent<CanvasGroup>().blocksRaycasts = false;
        */
        /*
        originScale = transform.localScale;
	    draggableObject = Instantiate(gameObject).GetComponent<Draggable>();
        draggableObject.parentToReturnTo = transform.parent;
        draggableObject.transform.SetParent(transform.parent.parent);
	    draggableObject.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        */
	}

	public void OnDrag(PointerEventData eventData) {
		//this.transform.position = eventData.position;
        if(transform.parent.name == "SkillBook")
        {
	        draggableObject.transform.position = eventData.position;
        }
        else
        {
            transform.position = eventData.position;
        }
	}
	
	public void OnEndDrag(PointerEventData eventData) {
        if(transform.parent.name == "SkillBook")
        {
            draggableObject.transform.SetParent(draggableObject.parentToReturnTo);
            draggableObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            draggableObject.transform.localScale = originScale;
        }
        else
        {
            this.transform.SetParent( parentToReturnTo );
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        //this.transform.SetParent( parentToReturnTo );
        //GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}

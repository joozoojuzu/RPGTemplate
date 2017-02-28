using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item.Part part;
	public void OnPointerEnter(PointerEventData eventData)
    {
	}
	
	public void OnPointerExit(PointerEventData eventData)
    {
	}

    public void OnDrop(PointerEventData eventData)
    {
        ItemProperty itemProperty = eventData.pointerDrag.GetComponent<ItemProperty>();
        if (itemProperty.item.part == part)
        {
            EquipDraggable equipDraggable = eventData.pointerDrag.GetComponent<EquipDraggable>();
            equipDraggable.returnParent = transform;
        }
    }
}

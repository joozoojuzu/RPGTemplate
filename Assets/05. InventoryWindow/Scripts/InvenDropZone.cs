using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenDropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        EquipDraggable equipDraggable = eventData.pointerDrag.GetComponent<EquipDraggable>();
        equipDraggable.returnParent = transform;
    }
}

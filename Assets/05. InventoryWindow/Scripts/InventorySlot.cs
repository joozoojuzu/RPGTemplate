using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public List<GameObject> slotObjects = new List<GameObject>();

    void Start()
    {
        MakeSlots();
    }

    public Sprite slotImage;
    private void MakeSlots()
    {
        Vector2 size = new Vector2(slotImage.rect.width, slotImage.rect.height);

        for (int i = 0; i < 30; i++)
        {
            GameObject newSlotImage = new GameObject("" + (i + 1));
            newSlotImage.AddComponent<Image>().sprite = slotImage;
            newSlotImage.transform.SetParent(transform);
            RectTransform rt = newSlotImage.GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
            rt.sizeDelta = size;
            newSlotImage.AddComponent<InvenDropZone>();
            slotObjects.Add(newSlotImage);
        }

        for (int i = 0; i < 3; i++)
        {
            string id = "ID_2017_000" + (i + 1);
            GameObject itemImage = new GameObject(id);

            ItemProperty itemProperty = itemImage.AddComponent<ItemProperty>();
            itemProperty.SizeDelta(size);
            itemProperty.LoadItem(id);

            slotObjects[i].AddChild(itemImage);
        }
    }
}






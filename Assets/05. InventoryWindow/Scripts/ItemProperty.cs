using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(EquipDraggable))]
[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(EventSystem))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Image))]
public class ItemProperty : MonoBehaviour
{
    public Item item;
    private EventTrigger eventTrigger;
    private float screenWidth;
    public void SizeDelta(Vector2 sizeDelta)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x * 0.8f, sizeDelta.y * 0.8f);
    }

    public void LoadIcon(string id)
    {
        GetComponent<Image>().sprite = ItemDatabase.Instance.icons[id].sprite;
    }

    public void LoadItem(string id)
    {
        LoadIcon(id);
        item = ItemDatabase.Instance.GetItem(id);
    }

    void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();

        screenWidth = Screen.width;

        AddEventTrigger(OnPointerEnter, EventTriggerType.PointerEnter);
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit);
    }

    private void AddEventTrigger(UnityAction action, EventTriggerType triggerType)
    {
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
        trigger.AddListener((eventData) => action());

        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };
        eventTrigger.triggers.Add(entry);
    }

    private void AddEventTrigger(UnityAction<BaseEventData> action, EventTriggerType triggerType)
    {
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
        trigger.AddListener((eventData) => action(eventData));

        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };
        eventTrigger.triggers.Add(entry);
    }

    private GameObject itemDescription;
    private void OnPointerEnter()
    {
        Debug.Log("Enter !");
        itemDescription = PrefabLoader.LoadPrefab(PrefabLoader.cPrefabDir, "ItemDescription");

        transform.root.gameObject.AddChild(itemDescription);

        RectTransform rt = itemDescription.GetComponent<RectTransform>();
        rt.pivot = new Vector2(0, 1);

        itemDescription.transform.position = new Vector3(
            GetComponent<RectTransform>().position.x + (GetComponent<RectTransform>().rect.width / 2), 
            GetComponent<RectTransform>().position.y + (GetComponent<RectTransform>().rect.height / 2), 
            itemDescription.transform.position.z
            );

        itemDescription.transform.localScale = new Vector3(
            (rt.localScale.x * transform.root.localScale.x) * 0.7f,
            (rt.localScale.y * transform.root.localScale.y) * 0.7f,
            (rt.localScale.z * transform.root.localScale.z) * 0.7f
            );


        ItemDescription description = itemDescription.GetComponent<ItemDescription>();
        description.descriptions[(int)ItemDescription.Description.Name].text = item.nameString;
        description.descriptions[(int) ItemDescription.Description.DungeonLevel].text = item.dungeonLevelString;
        description.descriptions[(int) ItemDescription.Description.Wearable].text = item.wearableString;
        description.descriptions[(int) ItemDescription.Description.WearingLocation].text = item.locationString;
        description.descriptions[(int) ItemDescription.Description.Stat].text = item.statString;
        description.descriptions[(int) ItemDescription.Description.Classes].text = item.classesString;
        description.descriptions[(int) ItemDescription.Description.RequiredLevel].text = item.requireLevelString;
        description.descriptions[(int) ItemDescription.Description.Price].text = item.priceString;
    }

    private void OnPointerExit()
    {
        Debug.Log("Exit !");
        if (itemDescription != null)
        {
            Destroy(itemDescription);
            itemDescription = null;
        }
    }
}

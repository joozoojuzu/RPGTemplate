using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Icon
{
    public Sprite sprite;
}

public class ItemDatabase : MonoBehaviour
{
    private Dictionary<string, Item> items = new Dictionary<string, Item>();
    public Dictionary<string, Icon> icons = new Dictionary<string, Icon>();

    private static ItemDatabase instance;

    public static ItemDatabase Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        {
            string id = "ID_2017_0001";
            Item item = new Item();
            item.part = Item.Part.Head;
            item.grade = Item.Grade.Hero;
            item.wearable = Item.Wearable.Wearing;
            item.classes = Classes.Name.DeathKnight;

            item.id = id;
            item.nameString = "오우거해골 뼈판금 철갑투구";
            item.dungeonLevelString = "신화 전쟁벼림";
            item.itemLevelString = "아이템 레벨: 701";
            item.wearableString = "획득시 귀속";
            item.locationString = "머리";
            item.statString = "방어도 314\n힘 + 323\n체력 + 485\n가속 + 189\n연속타격 + 231";
            item.classesString = "직업: 죽음의 기사";
            item.requireLevelString = "최소 요구 레벨: 110";
            item.priceString = "판매 가격: 20골드";

            instance.items.Add(id, item);
            Sprite sprite = Resources.Load("Texture/Equipments/Plate/inv_plate_helm", typeof(Sprite)) as Sprite;
            Icon icon = new Icon();
            icon.sprite = sprite;
            instance.icons.Add(id, icon);
        }

        {
            string id = "ID_2017_0002";
            Item item = new Item();
            item.part = Item.Part.Chest;
            item.grade = Item.Grade.Hero;
            item.wearable = Item.Wearable.Wearing;
            item.classes = Classes.Name.DeathKnight;

            item.id = id;
            item.nameString = "오우거해골 뼈판금 흉갑";
            item.dungeonLevelString = "신화 전쟁벼림";
            item.itemLevelString = "아이템 레벨: 701";
            item.wearableString = "획득시 귀속";
            item.locationString = "가슴";
            item.statString = "방어도 386\n힘 + 323\n체력 + 485\n특화 + 231\n연속타격 + 189";
            item.classesString = "직업: 죽음의 기사";
            item.requireLevelString = "최소 요구 레벨: 110";
            item.priceString = "판매 가격: 19골드";

            instance.items.Add(id, item);
            Sprite sprite = Resources.Load("Texture/Equipments/Plate/inv_plate_chest", typeof(Sprite)) as Sprite;
            Icon icon = new Icon();
            icon.sprite = sprite;

            instance.icons.Add(id, icon);
        }

        {
            string id = "ID_2017_0003";
            Item item = new Item();
            item.part = Item.Part.Pants;
            item.grade = Item.Grade.Hero;
            item.wearable = Item.Wearable.Wearing;
            item.classes = Classes.Name.DeathKnight;

            item.id = id;
            item.nameString = "오우거해골 뼈판금 경갑";
            item.dungeonLevelString = "신화 전쟁벼림";
            item.itemLevelString = "아이템 레벨: 701";
            item.wearableString = "획득시 귀속";
            item.locationString = "다리";
            item.statString = "방어도 338\n힘 + 323\n체력 + 485\n치명타 및 극대화 + 216\n연속타격 + 216";
            item.classesString = "직업: 죽음의 기사";
            item.requireLevelString = "최소 요구 레벨: 110";
            item.priceString = "판매 가격: 21골드";

            instance.items.Add(id, item);

            Sprite sprite = Resources.Load("Texture/Equipments/Plate/inv_plate_pant", typeof(Sprite)) as Sprite;
            Icon icon = new Icon();
            icon.sprite = sprite;
            instance.icons.Add(id, icon);
        }
    }

    public Item GetItem(string id)
    {
        return instance.items[id];
    }

    public Sprite GetIcon(string id)
    {
        return instance.icons[id].sprite;
    }
}

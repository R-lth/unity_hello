using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject ItemPrefab;       //Item
    public GameObject Root;             //canvers grid
    public List<Item> ItemList = new List<Item>();      //Inven 아이템 객체    

    public List<ItemInfo> ItemInfoList = new List<ItemInfo>(); //보유 아이템

    void Start()
    {
        ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "apple", Level = 3, Prefab = "itemicon/apple" });
        ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "apple", Level = 2, Prefab = "itemicon/apple" });
        ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "axe", Level = 1, Prefab = "itemicon/axe" });
        ItemInfoList.Add(new ItemInfo() { Type = 2, Name = "book", Level = 2, Prefab = "itemicon/book" });
        ItemInfoList.Add(new ItemInfo() { Type = 2, Name = "boots", Level = 1, Prefab = "itemicon/boots" });

        Refresh();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(new ItemInfo() { Name = "", Grade = 1, Level = 1, Prefab = "itemicon/apple" });
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(ItemList.Count > 0) RemoveItem(ItemList[0]);
        }
    }

    Item AddItem(ItemInfo iteminfo) 
    {
        //ItemInfoList.Add(iteminfo);

        GameObject go = Instantiate(ItemPrefab);  //Instantiate
        go.transform.SetParent(Root.transform);

        Item item = go.GetComponent<Item>();        
        item.Setup( Guid.NewGuid().ToString(), iteminfo, Callback);
        //item.Setup( Guid.NewGuid().ToString(), iteminfo, (rt) => { print(rt); });

        ItemList.Add(item);

        return item;
    }

    void Callback(string uid)
    {
        print(uid);        
        //Item item = FindItem(uid); RemoveItem(item);   //imsi test
    }

    void RemoveItem(Item item) 
    {
        ItemList.Remove(item);
        Destroy(item.gameObject);                                     
    }

    Item FindItem(string _uid) 
    {
        Item item = ItemList.Find(a => a.itemInfo.UID == _uid);
        return item;
    }
    //--------------------------------------------------------------------
    int type_num = 0;
    void Refresh()
    {
        ItemList.RemoveAll(a=>true);
        GameObject_del_child(Root);

        foreach (var item in ItemInfoList) {
            if (type_num != 0 && type_num != item.Type) continue;
            AddItem(item);
        }
    }

    void GameObject_del_child(GameObject source)
    {
        Transform[] AllData = source.GetComponentsInChildren<Transform>(true); //비활성포함.
        foreach (Transform Obj in AllData) {
            if (Obj.gameObject != source) //자신 제외. 
            {
                Destroy(Obj.gameObject);
            }
        }
    }
    //--------------------------------------------------------------------
    public void SetType(int _type)
    {
        type_num = _type;
        Refresh();
    }
    //--------------------------------------------------------------------
    public void SetSort(int _sort) 
    {
        if (_sort == 0) ItemInfoList.Sort((a,b)=> a.Level.CompareTo(b.Level));  //by level
        if (_sort == 1) ItemInfoList.Sort(CompareName); // by name
        Refresh();
    }
    public int CompareName(ItemInfo a, ItemInfo b)
    {
        //if ((a == null) || (b == null)) throw new ApplicationException("error: CompareName");
        return a.Name.CompareTo(b.Name);
    }
}

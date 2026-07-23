using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Target Inventory")]
    public InventoryComponent targetInventory;

    [Header("Slot UI List")]
    public List<SlotUI> slotsUI;

    private void Awake()
    {
        slotsUI = new List<SlotUI>(GetComponentsInChildren<SlotUI>(true));
    }

    private void OnEnable()
    {
        if (targetInventory == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                targetInventory = player.GetComponent<InventoryComponent>();
            }
        }

        if (targetInventory != null)
        {
            targetInventory.OnInventoryChanged -= Redraw;
            targetInventory.OnInventoryChanged += Redraw;
            Redraw();
        }
    }

    private void OnDisable()
    {
        if (targetInventory != null) 
        {
            targetInventory.OnInventoryChanged -= Redraw;
        }
    }

    public void Redraw()
    {
        for (int i = 0; i < slotsUI.Count; i++)
        {
            slotsUI[i].Init(i, targetInventory);
            slotsUI[i].UpdateSlotUI(targetInventory.slots[i]);
        }
    }
}

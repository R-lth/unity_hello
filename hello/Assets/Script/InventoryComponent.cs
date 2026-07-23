using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    public ItemTemplete.Slot mySlot;

    [Header("Inventory Settings")]
    public int maxItemCnt = 5; // 슬롯당 최대 중첩 개수
    public int maxSlotCnt = 5; // 전체 슬롯 개수

    public event Action OnInventoryChanged;
    public List<ItemTemplete.Slot> slots;

    private void Awake()
    {
        slots = new List<ItemTemplete.Slot>(maxSlotCnt);

        for (int i = 0; i < maxSlotCnt; ++i)
        {
            slots.Add(new ItemTemplete.Slot(default, 0));
        }
    }

    public bool AddItem(ItemTemplete.Item newItem)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].IsEmpty && slots[i].item.id == newItem.id)
            {
                if (slots[i].cnt < maxItemCnt)
                {
                    slots[i] = new ItemTemplete.Slot(newItem, slots[i].cnt + 1);
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsEmpty)
            {
                slots[i] = new ItemTemplete.Slot(newItem, 1);
                OnInventoryChanged?.Invoke();
                return true;
            }
        }

        return false;
    }


    public void Subtract(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slots.Count) return;

        ItemTemplete.Slot slot = slots[slotIndex];

        if (slot.IsEmpty)
        {
            return;
        }

        slot.cnt--;

        if (slot.cnt <= 0)
        {
            slot = new ItemTemplete.Slot(default, 0);
        }

        slots[slotIndex] = slot;
        OnInventoryChanged?.Invoke();

        return;
    }
}
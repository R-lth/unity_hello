using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SlotUI : MonoBehaviour
{
    public ItemTemplete.Slot mySlot;

    [Header("UI Elements")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI countText;

    private int slotIndex;
    private InventoryComponent targetInventory;

    private void Awake()
    {
        Button btn = GetComponentInChildren<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnClickUseButton);
        }
    }

    public void Init(int index, InventoryComponent inventory)
    {
        slotIndex = index;
        targetInventory = inventory;
    }

    public void UpdateSlotUI(ItemTemplete.Slot slot)
    {
        if ((nameText == null) || (countText == null)) 
        {
            return;
        }

        if (slot.IsEmpty)
        {
            nameText.text = "None";
            countText.text = "0";
        }
        else
        {
            nameText.text = slot.item.itemName;
            countText.text = slot.cnt.ToString();
        }
    }

    public void OnClickUseButton()
    {
        if (targetInventory != null)
        {
            targetInventory.Subtract(slotIndex);
        }
    }
}

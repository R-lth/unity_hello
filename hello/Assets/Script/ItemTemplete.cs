// InventorySystem.cs
using UnityEngine;

public class ItemTemplete : MonoBehaviour
{
    [System.Serializable]
    public enum Stat { None, Hp, Atk }

    [System.Serializable]
    public struct Item
    {
        public string name;
        public int id;
        public Stat stats;
    }

    [System.Serializable]
    public struct Slot
    {
        public Item item;
        public int cnt;

        public readonly bool IsEmpty => cnt <= 0 || item.id == 0;

        public Slot(Item newItem, int cnt = 1)
        {
            this.item = newItem;
            this.cnt = cnt;
        }
    }
}
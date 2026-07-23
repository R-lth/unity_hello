using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public ItemTemplete.Item myItem;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowPickupPopup(this);
        }
    }
}

using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    public GameObject pickupPopupUI;
    public TextMeshProUGUI popupText;

    [Header("Player Target")]
    public InventoryComponent playerInventory;

    private FieldItem currentItem; 

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        if (playerInventory == null) { playerInventory = FindAnyObjectByType<InventoryComponent>(); }
    }

    public void ShowPickupPopup(FieldItem item)
    {
        currentItem = item;
        pickupPopupUI.SetActive(true);
        popupText.text = $"{currentItem.myItem.name}를 획득하시겠습니까?";
    }

    public void OnClickYes()
    {
        if (currentItem != null && playerInventory != null)
        {
            bool isAdded = playerInventory.AddItem(currentItem.myItem);

            if (isAdded)
            {
                // todo. 오브젝트 풀링
                Destroy(currentItem.gameObject);
            }
            else 
            {
                Debug.LogWarning("인벤토리가 가득 차서 아이템을 주울 수 없습니다!");
            }
        }

        ClosePopup();
    }

    public void OnClickNo()
    {
        ClosePopup();
    }

    private void ClosePopup()
    {
        pickupPopupUI.SetActive(false);
        currentItem = null;
    }
}

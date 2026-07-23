using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    public GameObject pickupPopupUI;
    public TextMeshProUGUI popupText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton; 

    [Header("Player Target")]
    public InventoryComponent playerInventory;

    private Action onYesConfirmed; 

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        // YES 버튼 이벤트 바인딩
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() =>
        {
            onYesConfirmed?.Invoke();
            ClosePopup();
        });

        // NO 버튼 이벤트 바인딩
        if (noButton != null)
        {
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(ClosePopup);
        }
    }

    private void Start()
    {
        if (playerInventory == null) { playerInventory = FindAnyObjectByType<InventoryComponent>(); }
    }

    public void ShowPickupPopup(FieldItem item)
    {
        popupText.text = $"{item.myItem.itemName}를 획득하시겠습니까?";

        // Yes 버튼에 이벤트 송신
        onYesConfirmed = () =>
        {
            if (playerInventory != null && playerInventory.AddItem(item.myItem))
            {
                Destroy(item.gameObject);
            }
        };

        pickupPopupUI.SetActive(true);
    }

    public void ClosePopup()
    {
        pickupPopupUI.SetActive(false);
        onYesConfirmed = null;
    }
}

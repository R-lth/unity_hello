using System;
using TMPro;
using UnityEngine;

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

    // 1. 필드 아이템 획득 팝업
    public void ShowPickupPopup(FieldItem item)
    {
        popupText.text = $"{item.myItem.itemName}를 획득하시겠습니까?";

        // YES 누르면 실행될 동작을 Action으로 넘김!
        onYesConfirmed = () =>
        {
            if (playerInventory != null && playerInventory.AddItem(item.myItem))
            {
                Destroy(item.gameObject);
            }
        };

        pickupPopupUI.SetActive(true);
    }

    // 2. 만약 나중에 아이템 사용/버리기 확인 팝업도 필요하다면? 그냥 만들어 쓰면 됨!
    public void ShowConfirmPopup(string message, Action onConfirm)
    {
        popupText.text = message;
        onYesConfirmed = onConfirm; // 넘겨받은 동작 세팅
        pickupPopupUI.SetActive(true);
    }

    public void ClosePopup()
    {
        pickupPopupUI.SetActive(false);
        onYesConfirmed = null; // 초기화
    }
}

//public class UIManager : MonoBehaviour
//{
//    public static UIManager Instance { get; private set; }

//    [Header("UI References")]
//    public GameObject pickupPopupUI;
//    public TextMeshProUGUI popupText;

//    [Header("Player Target")]
//    public InventoryComponent playerInventory;

//    private FieldItem currentItem; 

//    private void Start()
//    {
//        if (playerInventory == null) { playerInventory = FindAnyObjectByType<InventoryComponent>(); }
//    }

//    public void ShowPickupPopup(FieldItem item)
//    {
//        currentItem = item;
//        pickupPopupUI.SetActive(true);
//        popupText.text = $"{currentItem.myItem.itemName}를 획득하시겠습니까?";
//    }

//    public void OnClickYes()
//    {
//        if (currentItem != null && playerInventory != null)
//        {
//            bool isAdded = playerInventory.AddItem(currentItem.myItem);

//            if (isAdded)
//            {
//                // todo. 오브젝트 풀링
//                Destroy(currentItem.gameObject);
//            }
//        }

//        ClosePopup();
//    }

//    public void OnClickNo()
//    {
//        ClosePopup();
//    }

//    private void ClosePopup()
//    {
//        pickupPopupUI.SetActive(false);
//        currentItem = null;
//    }
//}

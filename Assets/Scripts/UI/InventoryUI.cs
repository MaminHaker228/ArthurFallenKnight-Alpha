using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject inventoryPanel;
    public Transform itemContainer;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;
    public Button useButton;
    public Button equipButton;

    private InventoryManager inventory;
    private InventoryManager.Item selectedItem;

    private void Start()
    {
        inventory = InventoryManager.Instance;
        inventory.OnInventoryChanged += RefreshUI;

        Input.GetKeyDown(KeyCode.I);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if (inventoryPanel.activeSelf)
        {
            RefreshUI();
        }
    }

    private void RefreshUI()
    {
        // Clear existing items
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        // Add items to UI
        foreach (InventoryManager.Item item in inventory.GetInventory())
        {
            GameObject itemUI = new GameObject("ItemSlot");
            itemUI.transform.SetParent(itemContainer);

            Button itemButton = itemUI.AddComponent<Button>();
            itemButton.onClick.AddListener(() => SelectItem(item));

            TextMeshProUGUI itemText = itemUI.AddComponent<TextMeshProUGUI>();
            itemText.text = $"{item.itemName} x{item.quantity}";
        }
    }

    private void SelectItem(InventoryManager.Item item)
    {
        selectedItem = item;
        itemNameText.text = item.itemName;
        itemDescText.text = item.description;
        useButton.interactable = true;
        equipButton.interactable = true;
    }

    public void UseItem()
    {
        if (selectedItem != null)
        {
            // Item usage logic
            inventory.RemoveItem(selectedItem.itemId);
        }
    }

    public void EquipItem()
    {
        if (selectedItem != null)
        {
            inventory.EquipItem(selectedItem.itemId);
        }
    }
}

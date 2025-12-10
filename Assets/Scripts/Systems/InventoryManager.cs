using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [System.Serializable]
    public class Item
    {
        public string itemId;
        public string itemName;
        public string description;
        public enum Rarity { Common, Rare, Legendary }
        public Rarity rarity = Rarity.Common;
        public int quantity = 1;
        public bool isEquipped = false;
    }

    private List<Item> inventory = new List<Item>();
    public delegate void InventoryChangedDelegate();
    public InventoryChangedDelegate OnInventoryChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeStartingItems();
    }

    private void InitializeStartingItems()
    {
        AddItem("memory_fragment", "Memory Fragment", "A fragment of forgotten memories", Item.Rarity.Rare, 1);
        AddItem("healing_potion", "Healing Potion", "Restores 50 health", Item.Rarity.Common, 3);
        AddItem("dark_artifact", "Dark Artifact", "Whispers of ancient darkness", Item.Rarity.Legendary, 1);
        AddItem("blade_shard", "Blade Shard", "Fragment of a legendary sword", Item.Rarity.Rare, 1);
    }

    public void AddItem(string id, string name, string desc, Item.Rarity rarity, int amount = 1)
    {
        Item existingItem = inventory.Find(i => i.itemId == id);

        if (existingItem != null)
        {
            existingItem.quantity += amount;
        }
        else
        {
            inventory.Add(new Item
            {
                itemId = id,
                itemName = name,
                description = desc,
                rarity = rarity,
                quantity = amount
            });
        }

        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(string id, int amount = 1)
    {
        Item item = inventory.Find(i => i.itemId == id);
        if (item != null)
        {
            item.quantity -= amount;
            if (item.quantity <= 0)
            {
                inventory.Remove(item);
            }
            OnInventoryChanged?.Invoke();
        }
    }

    public void EquipItem(string id)
    {
        foreach (Item item in inventory)
        {
            if (item.itemId == id)
            {
                item.isEquipped = true;
            }
            else if (item.isEquipped)
            {
                item.isEquipped = false;
            }
        }
        OnInventoryChanged?.Invoke();
    }

    public List<Item> GetInventory()
    {
        return inventory;
    }

    public Item GetItem(string id)
    {
        return inventory.Find(i => i.itemId == id);
    }
}

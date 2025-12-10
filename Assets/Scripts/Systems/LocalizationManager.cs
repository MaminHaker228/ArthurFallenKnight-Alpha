using UnityEngine;
using System.Collections.Generic;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }

    private bool isRussian = true;
    private Dictionary<string, Dictionary<string, string>> localizations = new Dictionary<string, Dictionary<string, string>>();

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

        LoadLocalizations();
    }

    private void LoadLocalizations()
    {
        // Russian
        localizations["RU"] = new Dictionary<string, string>
        {
            {"ui_inventory", "Инвентарь"},
            {"ui_health", "Здоровье"},
            {"ui_stamina", "Выносливость"},
            {"ui_equip", "Надеть"},
            {"ui_use", "Использовать"},
            {"menu_start", "Начать игру"},
            {"menu_settings", "Настройки"},
            {"menu_quit", "Выход"}
        };

        // English
        localizations["EN"] = new Dictionary<string, string>
        {
            {"ui_inventory", "Inventory"},
            {"ui_health", "Health"},
            {"ui_stamina", "Stamina"},
            {"ui_equip", "Equip"},
            {"ui_use", "Use"},
            {"menu_start", "Start Game"},
            {"menu_settings", "Settings"},
            {"menu_quit", "Quit"}
        };
    }

    public string GetText(string key)
    {
        string lang = isRussian ? "RU" : "EN";
        if (localizations[lang].ContainsKey(key))
        {
            return localizations[lang][key];
        }
        return key;
    }

    public void SetLanguage(bool russian)
    {
        isRussian = russian;
    }

    public bool IsRussian => isRussian;
}

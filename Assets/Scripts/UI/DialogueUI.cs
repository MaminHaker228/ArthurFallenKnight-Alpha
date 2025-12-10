using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("Dialogue UI")]
    public Button continueButton;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
        continueButton.onClick.AddListener(() => dialogueManager.ContinueDialogue());
    }
}

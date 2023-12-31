using System;
using System.Collections.Generic;
using Conversa.Runtime.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject messageWindow;
    [SerializeField] private GameObject choiceWindow;
    [SerializeField] private Image avatarImage;
    [SerializeField] private TextMeshProUGUI actorNameText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button nextMessageButton;
    [SerializeField] private GameObject teamPanel;

    [SerializeField] private GameObject choiceOptionButtonPrefab;
    [SerializeField] private GameObject teamAvatarPrefab;

    public void ShowMessage(string actor, string message, Sprite avatar, Action onContinue)
    {
        // choiceWindow.SetActive(false);
        messageWindow.SetActive(true);

        UpdateImage(avatar);
        actorNameText.text = actor;
        messageText.text = message;

        nextMessageButton.enabled = true;
        nextMessageButton.onClick.RemoveAllListeners();
        nextMessageButton.onClick.AddListener(() => onContinue());
    }

    public void ShowChoice(string actor, string message, Sprite avatar, List<Option> options)
    {
        messageWindow.SetActive(true);

        UpdateImage(avatar);
        actorNameText.text = actor;
        messageText.text = message;
        nextMessageButton.enabled = false;

        choiceWindow.SetActive(true);

        foreach (Transform child in choiceWindow.transform)
            Destroy(child.gameObject);

        options.ForEach(option =>
        {
            var instance = Instantiate(choiceOptionButtonPrefab, Vector3.zero, Quaternion.identity);
            instance.transform.SetParent(choiceWindow.transform);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = option.Message;
            instance.GetComponent<Button>().onClick.AddListener(() => option.Advance());
        });
    }

    private void UpdateImage(Sprite sprite)
    {
        avatarImage.enabled = sprite != null;
        avatarImage.sprite = sprite;
    }

    public void Hide()
    {
        messageWindow.SetActive(false);
        choiceWindow.SetActive(false);
    }

    public void AddTeam(Sprite Avatar){
        var instance = Instantiate(teamAvatarPrefab, Vector3.zero, Quaternion.identity);
        instance.transform.SetParent(teamPanel.transform);
        // instance.GetComponentInChildren<TextMeshProUGUI>().text = "";
        instance.GetComponent<Image>().sprite = Avatar;
    }
}

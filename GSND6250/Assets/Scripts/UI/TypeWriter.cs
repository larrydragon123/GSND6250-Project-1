using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private TextMeshProUGUI tmpText;

    public bool isTyping = false;

    private void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    public void StartTyping(string textToType)
    {
        // StopAllCoroutines();
        StartCoroutine(TypeText(textToType));
    }

    private IEnumerator TypeText(string textToType)
    {
        isTyping = true;
        tmpText.text = "";
        foreach (char letter in textToType.ToCharArray())
        {
            tmpText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void Start()
    {
        // StartTyping("Damn, Where Did I put my glasses?");
    }
}

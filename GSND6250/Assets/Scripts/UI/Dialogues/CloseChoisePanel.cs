using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChoisePanel : MonoBehaviour
{
    private GameObject choiceWindow;
    // Start is called before the first frame update
    void Start()
    {
        choiceWindow = GameObject.Find("ChoicePanel");
    }

    public void ClosePanel()
    {
        choiceWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

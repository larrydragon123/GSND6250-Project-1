using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagination : MonoBehaviour
{
    public Canvas imaginationCanvas;
    public GameObject imaginationImage;
    public bool isAreaTriggered = false;
    // public float showDistance = 5f;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        imaginationImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // make the canvas face the player

        Vector3 targetPostition = new Vector3(Camera.main.transform.position.x,
            imaginationCanvas.transform.position.y,
            Camera.main.transform.position.z);
        imaginationCanvas.transform.LookAt(targetPostition);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isShowing)
        {
            if (!isAreaTriggered)
            {
                imaginationImage.SetActive(true);
                isShowing = true;
            }
        }
        isAreaTriggered = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isShowing)
        {
            if (isAreaTriggered)
            {
                imaginationImage.SetActive(false);
                isShowing = false;
            }
        }
        isAreaTriggered = false;
    }
}

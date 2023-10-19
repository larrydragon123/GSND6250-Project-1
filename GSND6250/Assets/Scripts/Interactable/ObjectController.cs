using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    public string text;
    private GameObject player;
    public GameObject parentObject;

    public bool isFloating = false;
    public bool isHighlighted = false;

    public bool isStatic = false;


    public Material highlightMaterial;
    public Material defaultMaterial;

    int rand = 0;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rand = Random.Range(0, 3);

    }


    public void OnClick()
    {
        if (this.tag == "Mushroom")
        {
            player.GetComponent<PlayerSanityStats>().NextState();
            Destroy(parentObject);
        }
    }

    void ChangeChildrenMaterial(Transform parent)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = highlightMaterial;
        }
        foreach (Transform child in parent)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material = highlightMaterial;
            }

            // Recursively change materials of the children's children
            ChangeChildrenMaterial(child);
        }
    }

    void Float()
    {
        // float height = Random.Range(0.5f, 1.5f);
        // //float into air slowly
        // parentObject.transform.position = Vector3.MoveTowards(parentObject.transform.position, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y + height, parentObject.transform.position.z), 0.5f);
    }

    void Spin()
    {

        switch (rand)
        {
            case 0:
                parentObject.transform.Rotate(0.5f, 0, 0);
                break;
            case 1:
                parentObject.transform.Rotate(0, 0.5f, 0);
                break;
            case 2:
                parentObject.transform.Rotate(0, 0, 0.5f);
                break;
        }

    }


    private void Update()
    {
        if (!isFloating && player.GetComponent<PlayerSanityStats>().state >= 2)
        {
            Float();
            isFloating = true;
        }
        else if (isFloating)
        {
            if (!isStatic)
            {
                Spin();
            }

        }
        if (!isHighlighted && player.GetComponent<PlayerSanityStats>().state >= 3)
        {
            ChangeChildrenMaterial(parentObject.transform);
            isHighlighted = true;
        }
        

    }
}

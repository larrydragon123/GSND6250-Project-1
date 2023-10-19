using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerSanityStats : MonoBehaviour
{
    public int state;

    private Transform _selection;

    private GameObject previousObject;

    private GameObject textObject;

    public PostProcessVolume postProcessVolume;
    private ColorGrading colorGradingEffect;

    private Bloom bloomEffect;

    private void Start(){
        state = 0;
        
        
        
    }
    public void ColorEffect()
    {
        // Check if the Post-Processing Volume exists
        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGetSettings(out colorGradingEffect);
            // Enable the Bloom effect
            if (colorGradingEffect != null)
            {
                colorGradingEffect.active = true;
            }
        }
    }
    public void BloomEffect()
    {
        // Check if the Post-Processing Volume exists
        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGetSettings(out bloomEffect);
            // Enable the Bloom effect
            if (bloomEffect != null)
            {
                bloomEffect.active = true;
            }
        }
    }
    public void NextState()
    {
        state++;
    }
    private void ShowText()
    {
        textObject = new GameObject("WorldSpaceText");

        // Attach a TextMesh component to the GameObject.
        TextMesh textMesh = textObject.AddComponent<TextMesh>();

        // Set the text content.
        textMesh.text = "Hello, I am" + previousObject.GetComponent<ObjectController>().text;

        // Set the font size.
        textMesh.fontSize = 36;

        // Set the font style (optional).
        textMesh.fontStyle = FontStyle.Bold;

        // Set the alignment (optional).
        textMesh.alignment = TextAlignment.Center;

        // Set the anchor (optional).
        textMesh.anchor = TextAnchor.MiddleCenter;

        // Set the color (optional).
        textMesh.color = Color.blue;

        // Position the text in world space.
        textObject.transform.position = previousObject.transform.position;

        // Rotate the text (optional).
        // textObject.transform.rotation = transform.rotation;

        // Scale the text (optional).
        textObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void HideText()
    {
        Destroy(textObject);
    }

    private void Update()
    {
        if (textObject)
        {
            textObject.transform.LookAt(transform);
            textObject.transform.Rotate(0, 180, 0);
        }

        // if (_selection != null)
        // {
        //     var selectionRenderer = _selection.GetComponent<Renderer>();
        //     selectionRenderer.material = previousObject.GetComponent<ObjectController>().defaultMaterial;
        //     _selection = null;
        // }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Interactable")))
        {
            previousObject = hit.transform.gameObject;
            var selection = hit.transform;
            // previousObject.GetComponent<ObjectController>().defaultMaterial = selection.GetComponent<Renderer>().material;
            // var selectionRenderer = selection.GetComponent<Renderer>();
            // if (selectionRenderer != null)
            // {
            //     selectionRenderer.material = previousObject.GetComponent<ObjectController>().highlightMaterial;
            // }

            _selection = selection;
            //if mouse clicked debug clicked
            if (Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<ObjectController>().OnClick();
            }

            //show text
            if (textObject == null)
            {
                ShowText();
            }

        }
        else
        {
            if (previousObject)
            {
                HideText();
            }
        }

        if (!colorGradingEffect && state >= 4)
        {
            ColorEffect();
        }
        if (!bloomEffect && state >= 5)
        {
            BloomEffect();
        }
    }
}

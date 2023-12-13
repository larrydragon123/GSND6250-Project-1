using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EventController : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public GameObject textPanel;
    public GameObject fadePanel;
    public float fadeDuration = 1f;
    public TypeWriter typeWriter;

    public Volume volume;
    public Squinting squinting;
    public GameObject player;

    public GameObject GlassesStorePosition;
    public GameObject ApartmentPosition;

    private bool isClosed = false;
    private bool isFading = false;
    // Start is called before the first frame update
    void Start()
    {
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Damn, Where Did I put my glasses?");
    }


    // Update is called once per frame
    void Update()
    {
        if(typeWriter.isTyping == false && !isClosed)
        {
            StartCoroutine(DisableTextPanel());
        }
        
    }

    public void FoundGlasses(){
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Shit, my glasses are broken, gotta get a new one");
        StartCoroutine(FindPhone());
    }

    IEnumerator FindPhone(){
        yield return new WaitForSeconds(5f);
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Where is my phone, gotta call an uber");
    }

    public void CallUber(){
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Here you are, calling the uber");
        StartCoroutine(UberArrive());
    }

    public void FindGlasses(){
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Okay, gotta try on glasses to find one that fits my visual acuity");
    }

    IEnumerator UberArrive(){
        yield return new WaitForSeconds(5f);
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Okay, Uber is here gotta go");
        yield return new WaitForSeconds(3f);
        // load next scene
    }

    public void Glasses1(){
        volume.profile.TryGet(out LensDistortion lensDistortion);
        lensDistortion.intensity.value = 0.5f;
    }
    public void Glasses2(){
        volume.profile.TryGet(out ChromaticAberration chromaticAberration);
        chromaticAberration.intensity.value = 1f;
    }
    public void Glasses3(){
        volume.profile.TryGet(out Tonemapping tonemapping);
        tonemapping.SetAllOverridesTo(true);
    }
    public void Glasses4(){
        squinting.isfixed = true;
        volume.profile.TryGet(out Bloom bloom);
        bloom.SetAllOverridesTo(false);
        StartCoroutine(GoHome());

    }

    public void DoorToGlassesStore(){
        Debug.Log("DoorToGlassesStore");
        StartFade();
        StartCoroutine(GoToGlassesStore());
    }

    IEnumerator GoToGlassesStore(){
        yield return new WaitForSeconds(fadeDuration);
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<CharacterController>().transform.position = GlassesStorePosition.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
        FindGlasses();
    }

    IEnumerator GoToApartment(){
        yield return new WaitForSeconds(fadeDuration);
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<CharacterController>().transform.position = ApartmentPosition.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void DoorToApartment(){
        Debug.Log("DoorToApartment");
        StartFade();
        StartCoroutine(GoToApartment());
    }

    IEnumerator GoHome(){
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("I think this is the right one, I can see clearly now, lets go back to home");
        yield return new WaitForSeconds(3f);
        // load scene
    }

    public void FadeIn(){
        StartCoroutine(DoFade(1));
    }

    public void FadeOut(){
        StartCoroutine(DoFade(0));
    }

    public void StartFade()
    {
        if (!isFading)
        {
            StartCoroutine(CombinedFade());
        }
    }

    IEnumerator CombinedFade()
    {
        isFading = true;

        // Fade In
        yield return StartCoroutine(DoFade(1));

        // Wait for a bit after fading in
        yield return new WaitForSeconds(fadeDuration);

        // Fade Out
        yield return StartCoroutine(DoFade(0));

        isFading = false;
    }

    IEnumerator DoFade(float targetAlpha)
    {
        CanvasGroup canvasGroup = fadePanel.GetComponent<CanvasGroup>();
        float alpha = canvasGroup.alpha;

        while (!Mathf.Approximately(alpha, targetAlpha))
        {
            alpha = Mathf.MoveTowards(alpha, targetAlpha, Time.deltaTime / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }
    }


    public void ResetVision(){
        volume.profile.TryGet(out LensDistortion lensDistortion);
        lensDistortion.intensity.value = 0f;
        volume.profile.TryGet(out ChromaticAberration chromaticAberration);
        chromaticAberration.intensity.value = 0f;
        volume.profile.TryGet(out Tonemapping tonemapping);
        tonemapping.SetAllOverridesTo(false);
        squinting.isfixed = false;
        volume.profile.TryGet(out DepthOfField DOF);
        DOF.SetAllOverridesTo(true);
        volume.profile.TryGet(out Bloom bloom);
        bloom.SetAllOverridesTo(true);
    }

    IEnumerator DisableTextPanel()
    {
        isClosed = true;
        yield return new WaitForSeconds(2f);
        textPanel.SetActive(false);
    }
}

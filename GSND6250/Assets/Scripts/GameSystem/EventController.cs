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

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    public AudioSource phoneAudioSource;
    public AudioSource carAudioSource;
    public AudioSource bellAudioSource;


    private bool foundPhone = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("Damn, Where Did I put my glasses?");
        //play the first audio clip
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    IEnumerator PhoneRing(){
        //if not found ring phone every 20 seconds
        phoneAudioSource.Play();
        yield return new WaitForSeconds(20f);
        if(!foundPhone){
            StartCoroutine(PhoneRing());
        }

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
        typeWriter.StartTyping("Shit, my glasses are broken! I gotta get a new pair!");
        audioSource.clip = audioClips[1];
        audioSource.Play();
        StartCoroutine(FindPhone());
    }

    IEnumerator FindPhone(){
        yield return new WaitForSeconds(10f);
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("I need to find my phone so I can Uba over");
        StartCoroutine(PhoneRing());
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    public void CallUber(){
        textPanel.SetActive(true);
        isClosed = false;
        foundPhone = true;
        typeWriter.StartTyping("Found the phone! Lets call that Uba and go");
        audioSource.clip = audioClips[3];
        audioSource.Play();
        StartCoroutine(UberArrive());
    }
    IEnumerator UberArrive(){
        yield return new WaitForSeconds(5f);
        textPanel.SetActive(true);
        isClosed = false;
        carAudioSource.Play();
        typeWriter.StartTyping("Alright the Uba is here, let's get outside");
        audioSource.clip = audioClips[4];
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        // load next scene
    }

    public void FindGlasses(){
        textPanel.SetActive(true);
        isClosed = false;
        bellAudioSource.Play();
        typeWriter.StartTyping("Alright, there's a few pairs in here, lets try them on until we get the right one.");
        audioSource.clip = audioClips[5];
        audioSource.Play();
    }

    IEnumerator GoHome(){
        textPanel.SetActive(true);
        isClosed = false;
        typeWriter.StartTyping("This one feels really good! I can see clearly! I think it's time to head back home now!");
        audioSource.clip = audioClips[6];
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        // load scene
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

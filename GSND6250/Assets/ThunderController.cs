using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    public Light thunderLight;
    public AudioSource thunderAudio;
    public AudioClip thunderClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when press space, thunder will be triggered
        if (Input.GetKeyDown(KeyCode.T))
        {
            ThunderOneShot();
        }

    }
    public void ThunderOneShot()
    {
        StartCoroutine(ThunderOneShotCoroutine());
    }

    IEnumerator ThunderOneShotCoroutine()
    {
        thunderLight = GetComponent<Light>();
        float originalIntensity = thunderLight.intensity;

        // Blink 1: Gradually increase intensity
        thunderLight.intensity = 1f;

        // Pause for a short time
        yield return new WaitForSeconds(0.1f);

        // Blink 1: Gradually decrease intensity
        for (float t = 0; t < 0.25f; t += Time.deltaTime)
        {
            thunderLight.intensity = Mathf.Lerp(1.0f, originalIntensity, t / 0.25f);
            yield return null;
        }

        // Blink 2: Gradually increase intensity
        thunderLight.intensity = 1f;

        // Pause for a short time
        yield return new WaitForSeconds(0.1f);

        // Blink 2: Gradually decrease intensity
        for (float t = 0; t < 0.25f; t += Time.deltaTime)
        {
            thunderLight.intensity = Mathf.Lerp(1.0f, originalIntensity, t / 0.25f);
            yield return null;
        }

        // Play the thunder audio clip
        thunderAudio.PlayOneShot(thunderClip);
    }
    // public void ThunderOneShot(){
    //     StartCoroutine(ThunderOneShotCoroutine());
    // }

    // IEnumerator ThunderOneShotCoroutine(){
    //     thunderLight = GetComponent<Light>();
    //     thunderLight.intensity = 0.5f;
    //     new WaitForSeconds(0.1f);
    //     thunderLight.intensity = 0.0f;
    //     new WaitForSeconds(0.1f);
    //     thunderLight.intensity = 1f;
    //     yield return new WaitForSeconds(0.1f);
    //     thunderLight.intensity = 0.0f;
    //     thunderAudio.PlayOneShot(thunderClip);
    // }
}

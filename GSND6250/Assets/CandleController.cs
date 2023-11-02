using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public List<GameObject> candles;
    public ThunderController thunderController;
    public int currentCandle = 0;

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        //get child component
        candles[0].GetComponentInChildren<Light>().enabled = true;
        candles[0].GetComponent<SphereCollider>().enabled = true;
        candles[0].GetComponentInChildren<ParticleSystem>().Play();

        thunderController = GameObject.Find("ThunderLight").GetComponent<ThunderController>();
    }
    public void LightNextCandle(){
        StartCoroutine(LightNextCandleCoroutine());
        thunderController.ThunderOneShot();
    }

    IEnumerator LightNextCandleCoroutine(){
        candles[currentCandle].GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(10f);
        candles[currentCandle].GetComponentInChildren<Light>().enabled = false;
        candles[currentCandle].GetComponentInChildren<ParticleSystem>().Stop();
        if(currentCandle <= candles.Count - 1){
            currentCandle++;
        }else{
            door.GetComponent<MeshCollider>().enabled = false;
        }
        candles[currentCandle].GetComponentInChildren<Light>().enabled = true;
        candles[currentCandle].GetComponent<SphereCollider>().enabled = true;
        candles[currentCandle].GetComponentInChildren<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

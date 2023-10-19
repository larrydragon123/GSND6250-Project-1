using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public List<GameObject> mushrooms;
    // public int mushroomCount = 0;

    public void ShowMushroom(int count){
        if(count < mushrooms.Count){
            mushrooms[count].SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < mushrooms.Count; i++){
            mushrooms[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

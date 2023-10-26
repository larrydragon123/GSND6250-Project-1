using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conversa.Runtime;
public class TalkInteraction : MonoBehaviour
{
    public bool isTalked = false;
    public AvatarActor avatarActor;
    public Conversation conversation;

    public GameObject dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player" && !isTalked){
            Debug.Log("Player entered");
            // isTalked = true;
            dialogueSystem.GetComponent<DialogueController>().ChangeConversation(conversation);
        }
    }
}

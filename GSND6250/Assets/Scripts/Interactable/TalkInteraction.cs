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

    private bool isTalkable = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTalkable && Input.GetKeyDown(KeyCode.E) && !isTalked)
        {
            isTalked = true;
            dialogueSystem.GetComponent<DialogueController>().SetCurrentNPC(gameObject);
            dialogueSystem.GetComponent<DialogueController>().ChangeConversation(conversation);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !isTalked)
        {
            isTalkable = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !isTalked)
        {
            isTalkable = false;
        }
    }

}

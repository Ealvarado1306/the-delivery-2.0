using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class BezosCharacter : MonoBehaviour
{
    public NPCConversation myConvo;
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider other){
        ConversationManager.Instance.StartConversation(myConvo);
    }
}

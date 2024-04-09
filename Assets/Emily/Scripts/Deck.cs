using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public MyHand myHand;
    // Start is called before the first frame update
    void Start()
    {
        myHand = GameObject.FindObjectOfType<MyHand>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (myHand.cardAddedToHand == true)
        //{
       //     Invoke("MoveToPlayerHand", 2f);
       // }
    }

    void MoveToPlayerHand()
    {
        /*myHand.playerDeck.Add();
         add card from deck to player hand transfer prefab
         */
    }
}

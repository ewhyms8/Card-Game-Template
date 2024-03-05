using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>(52);
    public List<Card> player_deck = new List<Card>();
    public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();


    public Card trout;
    public Card GiantSquid;
    public Card Jellyfish;


    private float whatCard;


    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        deck.Add(trout);
    }

    // Update is called once per frame
    void Update()
    {
        whatCard = Random.Range(1, 2);
    }

    void Deal()
    {

        if (whatCard == 1)
        {
            player_deck.Add(trout);
            deck.Remove(trout);
        }

        if (whatCard == 2)
        {
            player_deck.Add(GiantSquid);
            deck.Remove(GiantSquid);
        }
    }

    void Shuffle()
    {
        
    }

    void AI_Turn()
    {
       //Ask for a card in their deck, more off a type of card = more likely to ask for that card
    }



    
}

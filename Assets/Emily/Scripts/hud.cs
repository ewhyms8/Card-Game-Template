using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hud : MonoBehaviour
{
    public TextMeshProUGUI oponentsPoints;
    public TextMeshProUGUI yourPoints;
    public float oPoints;
    public float yPoints;

    public TextMeshProUGUI deckSizeText;
    public float deckSize;
    
    public TextMeshProUGUI aiText;
    public Card WC;
    
    
    // Start is called before the first frame update
    void Start()
    {
        oPoints = 0;
        yPoints = 0;
        deckSize = 52;
        
    }

    // Update is called once per frame
    void Update()
    {
        oponentsPoints.text = "Opponents Total Points: " + oPoints;
        yourPoints.text = "Your Total Points: " + yPoints;
        deckSizeText.text = "" + deckSize;
        aiText.text = "waiting on you";
    }
    
}

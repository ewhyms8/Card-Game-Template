using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hud : MonoBehaviour
{
    public TextMeshProUGUI oponentsPoints;
    public TextMeshProUGUI yourPoints;
    

    public TextMeshProUGUI deckSizeText;
    public int deckSize;

    public TextMeshProUGUI aiText;
    public TextMeshProUGUI aiAsks;
    public GameManager gm;

    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        deckSize = 52;
        amount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        oponentsPoints.text = "Opponents Total Points: " + gm.oPoints;
        yourPoints.text = "Your Total Points: " + gm.yPoints;
        deckSizeText.text = "" + deckSize;
        aiText.text = "waiting on you";
    }

}
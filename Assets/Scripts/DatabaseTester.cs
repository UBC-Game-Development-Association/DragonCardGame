using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

public class DatabaseTester : MonoBehaviour
{
    // Start is called before the first frame update

    private List<CardStats> stats = new List<CardStats>();

    //public CardBrowser browser;
    
    public
        void Start()
    {
        stats.Add(createStats(cardType.unit, 1, 2, 2, 4, 3, "a"));
        stats.Add(createStats(cardType.unit, 1, 2, 2, 4, 3, "a"));
        stats.Add(createStats(cardType.unit, 2, 2, 3, 4, 4, "a"));
        stats.Add(createStats(cardType.unit, 1, 2, 2, 4, 3, "n"));
        
        
    }

    public List<CardStats> returnStats()
    {
        return stats;
    }
    
    public CardStats createStats(cardType type, int id,int score,int size,int sensitivity, int habitatType, string name)
    {
        CardStats thisStat = new CardStats();
        thisStat.cardID = id;
        thisStat.score = score;
        thisStat.size = size;
        thisStat.sensitivity = sensitivity;
        thisStat.habitatType = habitatType;
        thisStat.cardName = name;
        return thisStat;
    }
    
}

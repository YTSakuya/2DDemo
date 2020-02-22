using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private int cherry = 0;
    [SerializeField] private int gem = 0;

    [SerializeField] private Text cherryCount;
    [SerializeField] private Text gemCount;
    void Start()
    {
        //cherryCount=
        //gemCount=
    }

    void Update()
    {
        ShowCollections();
    }

    public void AddCherry()
    {
        cherry += 1;
    }

    public void AddGem()
    {
        gem += 1;
    }

    private void ShowCollections()
    {
        cherryCount.text = cherry.ToString();
        gemCount.text = gem.ToString();
    }
}

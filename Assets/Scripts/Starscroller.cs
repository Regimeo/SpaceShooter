using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starscroller : MonoBehaviour
{
    private GameController gameController;
    private ParticleSystem ps;
    private int counter;
    public float hSliderValue;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;
        hSliderValue = 1;
        if (gameController.score >= 100)
        {
            hSliderValue = Mathf.Lerp(1 , 10, 100);
        }        
    }
}

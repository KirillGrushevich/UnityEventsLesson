﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGameController : MonoBehaviour
{
    [SerializeField] private Sprite[] habitablePlanets;
    [SerializeField] private Sprite[] uninhabitablePlanets;
    [SerializeField] private Sprite[] gasGiants;

    [SerializeField] private float gameCycleTime = 5f;
    [SerializeField] private int planetsCount = 24;
    [SerializeField] private Planet basePlanet;

    private Planet[] planets;
    
    private IEnumerator Start()
    {
        planets = new Planet[planetsCount];
        planets[0] = basePlanet;

        for (int i = 1; i < planetsCount; i++)
        {
            planets[i] = Instantiate(basePlanet, basePlanet.transform.parent, false);
        }
        
        while (true)
        {
            var habitablePlanetNumber = Random.Range(0, planetsCount);

            for (int i = 0; i < planetsCount; i++)
            {
                if (i == habitablePlanetNumber)
                {
                    planets[i].Setup(habitablePlanets[Random.Range(0, habitablePlanets.Length)], OnHabitablePlanetClicked);
                    continue;
                }

                if (Random.Range(0, 3) == 0)
                { 
                    planets[i].Setup(uninhabitablePlanets[Random.Range(0, uninhabitablePlanets.Length)], OnUninhabitablePlanetClicked);
                    continue;
                }
                
                planets[i].Setup(gasGiants[Random.Range(0, gasGiants.Length)], OnGasGiantClicked);
            }

            yield return new WaitForSeconds(gameCycleTime);
        }
    }

    private void OnHabitablePlanetClicked()
    {
        Debug.Log("OnHabitablePlanetClicked");
    }
    
    private void OnUninhabitablePlanetClicked()
    {
        Debug.Log("OnUninhabitablePlanetClicked");
    }
    
    private void OnGasGiantClicked()
    {
        Debug.Log("OnGasGiantClicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

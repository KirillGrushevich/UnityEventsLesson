using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetGameController : MonoBehaviour
{
    [SerializeField] private Sprite[] habitablePlanets;
    [SerializeField] private Sprite[] uninhabitablePlanets;
    [SerializeField] private Sprite[] gasGiants;

    [SerializeField] private float gameCircleTime = 5f;
    [SerializeField] private int planetsCount = 24;
    [SerializeField] private Planet basePlanet;

    private Planet[] _planets;

    private IEnumerator Start()
    {
        _planets = new Planet[planetsCount];
        _planets[0] = basePlanet;

        for (var i = 1; i < planetsCount; i++)
        {
            _planets[i] = Instantiate(basePlanet, basePlanet.transform.parent, false);
        }
        
        while (true)
        {
            var habitablePlanetNumber = Random.Range(0, planetsCount);

            for (var i = 0; i < planetsCount; i++)
            {
                if (i == habitablePlanetNumber)
                {
                    _planets[i].Setup(habitablePlanets[Random.Range(0, habitablePlanets.Length)], OnHabitablePlanetClicked);
                    continue;
                }

                if (Random.Range(0, 3) == 0)
                {
                    _planets[i].Setup(uninhabitablePlanets[Random.Range(0, uninhabitablePlanets.Length)], OnUninhabitablePlanetClicked);
                    continue;
                }
                
                _planets[i].Setup(gasGiants[Random.Range(0, gasGiants.Length)], OnGasGiantPlanetClicked);
                
            }
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
    
    private void OnGasGiantPlanetClicked()
    {
        Debug.Log("OnGasGiantPlanetClicked");
    }
}

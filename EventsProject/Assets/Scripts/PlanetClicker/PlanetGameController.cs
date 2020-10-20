using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGameController : MonoBehaviour
{
    [SerializeField] private Sprite[] habitablePlanets;
    [SerializeField] private Sprite[] uninhabitablePlanets;
    [SerializeField] private Sprite[] gasGiants;

    [SerializeField] private float gameCircleTime = 5f;
    [SerializeField] private int planetCount = 24;
    [SerializeField] private Planet basePlanet;

    private Planet[] planets;
    private IEnumerator Start()
    {
        planets = new Planet[planetCount];
        planets[0] = basePlanet;
        for (int i = 1; i < planetCount; i++)
        {
            planets[i] = Instantiate(basePlanet, basePlanet.transform.parent, false);
        }
        while (true)
        {
            var habitablePlanetNumber = Random.Range(0, planetCount);
            for (int i = 0; i < planetCount; i++)
            {
                if (i==habitablePlanetNumber)
                {
                    planets[i].Setup(habitablePlanets[Random.Range(0, habitablePlanets.Length)], OnHabitablePlanetClick);
                    continue;
                }

                if (Random.Range(0,3) == 0)
                {
                    planets[i].Setup(uninhabitablePlanets[Random.Range(0, uninhabitablePlanets.Length)], OnUninhabitablePlanetClick);
                    continue;
                }
                
                planets[i].Setup(gasGiants[Random.Range(0, gasGiants.Length)], OnHGasGiantPlanetClick);
            }
            
            yield return new WaitForSeconds(gameCircleTime);
        }
    }

    private void OnHabitablePlanetClick()
    {
        Debug.Log("OnHabitablePlanetClicked");
    }
    
    private void OnUninhabitablePlanetClick()
    {
        Debug.Log("OnHabitablePlanetClicked");
    }
    
    private void OnHGasGiantPlanetClick()
    {
        Debug.Log("OnHabitablePlanetClicked");
    }
}

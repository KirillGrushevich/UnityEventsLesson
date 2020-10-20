using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MPE;
using UnityEngine;
using UnityEditor.EventSystems;
using Random = UnityEngine.Random;

public class PlanetGameControler : MonoBehaviour
{
    [SerializeField] private Sprite[] habitablePlanets;
    [SerializeField] private Sprite[] unhabitablsePlanet;
    [SerializeField] private Sprite[] HasGigant;
    [SerializeField] private float gameCircTime = 5f;
    [SerializeField] private int planetCount = 24;
    [SerializeField] private PlanetCkiker basePlanet;
    private PlanetCkiker[] planets;
    private IEnumerator Start()
    {
        planets = new PlanetCkiker[planetCount];
        planets[0] = basePlanet;
        for (int i = 0; i < planetCount; i++)
        {
            planets[i] = Instantiate(basePlanet, basePlanet.transform.parent);
        }

        while (true)
        {
            var habitPlanetNumber = Random.Range(0, planetCount);
            for (int i = 0; i < planetCount; i++)
            {
                if (i == habitPlanetNumber)
                {
                    planets[i].Setup(habitablePlanets[Random.Range(0,habitablePlanets.Length)], OnHandler);
                    continue;
                }

                if (Random.Range(0, 3) == 0)
                {
                    planets[i].Setup(habitablePlanets[Random.Range(0,HasGigant.Length)], OnHandlerGas);
                    continue;
                }
                planets[i].Setup(habitablePlanets[Random.Range(0,unhabitablsePlanet.Length)], OnHandlerUn);
                continue;
            }
            yield return new WaitForSeconds(gameCircTime);
        }
    }

    private void OnHandler()
    {
        Debug.Log("1");
    }
    private void OnHandlerGas()
    {
        Debug.Log("2");
    }
    private void OnHandlerUn()
    {
        Debug.Log("3");
    }
}

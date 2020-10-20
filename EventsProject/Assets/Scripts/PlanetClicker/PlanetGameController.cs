using System.Collections;
using UnityEngine;

public class PlanetGameController : MonoBehaviour {
    
    [SerializeField] private Sprite[] _habitablePlanets;
    [SerializeField] private Sprite[] _unInhabitablePlanets;
    [SerializeField] private Sprite[] _gasGiants;

    [SerializeField] private float _gameCircleTime = 5f;
    [SerializeField] private int _planetsCount = 24;
    [SerializeField] private Planet _basePlanet;

    private Planet[] _planets;
    
    private IEnumerator Start() {

        _planets = new Planet [_planetsCount];
        _planets[0] = _basePlanet;

        for (int i = 1; i < _planetsCount; i++) {
            _planets[i] = Instantiate(_basePlanet, _basePlanet.transform.parent, false);
        }

        while (true) {
            var habitablePlanetNumber = Random.Range(0, _planetsCount);
            for (int i = 0; i < _planetsCount; i++) {
                if (i == habitablePlanetNumber) {
                    _planets[i].Setup(_habitablePlanets[Random.Range(0, _habitablePlanets.Length)], OnHabitablePlanetClick);
                    continue;
                }
                if (Random.Range(0, 3) == 0) {
                    _planets[i].Setup(_unInhabitablePlanets[Random.Range(0, _unInhabitablePlanets.Length)],
                        OnInhabitablePlanetClick);
                    continue;
                }
                
                _planets[i].Setup(_gasGiants[Random.Range(0, _gasGiants.Length)], OnInhabitablePlanetClick);
            }    
            
            yield return new WaitForSeconds(_gameCircleTime);
        }
    }

    private void OnHabitablePlanetClick() {
        Debug.Log("OnHabitablePlanetClick");
    }
    
    private void OnInhabitablePlanetClick() {
        Debug.Log("OnInhabitablePlanetClick");
    }
}

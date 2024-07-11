using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _runes;
    [SerializeField] float _switchInterval = 5f;
    private int currentActiveIndex = -1;

    void Start()
    {
        foreach (GameObject rune in _runes)
        {
            rune.SetActive(false);
        }

        _runes[0].SetActive(true);

        // Commencer la coroutine pour alterner les objets
        StartCoroutine(SwitchActiveObject());
    }

    private IEnumerator SwitchActiveObject()
    {
        while (true)
        {
            // Attendre pendant l'intervalle spécifié
            yield return new WaitForSeconds(_switchInterval);

            _runes[0].SetActive(false);

            // Désactiver l'objet actuellement actif
            if (currentActiveIndex >= 0 && currentActiveIndex < _runes.Count)
            {
                _runes[currentActiveIndex].SetActive(false);
            }

            // Sélectionner un nouvel objet aléatoirement
            int newIndex;
            do
            {
                newIndex = Random.Range(0, _runes.Count);
            } while (newIndex == currentActiveIndex);

            // Activer le nouvel objet
            currentActiveIndex = newIndex;
            _runes[currentActiveIndex].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SymbolSpawner : MonoBehaviour {

    [SerializeField] private List<GameObject> m_symbols;
    [SerializeField] private float m_spawnRate = 2f;
    [SerializeField] private float m_spawnHeight = 5f;

    private List<GameObject> _symbolsCreated = new List<GameObject>();
    private float nextSpawn = 0f;
    private int _index;

    void Update() {

        if (Time.time > nextSpawn) {

            nextSpawn = Time.time + m_spawnRate;
            SpawnSymbol();
        }
    }

    void SpawnSymbol()
    {
        Vector3 spawnPosition = new Vector3(5, m_spawnHeight, 0);

        GameObject symbol = new GameObject();

        if (_index < m_symbols.Count) {

            symbol = m_symbols[_index];
            Instantiate(symbol, spawnPosition, Quaternion.identity);
            _symbolsCreated.Add(symbol);
            _index += 1;

        }

        else {

            int newIndex = Random.Range(0, m_symbols.Count);
            symbol = _symbolsCreated[newIndex];
            EnableSymbol(symbol);

        }

        StartCoroutine(DisableSymbol(5.0f, symbol));

    }

    private IEnumerator DisableSymbol(float waitTime, GameObject symbol) {

        yield return new WaitForSeconds(waitTime);

        foreach (LineRenderer lr in symbol.GetComponentsInChildren<LineRenderer>()) { lr.enabled = false; }
        foreach (SpriteRenderer sr in symbol.GetComponentsInChildren<SpriteRenderer>()) { sr.enabled = false; }

    }

    private void EnableSymbol(GameObject symbol) {

        foreach (LineRenderer lr in symbol.GetComponentsInChildren<LineRenderer>()) { lr.enabled = true; }
        foreach (SpriteRenderer sr in symbol.GetComponentsInChildren<SpriteRenderer>()) { sr.enabled = true; }

    }
}

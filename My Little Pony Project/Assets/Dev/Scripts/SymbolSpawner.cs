using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSpawner : MonoBehaviour {

    [SerializeField] private List<GameObject> m_symbols;
    [SerializeField] private float m_spawnRate = 2f;
    [SerializeField] private float m_spawnHeight = 5f;

    private float nextSpawn = 0f;

    void Update() {

        if (Time.time > nextSpawn) {

            nextSpawn = Time.time + m_spawnRate;
            SpawnSymbol();
        }
    }

    void SpawnSymbol()
    {
        Vector3 spawnPosition = new Vector3(5, m_spawnHeight, 0);
        GameObject symbol = Instantiate(m_symbols[Random.Range(0, m_symbols.Count)], spawnPosition, Quaternion.identity);
        Destroy(symbol, 5f);
    }
}

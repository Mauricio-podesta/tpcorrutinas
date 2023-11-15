using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private TextMeshProUGUI gameStartText;
    [SerializeField] private TextMeshProUGUI numbers;
    [SerializeField] private TextMeshProUGUI indicaciones;
    [SerializeField] private GameObject SpawnSquare;
    [SerializeField] private float spawnsAmount;
    [SerializeField] private float minSpawnTime = 0.3f;
    [SerializeField] private float maxSpawnTime = 0.7f;
    bool dothespawn;

    void Start()
    {
        StartCoroutine(CountdownScreen());
        dothespawn = false;
      
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(NormalSpawn(spawn, spawnsAmount));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RandomSpawn(spawn, spawnsAmount));
        }
    }

    private void SpawnObject(Transform spawner)
    {
        GameObject instantiatedObject = Instantiate(objectPrefab, spawner.position, Quaternion.identity);

        Destroy(instantiatedObject, 1.5f);
    }
    private IEnumerator NormalSpawn(Transform spawner, float spawnsAmount)
    {
        if (dothespawn == true)
        {
            for (int i = 0; i < spawnsAmount; i++)
            {
                SpawnObject(spawner);
                yield return new WaitForSeconds(0.5f);
            }
        }

    }
    private IEnumerator RandomSpawn(Transform spawner,float spawnAmoung)
    {
        for (int i = 0; i < spawnsAmount; i++)
        {
            SpawnObject(spawner);
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    } 

        private IEnumerator CountdownScreen()
    {
        SpawnSquare.SetActive(false);
        indicaciones.enabled = false;
        gameStartText.enabled = false;
        numbers.text = "3";
        yield return new WaitForSeconds(1f);
        numbers.text = "2";
        yield return new WaitForSeconds(1f);
        numbers.text = "1";
        yield return new WaitForSeconds(1f);
        numbers.text = "0";
        yield return new WaitForSeconds(1f);
        numbers.enabled = false;
        yield return new WaitForSeconds(1f);
        gameStartText.enabled = true;
        yield return new WaitForSeconds(1f);
        gameStartText.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SpawnSquare.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        dothespawn = true;
        indicaciones.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject spikePrefab;

    [Header("Points")]
    [SerializeField] private Transform[] coinSpawnPoint;
    [SerializeField] private Transform[] spikeSpawnPoint;

    private int[] coinArray = { 0, 1, 2, 3, 4, 5, 6, 7 };
    private int[] spikesArray = { 0, 1, 2, 3, 4, 5, 6, 7 };

    public static int counterCoins;
    public static int counterSpikes;
    private void Awake()
    {
        counterCoins = Random.Range(2, 6);
        counterSpikes = Random.Range(2, 5);
        RandomCoinArray();
        RandomSpikesArray();
        CreateObjects();
    }

    private void CreateObjects()
    {
        for (int i = 0; i < counterCoins; i++)
        {
            Instantiate(coinPrefab, coinSpawnPoint[coinArray[i]]);
        }
        for (int i = 0; i < counterSpikes; i++)
        {
            Instantiate(spikePrefab, spikeSpawnPoint[spikesArray[i]]);
        }
    }

    #region RandomArrays
    private void RandomCoinArray()
    {
        System.Random random = new System.Random();
        for (int i = coinArray.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = coinArray[j];
            coinArray[j] = coinArray[i];
            coinArray[i] = temp;
        }
    }
    private void RandomSpikesArray()
    {
        System.Random random = new System.Random();
        for (int i = spikesArray.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = spikesArray[j];
            spikesArray[j] = spikesArray[i];
            spikesArray[i] = temp;
        }
    }
    #endregion

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnpoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f; //  2 sec to spawn first wave

    public Text waveCountdownText;

    private float waveIndex = 1;
    void Update() {
        if (countdown <= 0f) {
            //SpawnWave(); it is IEnumerator so we can't call just like this
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime; // countdown by 1 every second

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave() { // IEnumerator that pause piece of code
        //Debug.Log("Wave Incoming!!!");
        for (int i = 0; i < waveIndex; ++i) {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);   // wait some sec
        }
        waveIndex++;
    }
    void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}

using UnityEngine;

public class Spawner : MonoBehaviour
{
    // We will need a reference to the prefab to spawn it and a value to determine how often
    // to spawn them. Some variables to change the positions of the pipes

    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // We want to be able to disable the spawner if the player looses.
    // Only want to spawn when the script is enables
    private void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawnRate, spawnRate);
    }

    // Calles automatically when an object is disabled
    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }

    private void spawn()
    { // we need to clone our prefab

        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
}

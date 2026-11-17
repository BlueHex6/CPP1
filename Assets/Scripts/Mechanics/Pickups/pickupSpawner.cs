using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class pickupSpawner : MonoBehaviour
{

    [SerializeField] private SimplePickup pickup1;
    [SerializeField] private SimplePickup pickup2;
    [SerializeField] private SimplePickup pickup3;
    private static int randomized = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SimplePickup spawned;
        if (randomized == -1)
        {
            randomized = Random.Range(0, 3);
        }
        int pickup = randomized;
        switch (pickup)
        {
            case 0:
                spawned = Instantiate(pickup1, transform.position, Quaternion.identity);
                break;
            case 1:
                spawned = Instantiate(pickup2, transform.position, Quaternion.identity);
                break;
            case 2:
                spawned = Instantiate(pickup3, transform.position, Quaternion.identity);
                break;
        }

    }
    void OnApplicationQuit()
    {
        randomized = -1;
    }
}

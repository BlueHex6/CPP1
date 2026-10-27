using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 5.0f;

    [SerializeField] private Vector2 initVelocity = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
        if(initVelocity != Vector2.zero)
        {
            setVelocity(initVelocity);
        }
    }

    // Update is called once per frame
    public void setVelocity(Vector2 velocity)
    {
        GetComponent<Rigidbody2D>().linearVelocity = velocity;
    }

    //collision detection code
}

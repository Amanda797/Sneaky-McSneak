using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Rigidbody2D Rb;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Rb.AddForce(transform.right * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.GetComponent<Health>())
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

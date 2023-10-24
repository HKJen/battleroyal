using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 25;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "deadZone") {
            Destroy(gameObject);
        }
        if (other.tag == "Enemy"){
            FindObjectOfType<Win>().OnDeath();
            Destroy(other.gameObject);
        }

        if (other.tag == "Player"){
            other.GetComponent<Health>().ChangeHealth(-20);
        }

        if (other.tag == "RedBarrel") {
            other.GetComponent<RedBarrel>().Boom();
        }
        
    }
}

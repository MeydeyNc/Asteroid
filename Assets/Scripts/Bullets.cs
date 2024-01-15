
using UnityEngine;

public class Bullets : MonoBehaviour
{
    //vitesse du projectile
    public float speed = 500.0f;
    //vie du projectile, il ne peut pas se déplacer éternellement
    public float maxlifetime = 0.1f;
    //on fait comprendre que ça va être un objet tangible
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //On ajoute de la puissance avec la vitesse pour projeter les projectiles
    //On rajoute le lifetime de l'objet projectile pour éviter son existence éternelle.
    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxlifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

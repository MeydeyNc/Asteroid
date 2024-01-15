
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //on a plusieurs sprites différents pour les Asteroids on va donc en faire un array pour du random
    public Sprite[] sprites;

    //on va changer aléatoirement la taille des astéroids pour leurs donner un aspect original
    public float size = 1.0f;

    public float minsize = 0.5f;

    public float maxsize = 1.5f;

    public float speed = 50.0f; //vitesse des kayoux

    public float maxLifetime = 30.0f;

    private SpriteRenderer _spriterenderer;

    private Rigidbody2D _rigibody;


    private void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriterenderer.sprite = sprites[Random.Range(0, sprites.Length)]; //c'est ici qu'on fait du random dans le choix des sprites

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f); //On va aussi changer l'orientation de l'asteroid 

        this.transform.localScale = Vector3.one * this.size;

        _rigibody.mass = this.size ; //on implémente aussi la masse qui va changer en fonction de la taille des sprites
    }

    //on donne aussi aux asteroids comme les projectiles un lifetime pour éviter qu'ils perdurent dans le temps.
    public void SetTrajectory(Vector3 direction)
    {
        _rigibody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision) // On check la collision puis on détermine sa taille 
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((this.size * 0.5f) >= this.minsize) // si la taille est plus grande que 0.5f alors on crée des kayoux de taille <= à 0.5
            {
                CreateSplit(); // on fait spawn 2 kayoux
                CreateSplit();
            }

            Destroy(this.gameObject); // dans tous les autres cas on détruit
        }
    }

    private void CreateSplit() 
    { 
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f; // on fait spawn dans un rayon random, mais proche autour de l'ancien asteroid

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed); // ici on lui donne sa taille finale et sa direction
    }
}

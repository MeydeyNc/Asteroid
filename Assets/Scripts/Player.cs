
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullets bulletPrefab;

    public float vitesseAccel = 1.0f;
    public float vitessePivot = 1.0f;
    //r�f�rence au rigidbody qui va nous servir de hitbox
    private Rigidbody2D _rigidbody;
    //Un bool pour savoir si on avance ou pas
    private bool _accel;
    //Un float pour tourner, on va ajuste comme dans le jeu og petit � petit la direction dans laquelle on va pousser/acc�l�rer
    private float _pivot;

    //sera appell�e une fois en tant qu'initialisation
    //va chercher le component qui est store avec notre objet
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //Ici on dit : Z ou UpArrow = �a pousse
    //Et on intervient avec des conditions pour ajuster les floats si on touche � Q ou D
    //Si on y touche pas �videmment on tourne pas
    private void Update()
    {
        _accel = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            _pivot = 1.0f; // de fa�on intuitive on aurait dit ici en negatif mais on va le faire tourner de fa�on diff�rente

        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _pivot = -1.0f;
        } else { 
            _pivot = 0.0f; 
        }

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        //{
        //    Shoot();
        //}
    }

    // sera toujours appel�e de fa�on fixe en terme de temporalit�
    //on utilise la fonction addforce qui permet de faire avancer notre player, up pour un jeu en 2D et Forward pour de la 3D
    private void FixedUpdate()
    {
        if ( _accel )
        {
            _rigidbody.AddForce(this.transform.up * this.vitesseAccel );
        }

        if ( _pivot != 0.0f )
        {
            _rigidbody.AddTorque( _pivot * this.vitessePivot);
        }
    }

    //private void Shoot()
    //{
    //    Bullets bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
    //    bullet.Project(this.transform.up);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();

        }
    }
}

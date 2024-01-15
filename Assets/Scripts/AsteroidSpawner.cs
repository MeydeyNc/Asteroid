
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public float trajectoryVariance = 15.0f; //On set un cone dans lequel les kayoux vont être envoyés

    public float spawnRate = 2.0f; //la vitesse de spawn des kayoux

    public int spawnAmount = 1;

    public float spawnDistance = 15.0f; //on set un spawn qui va faire apparaître les kayoux dans un rayon

    private void Start() //On lance le spawning à rythme régulier 
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {

            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection; //Ici on choisit la direction et la position des spawns de kayoux

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); // La on retourne les sprites de temps en temps

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);

            asteroid.size = Random.Range(asteroid.minsize, asteroid.maxsize); // La on gère leur taille
            asteroid.SetTrajectory(rotation * -spawnDirection); // Ici l'angle d'arrivée des kayoux
        }

    }
}

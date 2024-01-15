
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameOverScreen gameOverScreen;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabiltyTime = 5.0f;

    public void PlayerDied()
    {
        this.lives--;

        if (this.lives <= 0 )
        {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    public void Respawn()
    {

        this.player.transform.position = Vector3.zero;
        //this.player.gameObject.layer = LayerMask.NameToLayer("IngoreCollisions");
        this.player.gameObject.SetActive(true);
        
        //Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabiltyTime);
    }

    //private void TurnOnCollisions()
    //{
    //    this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    //}

    private void Menu()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Menu");
    }
    private void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScreen");

        //this.lives = 3;

        //Invoke(nameof(Respawn), this.respawnTime);
    }
}

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameHud GameHud;
    public GameHud GetGameHud(){ return GameHud;}
    [SerializeField] private GameObject Player;
    [SerializeField] private Ground Ground;
    [SerializeField] private GameObject Restart;
    public GameObject RestartButton() {return Restart;}

    //Enemies
    [SerializeField] private GameObject[] Enemies;

    private PlayerContoller PlayerController;

    [SerializeField, Range(3f, 7f)] private float MinSpawnPeriod;
    [SerializeField, Range(7f, 10f)] private float MaxSpawnPeriod;

    private Border Border;

    public void Awake()
    {
        if (GameHud.gameObject.activeSelf)
            GameHud.ShowHud(false);

    }

    public void StartGame(Button startButton)
    {
        startButton.gameObject.SetActive(false);
        GameHud.ShowHud(true);
        Ground.gameObject.SetActive(true);

        Instantiate(Player, Ground.Position, Quaternion.identity);
        PlayerController = FindObjectOfType<PlayerContoller>();
        StartCoroutine(SpawnEnemies());
    }

    public void RestartGame(Button restartButton)
    {
        StartGame(restartButton);
    }

    private IEnumerator SpawnEnemies()
    {
        while (PlayerController != null)
        {
            float NextSpawnPeriod = Random.Range(MinSpawnPeriod, MaxSpawnPeriod);
            int EnemyNumber = Random.Range(0, Enemies.Length);
            Vector3 RandPos = PlayerController.GetBorder().GetRandomPosition();

            yield return new WaitForSeconds(NextSpawnPeriod);

            if (PlayerController != null){
            GameObject Enemy = Instantiate(Enemies[EnemyNumber], RandPos, Quaternion.identity);

            Enemy.GetComponent<Enemy>().SetSpeedByScore(PlayerController.Score.GetScore());
            }
            else
            {
                break;
            }
        }
    }
}

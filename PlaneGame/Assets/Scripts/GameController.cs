using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Atributos para contagem de tempo da criação dos obstáculos
    [SerializeField] private float obstacleTimer = 1f;  
    private float timeMax = 2f;
    private float timeMin = 1f;

    //Atributos para posicionamento dos obstáculos na tela
    [SerializeField] private GameObject obstacle;
    private Vector3 obstaclePosition;
    private float posMax = 3.8f;
    private float posMin = 0.94f;

    //Atributos referentes ao level
    public PlayerController playerPlane;
    private int level = 1;
    private float xp = 5;
    [SerializeField] private Text levelText;
    [SerializeField] AudioClip levelUpSong;
    private Vector3 camPos;
    

    // Start is called before the first frame update
    void Start()
    {
        obstaclePosition.x = 8.5f;
        camPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CreateObstacle();
        NextLevel();
    }

    //Cria obstaculos na tela com variações de tempo e posição aleatórias
    private void CreateObstacle()
    {
        obstaclePosition.y = Random.Range(posMin, posMax);

        //Contando tempo
        obstacleTimer -= Time.deltaTime;
        if (obstacleTimer <= 0)
        {
            obstacleTimer = Random.Range(timeMin / level, timeMax - (level/5));
            //Criando obstaculos
            Instantiate(obstacle, obstaclePosition, Quaternion.identity);
        }
    }

    //Verifica se o jogador atingiu a quantidade necessária de pontos para o próximo level
    private void NextLevel()
    {
        if(playerPlane.getPoints() > xp)
        {
            level++;          
            xp *= 2;
            AudioSource.PlayClipAtPoint(levelUpSong, transform.position);
        }
        levelText.text = level.ToString();

        
    }
    
    public int getLevel()
    {
        return level;
    }

}

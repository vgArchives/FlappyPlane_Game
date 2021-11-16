using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    //Atributos referentes ao obstáculo
    [SerializeField] private float obstacleVelocity;
    [SerializeField] private GameObject obstacle;

    //Atributo para acessar o GameController
    [SerializeField] private GameController gameController;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(obstacle,5f);

        //Encontrando o game controller da cena atual
        gameController = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * obstacleVelocity;

        //Ajustando velocidade
        obstacleVelocity = 4f + gameController.getLevel();
    }
}

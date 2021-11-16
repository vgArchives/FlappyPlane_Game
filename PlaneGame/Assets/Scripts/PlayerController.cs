using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    //Atributes
    private Rigidbody2D planeRB;
    [SerializeField] private float velocity = 5f;

    //Atributos para o sistema de pontos
    [SerializeField] private Text pointsText;
    private float points = 0;

    //Atributos para pegar o objeto puff
    [SerializeField] private GameObject puffAnimation;

    // Start is called before the first frame update
    void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitarQueda();
        Subir();
    }

    private void LimitarQueda()
    {
        //Limitando a velocidade de queda
        if (planeRB.velocity.y < -velocity) planeRB.velocity = Vector2.down * velocity;
    }

    private void Subir()
    {
        //Subindo o avi�o ao apertar espa�o
        if (Input.GetKeyDown(KeyCode.Space))
        {
            planeRB.velocity = Vector2.up * velocity;

            //Inst�ncia uma anima��o do puff no local onde o player est�
            GameObject puff = Instantiate(puffAnimation, transform.position, Quaternion.identity);

            //Destroi o objeto puff ap�s finalizar a anima��o
            Destroy(puff, 1f);
        }
    }

    //Reiniciar cena ap�s uma colis�o
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(0);
    }

    //Aumentar os pontos a cada obst�culo passado
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        points++;
        pointsText.text = Mathf.Round(points).ToString();
    }
    
    //Getter para pegar os pontos do player
    public float getPoints()
    {
        return points;
    }
}

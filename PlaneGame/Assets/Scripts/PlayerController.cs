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
        //Subindo o avião ao apertar espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            planeRB.velocity = Vector2.up * velocity;

            //Instância uma animação do puff no local onde o player está
            GameObject puff = Instantiate(puffAnimation, transform.position, Quaternion.identity);

            //Destroi o objeto puff após finalizar a animação
            Destroy(puff, 1f);
        }
    }

    //Reiniciar cena após uma colisão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(0);
    }

    //Aumentar os pontos a cada obstáculo passado
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

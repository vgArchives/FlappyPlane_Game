using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    private MeshRenderer backMaterial;

    //Posição do x offset
    private float posXOffset = 0;

    //Posição em vetor da main texture
    private Vector2 vectorTextureOffset;

    //Velocidade de movimento do fundo
    private float backVelocity = 0.2f;

    //Game controller para acessar o level
    [SerializeField] private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //identificando meu componente e passando para variável
        backMaterial = GetComponent<MeshRenderer>();
    }
  
    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        backVelocity += gameController.getLevel() / 10;
        
        //Aumentando o valor do x offset do material
        posXOffset += Time.deltaTime * backVelocity;

        //Passando o valor da variavel para o vetor
        vectorTextureOffset.x = posXOffset;

        //Movendo o x offset do meu objeto (Mesh Renderer)
        backMaterial.material.mainTextureOffset = vectorTextureOffset;
    }
}

using UnityEngine;

public class BackGroudController : MonoBehaviour
{
    //Pegando o material do fundo do backgroud
    private Renderer meuFundo;

    //posicao do x offset
    private float xOffset = 0f;

    //posicao da minha textura
    private Vector2 texturaOffset;

    //velocidade movimento da tela
    private float speed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuFundo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //diminuido vaor xoffset
        xOffset += Time.deltaTime * speed;

        //x Offset para o eixo da textura
        texturaOffset.x = xOffset;

        meuFundo.material.mainTextureOffset = texturaOffset;
    }
}

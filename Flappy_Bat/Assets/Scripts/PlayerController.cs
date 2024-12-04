using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe respons�vel pelo controle do jogador, derivada de MonoBehaviour
public class PlayerController : MonoBehaviour
{
    // Refer�ncia ao componente Rigidbody2D do jogador
    private Rigidbody2D rb;

    // Velocidade do jogador (valor configur�vel no Inspector)
    [SerializeField] private float speed = 5f;

    //Varivel para receber a fuma�a
    [SerializeField] private GameObject puff;

    // M�todo chamado uma vez no in�cio, antes da primeira execu��o de Update
    void Start()
    {
        // Obt�m a refer�ncia ao componente Rigidbody2D anexado ao GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // M�todo chamado uma vez por frame
    void Update()
    {
        subirPlayer();
        quedaPlayer();
        GameOver();
    }

    private void quedaPlayer()
    {
        // Limita a velocidade de queda do jogador
        if (rb.linearVelocity.y < -speed)
        {
            // Define a velocidade m�xima de queda como o valor da vari�vel speed
            rb.linearVelocity = Vector2.down * speed;
        }
    }

    private void subirPlayer()
    {
        // Verifica se a tecla "Espa�o" foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica uma velocidade para cima no Rigidbody2D
            rb.linearVelocity = Vector2.up * speed;

            // Instancia o puff atr�s do GameObject
            Vector3 puffPosition = transform.position;
            // Ajuste para garantir que fique atr�s
            puffPosition.x = transform.position.x -4; 
            
            //Cria o puff e o instanceia �para poder removelo da cena
            GameObject meuPuff =
            Instantiate(puff, puffPosition, Quaternion.identity);
            // Substitua "1.0f" pelo tempo da anima��o
            Destroy(meuPuff, 0.8f); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0);//Pode ser utilizado nome da Cena
    }

    private void GameOver()
    {

        if (transform.position.y <= -7f  )
        {
            SceneManager.LoadScene(0);//Pode ser utilizado nome da Cena
        }
    }
}

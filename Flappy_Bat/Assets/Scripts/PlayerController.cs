using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe responsável pelo controle do jogador, derivada de MonoBehaviour
public class PlayerController : MonoBehaviour
{
    // Referência ao componente Rigidbody2D do jogador
    private Rigidbody2D rb;

    // Velocidade do jogador (valor configurável no Inspector)
    [SerializeField] private float speed = 5f;

    //Varivel para receber a fumaça
    [SerializeField] private GameObject puff;

    // Método chamado uma vez no início, antes da primeira execução de Update
    void Start()
    {
        // Obtém a referência ao componente Rigidbody2D anexado ao GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Método chamado uma vez por frame
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
            // Define a velocidade máxima de queda como o valor da variável speed
            rb.linearVelocity = Vector2.down * speed;
        }
    }

    private void subirPlayer()
    {
        // Verifica se a tecla "Espaço" foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica uma velocidade para cima no Rigidbody2D
            rb.linearVelocity = Vector2.up * speed;

            // Instancia o puff atrás do GameObject
            Vector3 puffPosition = transform.position;
            // Ajuste para garantir que fique atrás
            puffPosition.x = transform.position.x -4; 
            
            //Cria o puff e o instanceia ´para poder removelo da cena
            GameObject meuPuff =
            Instantiate(puff, puffPosition, Quaternion.identity);
            // Substitua "1.0f" pelo tempo da animação
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

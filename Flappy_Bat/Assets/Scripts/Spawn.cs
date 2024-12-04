using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Spawn : MonoBehaviour
{
    //Movimento Variaveis 
    [SerializeField] private float maximoY = -0.1f;
    [SerializeField] private float minimoY = -3.74f;

    //Spawnar
    public GameObject objectToSpawn; // Objeto a ser spawnado
    public float spawnInterval = 1.5f; // Intervalo entre cada spawn
    [SerializeField]private Vector3 spawnPosition = new Vector3(14,-2,0);
    private float timer; // Contador para controlar o intervalo de spawn

    //Pontuação
    private float pontos = 0f;
    public TextMeshProUGUI texto;

    //level
    public int level = 1;
    private float proximoLevel = 10f;

    //Trocar o plano de Fundo a cada level 
    public GameObject background; // Referência ao GameObject do fundo
    public Material[] levelMaterials; // Array de materiais para cada nível
    public AudioClip[] musicaAudio;
    public AudioSource audioSource;

    void Start()
    {
        timer = spawnInterval; // Inicializa o timer com o intervalo de spawn
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = musicaAudio[2];
        audioSource.Play();
    }

    void Update()
    {
        timer -= Time.deltaTime; // Reduz o contador com base no tempo decorrido

        if (timer <= 0)
        {
            SpawnObject(); // Chama a função para spawnar o objeto
            timer = spawnInterval; // Reinicia o timer
        }

        sistemaPontos();
        GanhaLevel();
    }

    void SpawnObject()
    {
        spawnPosition.y = Random.Range(minimoY, maximoY);   
        // Cria o objeto na posição aleatória relativa à posição do Spawn
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    // Gizmos para visualizar a área de spawn no editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(transform.position, spawnArea);
        // Desenha um cubo na posição do objeto atual (apenas no editor)
        Gizmos.DrawWireCube(transform.position, spawnPosition);
    }

    private void sistemaPontos()
    {
        pontos += Time.deltaTime;
        texto.text = $"Score: {Mathf.Round(pontos)} " +
            $"\n Level: {level}";

    }

    public int GanhaLevel()
    {
        if (pontos >= proximoLevel)
        {
            level++;//aumenta o level
            proximoLevel *= 2f;//dobra pra trocar de level
            TrocaBackground();
        }

        return level;

    }


    private void TrocaBackground() {

        if (levelMaterials.Length > (level - 1))
        {
            Renderer renderer = background.GetComponent<Renderer>();
           
            if (renderer != null)
            {
                renderer.material = levelMaterials[level - 1];



                if (level <= 2)
                {
                    audioSource.clip = musicaAudio[0];
                    audioSource.Play();
                }

                if(level >= 3)
                {
                    audioSource.clip = musicaAudio[1];
                    audioSource.Play();

                }

            }
        }   
    }
}

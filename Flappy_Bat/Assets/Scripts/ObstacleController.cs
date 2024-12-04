using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject obstacle;

    [SerializeField] private Spawn spawnLevel;


    void Start()
    {
        spawnLevel = FindFirstObjectByType<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

        //Aumenta velocidade de acordo com nivel
        speed = 5f + spawnLevel.GanhaLevel();

        if(transform.position.x < -12f)
        {

            Destroy(obstacle);
        }


    }
}

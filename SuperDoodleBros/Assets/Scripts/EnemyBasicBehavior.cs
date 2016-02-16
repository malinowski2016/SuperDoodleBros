using UnityEngine;
using System.Collections;

public class EnemyBasicBehavior : MonoBehaviour
{

    //private bool dirRight = true;
    private Vector3 initialPos;

    public int maxHealth = 30;
    public int currentHealth;
    public float speed = 0.1f;
    public float range = 10f;

    public int attackDamage = 20;

    private Vector3 pos1;
    private Vector3 pos2;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        initialPos = transform.position;
        pos1 = initialPos - new Vector3(range, 0, 0);
        pos2 = initialPos + new Vector3(range, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(initialPos.x + Mathf.PingPong(speed * Time.time, range), initialPos.y, 0f);
        transform.position = pos;

        /*
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= (initialPos.x + range))
        {
            dirRight = false;
        }

        if (transform.position.x <= (initialPos.x - range))
        {
            dirRight = true;
        }
        */
    }
}
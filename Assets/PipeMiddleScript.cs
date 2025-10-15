using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private LogicManagerScript logic;
    private BEANScript beanScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        beanScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BEANScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && beanScript != null && beanScript.isAlive)
        {
            logic.addScore(1);
            if (logic.PlayerScore >= 1)
            {
                logic.win();
            }
        }
    }
}

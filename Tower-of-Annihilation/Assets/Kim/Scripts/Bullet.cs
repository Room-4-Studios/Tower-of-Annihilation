using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    public GameObject mgmt;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        mgmt = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mgmt.GetComponent<PlayerManager>().TakeDamage(4);
            Destroy();
        }
    }
}

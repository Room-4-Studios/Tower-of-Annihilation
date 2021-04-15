using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;
    private float angle2 = 0f; //angle for pattern 2
    private float angle3 = 0f; //angle for pattern 3

    private Vector2 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire1", 0f, 0.2f); //Fire every 0.2 seconds.
        InvokeRepeating("Fire2", 0f, 0.01f);
        InvokeRepeating("Fire3", 0f, 0.05f);
    }

    private void Fire1() //Pattern 1, straight lines.
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i=0; i<bulletAmount+1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle*Mathf.PI)/180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetDirection(bulDir);

            angle += angleStep;
        }
    }

    private void Fire2() //Pattern 2, spiral pattern.
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle2 * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle2 * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetDirection(bulDir);

        angle2 += 10f;       
    }

    private void Fire3() //Pattern 3, double spiral.
    {

        for (int i = 0; i <=1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle3 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle3 * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetDirection(bulDir);
        }
        angle3 += 10f;
        if (angle3 >= 360f)
        {
            angle3 = 0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

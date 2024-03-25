using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePoint;
    public float NumberBullet=0;
    public Sprite HasBullet;
    public Sprite NoBullet;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RedCircle"))
        {
            NumberBullet++;
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().sprite = HasBullet;
        }
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if(NumberBullet > 0)
            {
                ShootBullet(direction);
                NumberBullet--;
                if(NumberBullet == 0)
                {
                    GetComponent<SpriteRenderer>().sprite = NoBullet;
                }
            }
        }
    }
    void ShootBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(Bullet, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet.GetComponent<Bullet>().bulletSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Tutorial : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public float damage;
    public float nextFire;
    public float fireRate;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
            ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.up))
        {
            RaycastHit2D other = Physics2D.Raycast(laserFirePoint.position, transform.up);      //change m_transform.right to m_transform.forward if having issues aiming


            if (other.collider != null)
            {
                //hit
                if (other.collider.tag == "Enemy")
                {
                    if (Time.time > nextFire)// if i can shoot (based on FireRate)
                    {
                        nextFire = Time.time + fireRate; // defining FireRate
                        {// i will shoot
                            other.collider.GetComponent<PlayerHealth>().UpdateHealth(-damage);
                        }
                    }
                    Draw2DRay(laserFirePoint.position, other.point);
                }

            }
            Draw2DRay(laserFirePoint.position, other.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.up * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}

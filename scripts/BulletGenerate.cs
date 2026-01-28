using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

 //   public characterMovement characterMovement;
    public float shootspeed;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    ganerateBullate();
        //}
    }
    public void ganerateBullate()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        print("bullet position : "+bullet.transform.position);
        print("firePoint forward : " + firePoint.forward);
        var forwardpos = firePoint.forward;
        rb.AddForce(forwardpos * (shootspeed * 100));
        Destroy(bullet, 2);
    }
}

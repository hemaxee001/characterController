using UnityEngine;

public class BulletGenerateSec : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera PlayerCamera;
    //   public characterMovement characterMovement;
    public float shootspeed;
    public float aimDistance ;
    

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
        //  Get camera center aim
        Ray ray = new Ray(
            PlayerCamera.transform.position,
            PlayerCamera.transform.forward
        );
        print("position: " + PlayerCamera.transform.position);
        print("forward : " + PlayerCamera.transform.forward);

        Vector3 targetPoint;

        print("aimDistance : " + aimDistance);


        if (Physics.Raycast(ray, out RaycastHit hit, aimDistance))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(aimDistance);

        // Shoot from gun to aim point
        Vector3 shootDir =
            (targetPoint - firePoint.position).normalized;

        if (Vector3.Dot(shootDir, firePoint.forward) < 0f)
        {
            shootDir = firePoint.forward; // force forward shot
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.LookRotation(shootDir)
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = shootDir * shootspeed;

        Destroy(bullet, 2f);
        // // var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
        // var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        // Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // //print("bullet position : " + bullet.transform.position);
        // //print("firePoint forward : " + firePoint.forward);

        // // var forwardpos = firePoint.forward;
        //// rb.AddForce(forwardpos * (shootspeed * 100));

        //Vector3 ShootDir = PlayerCamera.transform.forward;
        // rb.linearVelocity = ShootDir * shootspeed;
        // Destroy(bullet, 2f);
    }
}

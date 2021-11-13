using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f; // Fire 1 Bullet in each second
    private float firecountDown = 0f; // In header it is private so it is not shown at unity , bcoz we cann't change it 

    [Header("Unity Set Up Fields")]
    public string enemytag = "Enemy";
    public Transform partToRotate;
    public float turnspeed = 10f;

    public GameObject bulletPrefab;
    public Transform firepoint; // point at which we want to spawn a bullet

    
    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);    
    }
    void UpdateTarget() {
        // start -> we can find shortest dis enemy = here it is nearestenemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);

        float shortestdistance = Mathf.Infinity;
        GameObject nearestenemy = null;

        foreach (GameObject enemy in enemies) {

            float distoenemy = Vector3.Distance(transform.position,enemy.transform.position);

            if (shortestdistance > distoenemy) {
                shortestdistance = distoenemy;
                nearestenemy = enemy;
            }
        }

        if (nearestenemy != null && shortestdistance <= range) // shortestdis is over range
        {
            target = nearestenemy.transform;
        }
        else {
            target = null; 
        }
        //->end

    }
    void Update() {

        //start this is for moving turret
        if (target == null)
            return;
        //transform.pos // jeni andar script nakhi 6 teni pos

        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //Vector3 rotation = lookRotation.eulerAngles;
        // here we are not getting smoothly gun

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        //end this is for moving turret

        if (firecountDown <= 0f) {
            shoot();
            firecountDown = 1f / fireRate;
        }
        firecountDown -= Time.deltaTime;
    }

    void shoot() {
        //Debug.Log("Shoot");
        GameObject GO = (GameObject)( Instantiate(bulletPrefab, firepoint.position , firepoint.rotation));
        Bullet obj = GO.GetComponent<Bullet>(); // Go return reference of bulletprefeb - (bullet)

        if (obj != null) {
            obj.seek(target);
        }
             
    }
    
    //gizmos display th a range of our turret
    void OnDrawGizmosSelected() {
        //Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,range);
    }
     
}

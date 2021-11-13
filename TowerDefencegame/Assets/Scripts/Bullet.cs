using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform target;
    public float speed=70f;
    public GameObject impacteffect;

    public float explosionrad = 0f;
    public void seek(Transform _target) {
        target = _target;
    }

    void Update() {
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float disthisframe = speed * Time.deltaTime;

        if(dir.magnitude <= disthisframe) {
            Hittarget();
            return;
        }

        transform.Translate(dir.normalized * disthisframe , Space.World);
        transform.LookAt(target);
    }

    void Hittarget() {

        GameObject effectinstance= (GameObject)Instantiate(impacteffect,transform.position,transform.rotation);
        Destroy(effectinstance,1.5f);
        if (explosionrad > 0f) {
            Explode();
        }
        else {
            damage(target);
        }
        Destroy(target.gameObject);
        Destroy(gameObject);
        //Debug.Log("We Hit Enemy");
    }
    void Explode() {
        Collider[] c = Physics.OverlapSphere(transform.position,explosionrad);
        foreach(Collider collider in c) {
            if (collider.tag == "Enemy") {
                damage(collider.transform);
            }
        }
    }
    void damage(Transform enemy) {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionrad);
    }
}

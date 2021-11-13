using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool validmovement = true;
    public float panspeed = 35f;
    public float panborderthickness = 10f;
    public float spped = 5f;
    public float miny = 10f;
    public float maxy = 50f;
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            validmovement = !validmovement;
        }

        if (!validmovement)
            return;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panborderthickness) {
            transform.Translate(Vector3.forward * panspeed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panborderthickness) {
            transform.Translate(Vector3.back * panspeed * Time.deltaTime);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panborderthickness) {
            transform.Translate(Vector3.right * panspeed * Time.deltaTime);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panborderthickness) {
            transform.Translate(Vector3.left * panspeed * Time.deltaTime);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);

        Vector3 pos = transform.position;
        pos.y -= (scroll) * 1000 * spped * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y,miny,maxy);
        transform.position = pos;
    }
    
}

using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {
    public Color hovercolor;
    Color startcolor;
    private Renderer rand;

    private GameObject turret;

    BuildManager buildManager;

    void Start() {
        rand = GetComponent<Renderer>();
        startcolor = rand.material.color;

        buildManager = BuildManager.ins;  
    }
  
    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (buildManager.GetTurretToBuild() == null) {
            return;
        }
        if (turret != null) {
            Debug.Log("Can't Build there");
            return;
        }
        //Build Turret
        //GameObject turrettoBuild = BuildManager.ins.GetTurretToBuild();
        GameObject turrettoBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turrettoBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (buildManager.GetTurretToBuild() == null) {
            return;
        }
        rand.material.color = hovercolor;
    }

    void OnMouseExit() {
        rand.material.color = startcolor;
    }
}

using UnityEngine;

public class TestEventFunction : MonoBehaviour
{
    void Awake() { print("Awake: " + Time.deltaTime + ", " + gameObject.name); }
    void Start() { print("Start: " + Time.deltaTime + ", " + gameObject.name); }
    void FixedUpdate() { print("FixedUpdate: " + Time.deltaTime + ", " + gameObject.name); }
    void Update() { print("Update: " + Time.deltaTime + ", " + gameObject.name); }
    void LateUpdate() { print("LateUpdate: " + Time.deltaTime + ", " + gameObject.name); }
    void OnEnable() { print("OnEnable: " + Time.deltaTime + ", " + gameObject.name); }
    void OnDisable() { print("OnDisable: " + Time.deltaTime + ", " + gameObject.name); }

}

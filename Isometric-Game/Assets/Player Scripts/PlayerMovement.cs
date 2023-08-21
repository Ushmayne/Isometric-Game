using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    private Vector3 input;
    private float speed = 5;
    private float turnSpeed = 360;
    public int playerMaxHealth = 100;
    public int playerMaxMana = 100;
    public int playerCurrentHealth;
    public int playerCurrentMana;
    public PlayerHealth phb;
    public PlayerAbility pab;

    void Start(){
        playerCurrentHealth = playerMaxHealth;
        phb.setHealth(playerCurrentHealth);
        playerCurrentMana = playerMaxMana;
        pab.setMana(playerMaxMana);
    }

    void Update(){
        GatherInput();
        Look();
    }

     private void FixedUpdate() {
        Move();
    }
    // Start is called before the first frame update
    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));

        
        
    }

    void Look(){
        if (input == Vector3.zero) {
            return;
        }

        var rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        
    }

    void Move(){
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);
    }

    void healthUpdate(int damage){

        playerCurrentHealth -= damage;
        phb.setHealth(playerCurrentHealth);

    }

    void maxHP(){
        playerCurrentHealth = playerMaxHealth;
        phb.setHealth(playerCurrentHealth);
    }
}

public static class Helpers 
{
    private static Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => isoMatrix.MultiplyPoint3x4(input);
}



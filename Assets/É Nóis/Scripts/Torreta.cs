using UnityEngine;

public class Torreta : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    private bool atirar = false;
    private bool mirar = false;
    private float fireCooldown = 1;
    private float fireTimer = 0f;

    Vector2 moveDirection;
    private Transform playerPosition;

    // Update is called once per frame
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            playerPosition = playerObj.transform;
        else
            playerPosition = null;
    }
    void Update()
    {
        if(playerPosition == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                playerPosition = playerObj.transform;
            else
                return;
        }
        if (atirar == true)
        {
            fireTimer += Time.deltaTime;
            if(fireTimer >= fireCooldown)
            {
                weapon.Fire();
                fireTimer = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                atirar = true;
                mirar = true;
            }
        }

    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y);
        if (mirar)
        {
            if(playerPosition == null)
            {
                GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                if (playerObj != null)
                {
                    playerPosition = playerObj.transform;
                }
                else return;
            }

            Vector2 aimDirection = (Vector2)playerPosition.position - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
    }
}

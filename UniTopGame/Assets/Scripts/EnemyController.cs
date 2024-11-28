using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 3;
    public float speed = 0.5f;
    public float reactionDistance = 4.0f;
    float axisH;
    float axisV;
    Rigidbody2D rbody;
    Animator animator;
    bool isActive = false;
    public int arrangeId = 0;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        axisH = 0;
        axisV = 0;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < reactionDistance)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
            animator.SetBool("IsActive", isActive);
            if (isActive)
            {
                animator.SetBool("IsActive", isActive);
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float rad = Mathf.Atan2(dy, dx);
                float angle = rad* Mathf.Rad2Deg;
                int direction;
                if (angle > -45.0f && angle <= 45.0f)
                {
                    direction = 3;
                }
                else if (angle > 45.0f && angle <= 135.0f)
                {
                    direction = 2;
                }
                else if (angle > -135.0f && angle < -45.0f)
                {
                    direction = 0;
                }
                else
                {
                    direction = 1;
                }
                animator.SetInteger("Direction",direction);
                axisH = Mathf.Cos(rad)*speed;
                axisV = Mathf.Sin(rad)*speed;
            }          
        }
        else
        {
            isActive = false;
        }
    }

    void FixedUpdate()
    {
        if (isActive && hp>0)
        {
            rbody.velocity = new Vector2(axisH,axisV).normalized;
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;
            if (hp <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                rbody.velocity = Vector2.zero;
                animator.SetBool("IsDead",true);
                Destroy(gameObject, 0.5f);
                SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected float flyingDownSpeed;
    [SerializeField] protected float flyingHorizSpeed;
    [SerializeField] protected float hoveringHeightCoef = 0.5f;

    protected GameObject player;

    private Coroutine routineFollow;
    private Coroutine routineHover;
    private Coroutine routineAim;

    [SerializeField] protected GameObject bullerPrefab;
    [SerializeField] protected float shootInterval;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }

    public void getDamage(int damage)
    {
        this.hp -= damage;
        if(hp<=0)
        {
            onDie();
        }
    }
    protected void onDie()
    {
        Destroy(gameObject);
    }
    protected virtual void follow()
    {
        routineFollow = StartCoroutine(following(player));
    }
    protected virtual void stopFollow()
    {
        StopCoroutine(routineFollow);
    }
    private IEnumerator following(GameObject gameObject)
    {
        while (true)
        {
            Vector2 dir = (gameObject.transform.position - transform.position).normalized;
            dir.y *= flyingDownSpeed;
            dir.x *= flyingHorizSpeed;
            transform.Translate(dir);
            yield return new WaitForFixedUpdate();
        }
    }

    protected virtual void goToStage(Vector3 endPos)
    {
        StartCoroutine(goingOnStage(endPos));
    }
    protected virtual IEnumerator goingOnStage(Vector3 endPos)
    {
        while (transform.position.y - endPos.y>=0.2f)
        {
            transform.position = (Vector2.Lerp(transform.position, endPos, 0.1f));
            yield return new WaitForFixedUpdate();
        }
        
    }
    protected void hover()
    {
        routineHover = StartCoroutine(hovering());
    }
    protected void stopHover()
    {
        StopCoroutine(routineHover);
    }
    private IEnumerator hovering()
    {
        bool isLeftDir = true;
        float xMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float xMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;

        float currentFlyingHorizSpeed = 0f;

        while (true)
        {
            if(currentFlyingHorizSpeed <=  flyingHorizSpeed)
            {
                Debug.Log(currentFlyingHorizSpeed);
                currentFlyingHorizSpeed += 0.005f;
            }

            if (isLeftDir == true)
            {
                if (transform.position.x <= xMin)
                {
                    isLeftDir = false;
                }
                float newX = (transform.position.x - currentFlyingHorizSpeed) ;
                transform.position = new Vector2( newX, Mathf.Sin(newX) * hoveringHeightCoef);
            }
            else
            {
                if (transform.position.x >= xMax)
                {
                    isLeftDir = true;
                }
                float newX = (transform.position.x + currentFlyingHorizSpeed) ;
                transform.position = new Vector2(newX, Mathf.Sin(newX) * hoveringHeightCoef);
               
            }


            yield return new WaitForFixedUpdate();
        }
    }

    protected  void shoot()
    {
        Instantiate(bullerPrefab,transform.position,Quaternion.identity);
    }
    protected void aim()
    {
        routineAim = StartCoroutine(aiming(player));
    }
    protected void stopAim()
    {
        StopCoroutine(routineAim);
    }
    private IEnumerator aiming(GameObject gameObject)
    {
        while (true)
        {
            Vector2 shootHole = transform.position;
            shootHole.y -= transform.localScale.y;
            RaycastHit2D hit = Physics2D.Raycast(shootHole, -Vector2.up);
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == gameObject.tag)
            {
                shoot();
                yield return new WaitForSeconds(shootInterval);
            }
            yield return new WaitForFixedUpdate();
        }

    }
}

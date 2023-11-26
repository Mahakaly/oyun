using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using DG.Tweening.Core.Easing;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform player1;

    [SerializeField] private Transform magePl;

    private int characterCount;

    [SerializeField] private GameObject gunner;
    [SerializeField] private GameObject Mage;
    [SerializeField] private GameObject bomber;

    

    [SerializeField] TMP_Text gateText;

    private GameManager gameManager;

    //***********************************

    [Range(0f, 1f)] [SerializeField] private float DistanceFactor, Radius;

    public bool moveByTouch, gameState;

    private Vector3 mouseStartPos,playerStartPos;

    public float playerSpeed,roadSpeed;

    private Camera cam;

    public bool roadMoving = true;

    [SerializeField] private Transform road;

    // Start is called before the first frame update
    void Start()
    {
        player1 = transform;

        characterCount = transform.childCount - 1;

        cam = Camera.main;

   
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        
            
        MoveTheRoad();

    }
    void MoveThePlayer()
    {
        if(Input.GetMouseButtonDown(0)&& !gameState)
        {
            moveByTouch= true;

            var plane = new Plane(Vector3.up, 0f);

            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if(plane.Raycast(ray,out var distance))
            {
                mouseStartPos = ray.GetPoint(distance + 1f);

                playerStartPos = transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;
        }

        if(moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);

            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if(plane.Raycast(ray,out var distance))
            {

                var mousePos = ray.GetPoint(distance + 1f);

                var move = mousePos - mouseStartPos;

                var control = playerStartPos + move;


                if(characterCount>15)
                    control.z = Mathf.Clamp(control.z, -8, -2f);
                else
                    control.z = Mathf.Clamp(control.z, -8, -2f);


                transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Lerp(transform.position.z,control.z,Time.deltaTime*playerSpeed));
            }
        }
       
    }
   public void MoveTheRoad()
    {
        if (!gameState && roadMoving == true)
        {
            road.Translate(road.right * Time.deltaTime * -roadSpeed);
        }
    }
    public void FormatStickMan()
    {
        for (int i = 0; i < player1.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);

            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos=new Vector3(x,-0.79f,z);

            player1.transform.GetChild(i).DOLocalMove(NewPos, 1f).SetEase(Ease.OutBack);
        }
        StartCoroutine(Death());      
    }
   

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);

        FormatStickMan();
    }


    private void MakeStickMan(int numner)
    {
        for (int i = 0; i < numner; i++)
        {
            Instantiate(gunner, transform.position, player1.transform.rotation,transform);
        }
        characterCount = transform.childCount - numner;

        FormatStickMan();
    }
    private void MageStickMan(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(Mage,transform.position, player1.transform.rotation,transform);
        }
        characterCount=transform.childCount - number;

        FormatStickMan();
    }
    
    private void bomberStickMan(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(bomber,transform.position, player1.transform.rotation,transform);
        }
        characterCount=transform.childCount - number;

        FormatStickMan();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Gate"))
        {
           

            collision.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false;

            collision.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;

            var gateManager = collision.GetComponent<GateManager>();

            if (gateManager.multiply) 
            {
                MakeStickMan(Random.Range(gateManager.randomMax, gateManager.randomMin));
                
            }
            else
            {
                MakeStickMan(gateManager.randomNumber);
            }
            collision.transform.parent.gameObject.SetActive(false);
            }
        

        if (collision.CompareTag("MageGate"))

        {
            collision.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false;

            collision.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;

            var gateManager = collision.GetComponent<GateManager>();

            if(gateManager.multiply)
            {
                MageStickMan( gateManager.randomNumber);
            }
            else
            {
                MageStickMan(gateManager.randomNumber);
            }
            collision.transform.parent.gameObject.SetActive(false);

        }

        if (collision.CompareTag("BomberGate"))
        {
            collision.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false;

            collision.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;

            var gateManager = collision.GetComponent<GateManager>();

            if (gateManager.multiply)
            {
                bomberStickMan(gateManager.randomNumber);
            }
            else
            {
                bomberStickMan(gateManager.randomNumber);
            }
            collision.transform.parent.gameObject.SetActive(false);

        }
        if (collision.CompareTag("GoldGate"))
        {
            GameManager.Instance.GetMoney();

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using DG.Tweening.Core.Easing;

public class PlayerManager : MonoBehaviour
{
    public Transform player1;
    public Transform magePl;
    private int CountChar;
    [SerializeField] private GameObject stickman;
    [SerializeField] private GameObject stickman1;
    [SerializeField] private GameObject stickman2;

    public GameObject secondWaveOpen;

    [SerializeField] TMP_Text gateText;
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

        CountChar = transform.childCount - 1;
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
            if(plane.Raycast(ray,out var distance
                    ))
            {
                var mousePos = ray.GetPoint(distance + 1f);
                var move = mousePos - mouseStartPos;
                var control = playerStartPos + move;

                if(CountChar>15)
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
            Instantiate(stickman, transform.position, player1.transform.rotation,transform);
        }
        CountChar = transform.childCount - numner;
        FormatStickMan();
    }
    private void MageStickMan(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickman1,transform.position, player1.transform.rotation,transform);
        }
        CountChar=transform.childCount - number;
        FormatStickMan();
    }
    
    private void bomberStickMan(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickman2,transform.position, player1.transform.rotation,transform);
        }
        CountChar=transform.childCount - number;
        FormatStickMan();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Gate"))
        {
            collision.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            collision.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;

            var gateManager = collision.GetComponent<GateManager>();
            if (gateManager.multiply) {
                MakeStickMan(gateManager.randomNumber);
                

            }
            else
            {
                MakeStickMan( gateManager.randomNumber);
                

            }
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
        }




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideRoute : MonoBehaviour
{
    public Camera myCamera;
    private float interactionDistance = 100f;
    
    //refer to the living objects
    public GameObject apple;
    public GameObject cat;
    public GameObject carrot;
    public GameObject chicken;
    
    //refer to the non-living objects
    public GameObject hammer;
    public GameObject trumpet;
    public GameObject chair;
    public GameObject bicycle;
    
    //the center points of objects
    private Vector3 centerApple;
    private Vector3 centerCat;
    private Vector3 centerCarrot;
    private Vector3 centerChicken;
    
    private Vector3 centerHammer;
    private Vector3 centerTrumpet;
    private Vector3 centerChair;
    private Vector3 centerBicycle;

    
    private GameObject lineApple;
    private GameObject lineCat;
    private GameObject lineCarrot;
    private GameObject lineChicken;
    
    private GameObject lineHammer;
    private GameObject lineTrumpet;
    private GameObject lineChair;
    private GameObject lineBicycle;

    
    
    // Start is called before the first frame update
    void Start()
    {
        float y = 0.1f;
        // Vector3 centerApple = apple.GetComponent<MeshRenderer>().bounds.center;
        // float x = centerApple.x;
        // float z = centerApple.z;
        // centerApple=new Vector3(x,y,z);
        
        centerApple = ObjectPoint(apple, y);
        centerCat = ObjectPoint(cat, y);
        centerCarrot = ObjectPoint(carrot, y);
        centerChicken = ObjectPoint(chicken, y);

        centerHammer = ObjectPoint(hammer, y);
        centerTrumpet = ObjectPoint(trumpet, y);
        centerChair = ObjectPoint(chair, y);
        centerBicycle = ObjectPoint(bicycle, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Camera myCamera = GetComponent<Camera>();
            Vector3 rayOrigin = myCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

            RaycastHit hitInfo = new RaycastHit();

            bool hit = Physics.Raycast(rayOrigin, myCamera.transform.forward, out hitInfo, interactionDistance);

            if (hit)
            {
                if (hitInfo.transform.CompareTag("APPLE"))
                {
                    Debug.Log("I SEE AN APPLE");
                    Destroy(apple);
                    Destroy(lineChair);
                    lineApple=DrawLine(centerApple, centerTrumpet, Color.blue, 1f);

                }
                else if (hitInfo.transform.CompareTag("CAT"))
                {
                    Debug.Log("I SEE A CAT");
                    Destroy(cat);
                    Destroy(lineHammer);
                    lineCat=DrawLine(centerCat, centerBicycle, Color.blue, 1f);
                }
                else if (hitInfo.transform.CompareTag("CARROT"))
                {
                    Debug.Log("I SEE A CARROT");
                    Destroy(carrot);
                    Destroy(lineBicycle);
                    lineCarrot=DrawLine(centerCarrot, centerChair, Color.blue, 1f);
                }
                else if (hitInfo.transform.CompareTag("CHICKEN"))
                {
                    Debug.Log("I SEE A CHICKEN");
                    Destroy(chicken);
                    Destroy(lineTrumpet);
                    lineChicken=DrawLine(centerChicken, centerHammer, Color.blue, 1f);
                }
                else if (hitInfo.transform.CompareTag("HAMMER"))
                {
                    Debug.Log("I SEE A HAMMER");
                    Destroy(hammer);
                    Destroy(lineChicken);
                    lineHammer=DrawLine(centerHammer, centerCat, Color.blue, 1f);
                }
                else if (hitInfo.transform.CompareTag("TRUMPET"))
                {
                    Debug.Log("I SEE A TRUMPET");
                    Destroy(trumpet);
                    Destroy(lineApple);
                    lineTrumpet=DrawLine(centerTrumpet, centerChicken, Color.blue, 1f);
                }
                else if (hitInfo.transform.CompareTag("CHAIR"))
                {
                    Debug.Log("I SEE A CHAIR");
                    Destroy(chair);
                    Destroy(lineCarrot);
                    //lineChair=DrawLine(centerChair, centerApple, Color.blue, 1f);
                }
                else if (hitInfo.transform.CompareTag("BICYCLE"))
                {
                    Debug.Log("I SEE A BICYCLE");
                    Destroy(bicycle);
                    Destroy(lineCat);
                    lineBicycle=DrawLine(centerBicycle, centerCarrot, Color.blue, 1f);
                }
            }
        }
    }

    GameObject DrawLine(Vector3 startPoint, Vector3 endPoint,Color c,float weight)                              
    {
        
        //define the positions of lines
        GameObject myLine = new GameObject();
        myLine.transform.position = startPoint;
        
        //add the line renderer component
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        
        //apply the material in order to show the lines
        lr.material =new Material(Shader.Find("Mobile/Particles/Additive"));
        
        //define the colors of lines
        lr.startColor = c;
        lr.endColor = c;
        
        //define the weight of lines
        lr.startWidth = weight;
        lr.endWidth = weight*2f;
        
        //define the point orders of lines
        lr.SetPosition(0, startPoint);
        lr.SetPosition(1, endPoint);

        return myLine;
    }
    
    Vector3 ObjectPoint(GameObject gameObject,float yValue) 
    {
        //Vector3 gameObjectPoint= gameObject.GetComponent<MeshRenderer>().bounds.center;
        Vector3 gameObjectPoint = gameObject.transform.position;
        gameObjectPoint.y = yValue;
        gameObject.transform.position = gameObjectPoint;
        
        return gameObjectPoint;
    }

    //define the map function
    float Map(float t, float a1, float b1, float a2, float b2)
    {
        if (t >= b1) {
            return b1;
        }else if(t<=a1) {
            return a1;
        }else {
            return ((t - a1) * (b2 - a2)) / (b1 - a1) + a2;
        }
    }
}

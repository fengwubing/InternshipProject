using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuideRoute1 : MonoBehaviour
{
    public Camera myCamera;
    private float interactionDistance = 5f;
    
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
    
    //the arrows of living and non-living objects
    public GameObject arrowAppleTrumpt;
    public GameObject arrowTrumpetChicken;
    public GameObject arrowChickenHammer;
    public GameObject arrowHammerCat;
    public GameObject arrowCatBicyle;
    public GameObject arrowBicyleCarrot;
    public GameObject arrowCarrotChair;
    public GameObject arrowChairApple;


    public Transform player;
    private float distanceToView = 8f;
    
    
    bool appleVisible = true;
    bool trumpetVisible = true;
    bool chickenVisible = true;
    bool hammerVisible = true;
    bool catVisible = true;
    bool bicycleVisible = true;
    bool carrotVisible = true;
    bool chairVisible = true;


    // Start is called before the first frame update
    void Start()
    {
        //make all the arrow invisible
        arrowAppleTrumpt.GetComponent<Renderer>().enabled = false;
        arrowTrumpetChicken.GetComponent<Renderer>().enabled = false;
        arrowChickenHammer.GetComponent<Renderer>().enabled = false;
        arrowHammerCat.GetComponent<Renderer>().enabled = false;
        arrowCatBicyle.GetComponent<Renderer>().enabled = false;
        arrowBicyleCarrot.GetComponent<Renderer>().enabled = false;
        arrowCarrotChair.GetComponent<Renderer>().enabled = false;
        arrowChairApple.GetComponent<Renderer>().enabled = false;

        
        //set the text to default false
        apple.GetComponentInChildren<TextMeshPro>().enabled=false;
        cat.GetComponentInChildren<TextMeshPro>().enabled=false;
        carrot.GetComponentInChildren<TextMeshPro>().enabled=false;
        chicken.GetComponentInChildren<TextMeshPro>().enabled=false;
        trumpet.GetComponentInChildren<TextMeshPro>().enabled=false;
        hammer.GetComponentInChildren<TextMeshPro>().enabled=false;
        chair.GetComponentInChildren<TextMeshPro>().enabled=false;
        bicycle.GetComponentInChildren<TextMeshPro>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 rayOrigin = myCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(rayOrigin, myCamera.transform.forward, out hitInfo, interactionDistance);
        
        
        //apple
        if (Vector3.Distance(player.transform.position, apple.transform.position) <= distanceToView)
        {
            apple.GetComponentInChildren<TextMeshPro>().enabled = appleVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("APPLE"))
                    {
                        Debug.Log("I SEE AN APPLE");
                        apple.GetComponent<MeshRenderer>().enabled = false;
                        apple.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowAppleTrumpt.GetComponent<Renderer>().enabled = true;
                        appleVisible = false;
                    }
                }
            }
        }
        else
        {
            apple.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //trumpet
        if (Vector3.Distance(player.transform.position, trumpet.transform.position) <= distanceToView)
        {
            trumpet.GetComponentInChildren<TextMeshPro>().enabled = trumpetVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("TRUMPET"))
                    {
                        Debug.Log("I SEE AN TRUMPET");
                        trumpet.GetComponent<MeshRenderer>().enabled = false;
                        trumpet.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowAppleTrumpt.GetComponent<Renderer>().enabled = false;
                        arrowTrumpetChicken.GetComponent<Renderer>().enabled = true;
                        trumpetVisible = false;
                    }
                }
            }
        }
        else
        {
            trumpet.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //chicken
        if (Vector3.Distance(player.transform.position, chicken.transform.position) <= distanceToView)
        {
            chicken.GetComponentInChildren<TextMeshPro>().enabled = chickenVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("CHICKEN"))
                    {
                        Debug.Log("I SEE AN CHICKEN");
                        chicken.GetComponent<MeshRenderer>().enabled = false;
                        chicken.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowTrumpetChicken.GetComponent<Renderer>().enabled = false;
                        arrowChickenHammer.GetComponent<Renderer>().enabled = true;
                        chickenVisible = false;
                    }
                }
            }
        }
        else
        {
            chicken.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //hammer
        if (Vector3.Distance(player.transform.position, hammer.transform.position) <= distanceToView)
        {
            hammer.GetComponentInChildren<TextMeshPro>().enabled = hammerVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("HAMMER"))
                    {
                        Debug.Log("I SEE AN HAMMER");
                        hammer.GetComponent<MeshRenderer>().enabled = false;
                        hammer.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowChickenHammer.GetComponent<Renderer>().enabled = false;
                        arrowHammerCat.GetComponent<Renderer>().enabled = true;
                        hammerVisible = false;
                    }
                }
            }
        }
        else
        {
            hammer.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //cat
        if (Vector3.Distance(player.transform.position, cat.transform.position) <= distanceToView)
        {
            cat.GetComponentInChildren<TextMeshPro>().enabled = catVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("CAT"))
                    {
                        Debug.Log("I SEE AN CAT");
                        cat.GetComponent<MeshRenderer>().enabled = false;
                        cat.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowHammerCat.GetComponent<Renderer>().enabled = false;
                        arrowCatBicyle.GetComponent<Renderer>().enabled = true;
                        catVisible = false;
                    }
                }
            }
        }
        else
        {
            cat.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //bicycle
        if (Vector3.Distance(player.transform.position, bicycle.transform.position) <= distanceToView)
        {
            bicycle.GetComponentInChildren<TextMeshPro>().enabled = bicycleVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("BICYCLE"))
                    {
                        Debug.Log("I SEE AN BYCYCLE");
                        bicycle.SetActive(false);
                        //bicycle.GetComponent<MeshRenderer>().enabled = false;
                        bicycle.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowCatBicyle.GetComponent<Renderer>().enabled = false;
                        arrowBicyleCarrot.GetComponent<Renderer>().enabled = true;
                        bicycleVisible = false;
                    }
                }
            }
        }
        else
        {
            bicycle.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //carrot
        if (Vector3.Distance(player.transform.position, carrot.transform.position) <= distanceToView)
        {
            carrot.GetComponentInChildren<TextMeshPro>().enabled = carrotVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("CARROT"))
                    {
                        Debug.Log("I SEE AN CARROT");
                        carrot.GetComponent<MeshRenderer>().enabled = false;
                        carrot.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowBicyleCarrot.GetComponent<Renderer>().enabled = false;
                        arrowCarrotChair.GetComponent<Renderer>().enabled = true;
                        carrotVisible = false;
                    }
                }
            }
        }
        else
        {
            carrot.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        
        
        //chair
        if (Vector3.Distance(player.transform.position, chair.transform.position) <= distanceToView)
        {
            chair.GetComponentInChildren<TextMeshPro>().enabled = chairVisible;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    if (hitInfo.transform.CompareTag("CHAIR"))
                    {
                        Debug.Log("I SEE AN CHAIR");
                        chair.GetComponent<MeshRenderer>().enabled = false;
                        chair.GetComponentInChildren<TextMeshPro>().enabled = false;
                        arrowCarrotChair.GetComponent<Renderer>().enabled = false;
                        arrowChairApple.GetComponent<Renderer>().enabled = false;
                        chairVisible = false;
                    }
                }
            }
        }
        else
        {
            chair.GetComponentInChildren<TextMeshPro>().enabled = false;
        }


        
    }
}

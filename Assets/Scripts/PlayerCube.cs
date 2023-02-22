using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCube : MonoBehaviour
{
    public float speed;

    public Image Fullbar;
    public GameObject Winscreen;

    public GameObject BlueWalls;
    public GameObject RedWalls;

    private bool SwitchRed;
    private bool SwitchBlue;

    void Start()
    {
        Fullbar.fillAmount = 0f;

        Winscreen.SetActive(false);

        SwitchRed = false;

        RedWalls.SetActive(false);
    }

    void Update()
    {
        //4 directional movement
        float x = (Input.GetAxis("Horizontal") * speed);
        float z = (Input.GetAxis("Vertical") * speed);
        transform.position += new Vector3(x * Time.deltaTime, 0f, z * Time.deltaTime);

        //winning
        if (Fullbar.fillAmount == 1)
        {
            Winscreen.SetActive(true);
        }
            
    }

    public void SwitchColorR()
    {
        SwitchRed = true;
            RedWalls.SetActive(true);
            BlueWalls.SetActive(false);
    }

    public void SwitchColorB()
    {
        SwitchBlue = true;
           RedWalls.SetActive(false);
           BlueWalls.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collectscript co = collision.gameObject.GetComponent<Collectscript>();
        if (co)
        {
            Destroy(collision.gameObject);
            Fullbar.fillAmount += 0.13f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    static int check = 1;
    public AudioSource splash;
    public static bool bobinBeaker = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaySplash();
        if (other.attachedRigidbody.tag == "Bob")
        {
            if (check < 0)
            {
                Debug.Log("Bob out of Water");
                Transform waterRb1 = GetComponent<Transform>();
                Vector3 start1 = new Vector3(waterRb1.transform.position.x, waterRb1.transform.position.y, waterRb1.transform.position.z);
                Vector3 end1 = new Vector3(waterRb1.transform.position.x, waterRb1.transform.position.y - 1.8f, waterRb1.transform.position.z);
                GetComponent<Transform>().position = Vector3.Lerp(start1, end1, Time.deltaTime * 0.8f);
                WeightController.bobInBeaker = false;
                bobinBeaker = false;
                check = check * -1;
                return;
            }

            Debug.Log("Bob in Water");
            bobinBeaker = true;
            BeakerController.bobInBeaker = true;
            Transform waterRb = GetComponent<Transform>();
            Vector3 start = new Vector3(waterRb.transform.position.x, waterRb.transform.position.y, waterRb.transform.position.z);
            Vector3 end = new Vector3(waterRb.transform.position.x, waterRb.transform.position.y + 1.8f, waterRb.transform.position.z);
            GetComponent<Transform>().position = Vector3.Lerp(start, end, Time.deltaTime * 0.8f);
        }
        check = check * -1;
    }

    public void PlaySplash()
    {
        splash.Play();
    }
}

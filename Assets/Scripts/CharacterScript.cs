using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public GameObject jumpText;

    private int JumpCounter;
    public AudioClip[] audioClipArr;
    private AudioSource audioSource;
    private Rigidbody rb;

    int jumpSpeed = 6;
    bool isOnFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor == true)
        {
            isOnFloor = false;
            JumpCounter++;
            jumpText.GetComponent<Text>().text = "Jump: " + JumpCounter;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            // audioSource.Play();

            int rand = Random.Range(0, audioClipArr.Length);
            audioSource.PlayOneShot(audioClipArr[rand]);
        }
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
        }
    }
}

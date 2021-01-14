using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip[] BGMArr;
    private AudioSource audioSource;

    float volSlider = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            audioSource.Stop();
            int rand = Random.Range(0, BGMArr.Length);
            audioSource.PlayOneShot(BGMArr[rand]);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.volume = audioSource.volume + Time.deltaTime + volSlider;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.volume = audioSource.volume + Time.deltaTime - volSlider;
        }
    }
}

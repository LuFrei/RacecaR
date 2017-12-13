using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverse : MonoBehaviour {

    public GameManager gm;
    public Animator anim;

    private void Start()
    {
        gm = GameObject.Find("GameManager(Clone)").GetComponent<GameManager>();
        anim = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        anim.SetBool("isReversed", gm.inverseActive);
        anim.SetFloat("Countdown", gm.inverseCountdown);
        anim.SetFloat("Duration", gm.inverseDuration);
    }
}

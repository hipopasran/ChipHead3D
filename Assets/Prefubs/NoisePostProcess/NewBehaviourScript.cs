using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public PostProcessingProfile m_Profile;
    public double timerStart;
    private double timerEnd;
    bool isTriggered;


    private void Start()
    {
        timerEnd = timerStart + 10;
        var behaviour = GetComponent<PostProcessingBehaviour>();

        if (behaviour.profile == null)
        {
            enabled = false;
            return;
        }

        m_Profile = Instantiate(behaviour.profile);
        behaviour.profile = m_Profile;
        isTriggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
    }

    void Update()
    {
        if (isTriggered)
        {
            var vignette = m_Profile.vignette.settings;
            var grain = m_Profile.grain.settings;
            //if ((Time.realtimeSinceStartup >= timerStart) && (Time.realtimeSinceStartup <= timerEnd))
            //{

                vignette.intensity = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup)) * 0.5f;
                m_Profile.vignette.settings = vignette;


                grain.intensity = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup)) + 0.2f;
                m_Profile.grain.settings = grain;


            //}
            //if (Time.realtimeSinceStartup > timerEnd)
            //{
            //    m_Profile.grain.Reset();
            //    m_Profile.vignette.Reset();
            //}
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {
        public Transform TextTargetName;
        public Transform ButtonAction;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
		//add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);
			
                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                ButtonAction.gameObject.SetActive(true);
                TextTargetName.gameObject.SetActive(true);

                if(name == "arduino-uno")
                {
                    TextTargetName.GetComponent<Text>().text = "Arduino UNO R3";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("ArduinoUnoSound"); });
                }

                if (name == "ir-barrier-sensor")
                {
                    TextTargetName.GetComponent<Text>().text = "IR Barrier Sensor";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("IrBarrierSensorSound"); });
                }

                if (name == "flame-sensor")
                {
                    TextTargetName.GetComponent<Text>().text = "IR Flame Sensor";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("FlameSensorSound"); });
                }

                if (name == "ldr-sensor")
                {
                    TextTargetName.GetComponent<Text>().text = "LDR Light Sensor";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("LdrSensorSound"); });
                }
            }
        }

        //function to play sound
        void playSound(string ss){
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}

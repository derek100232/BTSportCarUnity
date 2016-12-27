using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;



public class BasicDemo : MonoBehaviour {

    string fromArduino = "";
    string stringToEdit = "HC-06";

    bool IsPressW = false;
    bool IsPressA = false;
    bool IsPressS = false;
    bool IsPressD = false;
    bool IsPressBT = false;
    public GameObject Bluetoothset;
    public GameObject Canvas;
    public Sprite BTopen;
    public Sprite BTclose;
    public Sprite BTsprite;
    public Text Status;
    ///
    public void Press_W_Down()
    {

        IsPressW = true;

    }

    ///
    public void Press_A_Down()
    {

        IsPressA = true;

    }
    ///
    public void Press_S_Down()
    {

        IsPressS = true;

    }
    ///
    public void Press_D_Down()
    {

        IsPressD = true;

    }

    public void Press_Up()
    {

        IsPressW = false;
        IsPressA = false;
        IsPressS = false;
        IsPressD = false;
        BtConnector.sendChar('\n');
    }


    void Update()
    {

        if (IsPressW)
        {
            BtConnector.sendChar('w');
            //don't call the send method multiple times unless you really need to, because it will kill performance.
            Debug.Log("w");
            //Handheld.Vibrate();
        }

        if (IsPressA)
        {
            BtConnector.sendChar('a');
            //don't call the send method multiple times unless you really need to, because it will kill performance.
            Debug.Log("a");
            //Handheld.Vibrate();
        }

        if (IsPressS)
        {
            BtConnector.sendChar('s');
            //don't call the send method multiple times unless you really need to, because it will kill performance.
            Debug.Log("s");
            //Handheld.Vibrate();
        }

        if (IsPressD)
        {
            BtConnector.sendChar('d');
            //don't call the send method multiple times unless you really need to, because it will kill performance.
            Debug.Log("d");
            //Handheld.Vibrate();
        }

        Status.text = "Bluetooth Status : " + BtConnector.readControlData();

        if (BtConnector.isConnected())
        {
            BTSPopen();
        }
        else
        {        
            BTSPclose();
        }


    }


    public void BluetoothConnect()
    {
        if (!BtConnector.isBluetoothEnabled())
        {
            BtConnector.askEnableBluetooth();
        }
        else
        {

            BtConnector.moduleName(stringToEdit); //incase User Changed the Bluetooth Name
            BtConnector.connect();
        }
    }


    public void BluetoothClose()
    {
        if (BtConnector.isConnected())
        {
            BtConnector.close();

        }
    }

    public void BluetoothSwitch()
    {
        if (IsPressBT)
        {
            BluetoothConnect();
            IsPressBT = false;
            Debug.Log("BTopen");
        }
        else
        {
            BluetoothClose();
            IsPressBT = true;
            Debug.Log("BTclose");
        }
    } 
 

    public void BTSPclose()//change sprite close
    {
        Bluetoothset.gameObject.GetComponent<Image>().sprite = BTclose;
    }

    public void BTSPopen()//change sprite close
    {
        Bluetoothset.gameObject.GetComponent<Image>().sprite = BTopen;
    }


    void Start () {
        //use one of the following two methods to change the default bluetooth module.
        //BtConnector.moduleMAC("00:13:12:09:55:17");
        //BtConnector.moduleName ("HC-05");

        BTsprite = Bluetoothset.GetComponent<Image>().sprite;
        Status = Canvas.GetComponent<Text>();
    }


	void OnGUI(){

		//GUI.Label(new Rect(0, 0, Screen.width*0.15f, Screen.height*0.1f),"Module Name ");
		//stringToEdit = GUI.TextField(new Rect(Screen.width*0.15f, 0, Screen.width*0.8f, Screen.height*0.1f), stringToEdit);

		//GUI.Label(new Rect(0,Screen.height*0.2f,Screen.width,Screen.height*0.1f),"Arduino Says : " +  fromArduino);
		//GUI.Label(new Rect(0,Screen.height*0.2f,Screen.width,Screen.height*0.1f),"Bluetooth Status : " + BtConnector.readControlData ());
	
		///the hidden code here let you connect directly without askin the user
		/// if you want to use it, make sure to hide the code from line 23 to lin 33
		/*
		if( GUILayout.Button ("Connect")){ 
			
			startConnection = true; 
			
		} 
		
		if(GUI.Button(new Rect(0,Screen.height*0.4f,Screen.width,Screen.height*0.1f), "Connect")) 
		{
			if (!BtConnector.isBluetoothEnabled ()){ 
				BtConnector.enableBluetooth(); 
				
			} else {  
				
				BtConnector.connect(); 
				
				startConnection = false; 
				
			} 
			
		} 
		*/
		/*
		if(GUI.Button(new Rect(0,Screen.height*0.6f,Screen.width,Screen.height*0.1f), "sendChar")) {
            // if(BtConnector.isConnected()){
            //    BtConnector.sendChar('w');
            //    BtConnector.sendChar ('\n');//because we are going to read it using .readLine() which reads lines.
            //    Debug.Log("w");
            //    //don't call the send method multiple times unless you really need to, because it will kill performance.
		
            //}
				
		}
		if(GUI.Button(new Rect(0,Screen.height*0.5f,Screen.width,Screen.height*0.1f), "sendString")) {
			
			if(BtConnector.isConnected()){
				BtConnector.sendString("Hii");
				BtConnector.sendString("you can do this");
				//BtConnector.sendBytes(new byte[] {55,55,55,10});

				//don't call the send method multiple times unless you really need to, because it will kill performance.
			}
		}


	
		if(GUI.Button(new Rect(0,Screen.height*0.7f,Screen.width,Screen.height*0.1f), "Close")) {
			BtConnector.close();
		}

		if(GUI.Button(new Rect(0,Screen.height*0.8f,Screen.width,Screen.height*0.1f), "readData")) {
			if (BtConnector.available()) {
			fromArduino =  BtConnector.readLine ();
			}

		}
		if (GUI.Button (new Rect (0, Screen.height * 0.9f, Screen.width, Screen.height * 0.1f), "change ModuleName")) {
			BtConnector.moduleName(stringToEdit);

		}
        */

	}
}

public class EventTriggerExample : EventTrigger
{
    public override void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag called.");
    }

    public override void OnCancel(BaseEventData data)
    {
        Debug.Log("OnCancel called.");
    }

    public override void OnDeselect(BaseEventData data)
    {
        Debug.Log("OnDeselect called.");
    } 

    public override void OnPointerClick(PointerEventData data)
    {
        Debug.Log("OnPointerClick called.");
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("OnPointerEnter called.");
    }

    public override void OnPointerExit(PointerEventData data)
    {
        Debug.Log("OnPointerExit called.");
    }

}

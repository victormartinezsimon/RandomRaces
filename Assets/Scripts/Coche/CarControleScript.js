/*
Script Created by FlatTutorials for "Car Controller kit".
*/

@script AddComponentMenu ("FlatTutorials/Scripts/Car Control Script")
#pragma strict
var centerOfMass : Vector3;	//Center of mass
var dataWheel : WheelCollider;	//Wheel Collider from which you want to calculate the speed
var lowestSteerAtSpeed : float = 50;	//if lowestSteerAtSpeed < currentSpeed the steer Angle = highSpeedSteerAngel
var lowSpeedSteerAngel : float = 10;	//This could be a high value
var highSpeedSteerAngel : float = 1;	//This shouldn't be a high value (recomended for stability of car)
var decellarationSpeed : float = 30;	//How fast the car will decellarate
var maxTorque : float  = 50;	//Maximum Torque
var currentSpeed : float;		//Current Speed of car
var topSpeed : float = 150;		//Highest speed at which the car can go
var maxReverseSpeed : float = 50; 	//Highest Reverse speed
var backLightObject : GameObject;	//Mesh for reverse light
var idleLightMaterial : Material;	//for idle state
var brakeLightMaterial : Material; 	//Braked state
var reverseLightMaterial : Material;	//Reverse state
@HideInInspector	
var braked : boolean = false;	//Brake trigger
var maxBrakeTorque : float = 100; 	//Braking speed
var speedOMeterDial : Texture2D;	//GUI Texture for dial
var speedOMeterPointer : Texture2D;		//GUI Texture for needle
var tamSpeedOMeter : Vector2;// tam of the previous gui
var gearRatio : int[];		//Shift gear at speed
var spark : GameObject;		//OnCollision Spark

//var collisionSound : GameObject;	//OnCollision Sound

function Start () {
rigidbody.centerOfMass=centerOfMass; //Center of mass , for this the car should be pointing on z axis
}

function FixedUpdate () {
rigidbody.centerOfMass=centerOfMass; //Center of mass , for this the car should be pointing on z axis
HandBrake();
}
function Update(){
BackLight ();
EngineSound();
CalculateSpeed();
}

//Speed Calculation

function CalculateSpeed()
{
	currentSpeed = 2*22/7*dataWheel.radius*dataWheel.rpm*60/1000;
	currentSpeed = Mathf.Round(currentSpeed);
	
	currentSpeed=Mathf.Min(currentSpeed,topSpeed);
}

//Light Control

function BackLight ()
{
	//if (currentSpeed > 0 && Input.GetAxis("Vertical")<0&&!braked)
	if (currentSpeed > 0 && CustomInput.getInstance().getVertical()<0&&!braked)
	{
		backLightObject.renderer.material = brakeLightMaterial;
	}
	else 
	//if (currentSpeed < 0 && Input.GetAxis("Vertical")>0&&!braked)
	if (currentSpeed < 0 && CustomInput.getInstance().getVertical()>0&&!braked)
	{
		backLightObject.renderer.material = brakeLightMaterial;
	}
	else 
	//if (currentSpeed < 0 && Input.GetAxis("Vertical")<0&&!braked)
	if (currentSpeed < 0 && CustomInput.getInstance().getVertical()<0&&!braked)
	{
		backLightObject.renderer.material = reverseLightMaterial;
	}
	else 
	if (!braked)
	{
		backLightObject.renderer.material = idleLightMaterial;
	}
}

//Brake Trigger

function HandBrake(){
if (Input.GetButton("Jump")){
braked = true;
}
else{
braked = false;
}
}

//Engine Sound

function EngineSound()
{
	for (var i = 0; i < gearRatio.length; i++)
	{
		if(gearRatio[i]> currentSpeed)
		{
			break;
		}
	}
	var gearMinValue : float = 0.00;
	var gearMaxValue : float = 0.00;
	if (i == 0)
	{
		gearMinValue = 0;
	}
	else 
	{
		gearMinValue = gearRatio[i-1];
	}
	if(i==6)
	{
		Debug.Log(currentSpeed);
	}
	gearMaxValue = gearRatio[i];
	var enginePitch : float = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
	audio.pitch = enginePitch;
}

//Speedometer

function OnGUI ()
{
	//GUI.DrawTexture(Rect(Screen.width/2 - separacionX,Screen.height - separacionY,300,150),speedOMeterDial);
	var rectanguloFuera= Rect(	Screen.width/2 - Screen.width * tamSpeedOMeter.x/2,	
							Screen.height - Screen.height * tamSpeedOMeter.y,
							Screen.width * tamSpeedOMeter.x,
							Screen.height * tamSpeedOMeter.y);
							
	GUI.DrawTexture(rectanguloFuera,speedOMeterDial);
	var speedFactor : float = currentSpeed / topSpeed;
	var rotationAngle : float;
	if (currentSpeed >= 0){
	  rotationAngle = Mathf.Lerp(0,180,speedFactor);
	  }
	  else {
	  rotationAngle = Mathf.Lerp(0,180,-speedFactor);
	  }
	GUIUtility.RotateAroundPivot(rotationAngle,Vector2(Screen.width/2 ,Screen.height));
	var rectanguloAguja= Rect(	Screen.width/2 - Screen.width * tamSpeedOMeter.x/2,	
							Screen.height - Screen.height * tamSpeedOMeter.y,
							Screen.width * tamSpeedOMeter.x,
							Screen.height * tamSpeedOMeter.y*2);
	GUI.DrawTexture(rectanguloAguja,speedOMeterPointer);

}

//CollisioN FX
/*
function OnCollisionEnter (other : Collision)
{
	if (other.transform != transform && other.contacts.length != 0)
	{
		for (var i = 0; i < other.contacts.length ; i++)
		{
			Instantiate(spark,other.contacts[i].point,Quaternion.identity);
			var clone : GameObject = Instantiate(collisionSound,other.contacts[i].point,Quaternion.identity);
			clone.transform.parent = transform;
		}
	}
}
*/
function OnDrawGizmos  () {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position+centerOfMass, 0.1);
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bicycle
{
	class Cyclist
	{
		private string name;
		private bool onbike;

		private Bicycle bike;

		public bool GetBikeState()
		{
			return bike.stateup;
		}

		public void SetBikeState(bool b)
		{
			bike.stateup = b;
		}

		public string GetBikeDirection()
		{
			return bike.controlSystem.GetDirection();
		}

		public int GetSaddleHeight()
		{
			return bike.customizationSystem.GetSaddleHeight();
		}

		public void SaddleDown()
		{
			bike.customizationSystem.SaddleDown();
		}

		public void SaddleUp()
		{
			bike.customizationSystem.SaddleUp();
		}

		public int GetSWAngle()
		{
			return bike.controlSystem.GetSWAngle();
		}

		public void SWAngleRight()
		{
			bike.controlSystem.SetSWAngle(bike.customizationSystem.FixAngleRight(bike.controlSystem.GetSWAngle()));
		}

		public void SWAngleLeft()
		{
			bike.controlSystem.SetSWAngle(bike.customizationSystem.FixAngleLeft(bike.controlSystem.GetSWAngle()));
		}

		public double GetBikeSpeed()
		{
			return bike.movementSystem.GetSpeed();
		}

		public int GetTirePressure()
		{
			return bike.customizationSystem.GetTirePressure();
		}

		public void TirePressureUp()
		{
			bike.customizationSystem.FixPressureUp();
		}
		public void TirePressureDown()
		{
			bike.customizationSystem.FixPressureDown();
		}

		public void ShifterUp()
		{
			bike.speedAdjustment.SetShifterUp();
			bike.movementSystem.SetMaxSpeedShift(bike.speedAdjustment.GetShiftersMode());
		}

		public void ShifterDown()
		{
			bike.speedAdjustment.SetShifterDown();
			bike.movementSystem.SetMaxSpeedShift(bike.speedAdjustment.GetShiftersMode());
		}

		public int GetShifterMode()
		{
			return bike.speedAdjustment.GetShiftersMode();

		}

		public double GetMaxSpeed()
		{
			return bike.movementSystem.GetMaxSpeed();
		}
		public void TakeBike()
		{
			bike.stateup = true;
		}

		public void PutBike()
		{
			bike.stateup = false;
		}

		public void CommandSitStand(bool b)
		{
			onbike = b;
		}
		public bool GetOnBike ()
		{
			return onbike;
		}

		public void PushBike()
		{ 
		if(bike.stateup)
			{
				bike.movementSystem.CommandPush();
			}
		}
		public void PedalBike() 
		{
			if (bike.movementSystem.GetSpeed() < 50)
			{
				bike.movementSystem.CommandPedal();
			}
		}
		public void ChangeDir(string d) 
		{
			switch(d)
				{
				case "r":
					bike.controlSystem.TurnRight();
					break;
				case "l":
					bike.controlSystem.TurnLeft();
					break;
				case "s":
					bike.controlSystem.GoStraight();
					break;
				}
		}

		public void Lean(string d)
		{
			switch (d)
			{
				case "r":
					bike.controlSystem.TurnRight();
					break;
				case "l":
					bike.controlSystem.TurnLeft();
					break;
				case "s":
					bike.controlSystem.GoStraight();
					break;
			}
		}

		public void GentleSlow() 
		{
			bike.movementSystem.SetSpeed(bike.brakingSystem.SoftBrake(bike.movementSystem.GetSpeed()));
		}
		public void HardSlow()
		{
			bike.movementSystem.SetSpeed(bike.brakingSystem.HardBrake(bike.movementSystem.GetSpeed()));
		}
		public void SetName(string n) { name = n; }
		public string GetName() { return name; }



		public Cyclist() 
		{ 
			name = "Unknown";
			bike = new Bicycle();
			onbike = false;
		}
		public Cyclist(string namestr) 
		{ 
			name = namestr;
			bike = new Bicycle();
			onbike = false;
		}


	}
}

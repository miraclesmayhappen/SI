using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace bicycle
{


	class MovementSystem
	{
		private Pedals pedals;
		protected Chain chain;
		protected Stars stars;
		protected Wheel frontWheel;
		private Wheel rearWheel;

		protected double speed { get; set; }
		protected double maxspeed { get; set; }

		public MovementSystem()
		{
			pedals = new Pedals();
			chain = new Chain();
			stars = new Stars();
			frontWheel = new Wheel();
			rearWheel = new Wheel();
			speed = 0;
			maxspeed = 30;
		}

		internal Bicycle Bicycle
		{
			get => default;
			set
			{
			}
		}

		public void CommandPedal()
		{
			Random r = new Random();
			int range = 10;
			double rDouble = r.NextDouble() * range; //for doubles
			while (speed + rDouble > maxspeed)
			{
				rDouble = r.NextDouble() * range; //for doubles
			}
			speed += rDouble;
			speed = Math.Round(speed, 2);
		}
		public void CommandPush()
		{
			Random r = new Random();
			int range = 10;
			double rDouble = r.NextDouble() * range; //for doubles
			while (speed + rDouble > 6)
			{
				rDouble = r.NextDouble() * range; //for doubles
			}
			speed += rDouble;
			speed = Math.Round(speed, 2);

		}
		public double GetSpeed() { return speed; }
		public void SetSpeed(double s) { speed = s; }

		public double GetMaxSpeed() { return maxspeed; }
		public void SetMaxSpeedShift(int s) 
		{ 
		switch(s)
			{
				case 1:
					maxspeed = 10;
					break;
				case 2:
					maxspeed = 20;
					break;
				case 3:
					maxspeed = 30;
					break;
				case 4:
					maxspeed = 40;
					break;
				case 5:
					maxspeed = 50;
					break;
				case 6:
					maxspeed = 55;
					break;
				case 100:
					maxspeed = 10;
					break;
			}
		}
		
	}

	class ControlSystem 
	{
		protected SteeringWheel steeringWheel;
		private SteeringColumn steeringColumn;
		private string direction { get; set; }
		//	protected Wheel frontWheel;

		public ControlSystem()
		{
			steeringColumn = new SteeringColumn();
			steeringWheel = new SteeringWheel();
			direction = "Straight";
			//frontWheel = new Wheel();
		}

		public void TurnLeft()
		{
			direction = "Left";

		}
		public void TurnRight() { direction = "Right"; }
		public void GoStraight() { direction = "Straight"; }
		public string GetDirection() { return direction; }

		public int GetSWAngle()
		{
			return steeringWheel.angle;
		}

		public void SetSWAngle(int a)
		{
			steeringWheel.angle = a;
		}

	}

	class CustomizationSystem 
	{
		private bool state { get; set; }
		private Saddle saddle;
		private TireTube frontTireTube;
		private TireTube rearTireTube;
		//steering wheel

		
		public CustomizationSystem()
		{
			state = true;
			saddle = new Saddle();
			frontTireTube = new TireTube();
			rearTireTube = new TireTube();
		}

		public int GetTirePressure()
		{
			return frontTireTube.pressure;
		}

		public void SaddleUp()
		{
			if (saddle.height <= 5)
			{
				saddle.height += 1;
			}
		}

		public void SaddleDown()
		{
			if (saddle.height > 0)
			{
				saddle.height -= 1;
			}
		}

		public int GetSaddleHeight()
		{
			return saddle.height;
		}

		public int FixAngleRight(int a)
		{
			if (a<90)
			{
				a++;
			}
			return a;
		}

		public int FixAngleLeft(int a)
		{
			if (a > -90)
			{
				a--;
			}
			return a;
		}

		public void FixPressureUp()
		{
			if (frontTireTube.pressure<55)
			{
				frontTireTube.pressure++;
			}
		
		}
		public void FixPressureDown()
		{
			if (frontTireTube.pressure > 0)
			{ frontTireTube.pressure--; }
		}
	}
	class SpeedAdjustment 
		{
			private Shifters shifters;
			protected Ropes ropes;
			//stars
			//chain

			public SpeedAdjustment()
			{
				shifters = new Shifters();
				ropes = new Ropes();
			}
			
		public int GetShiftersMode() { return shifters.GetSpeedMode(); }
		public void SetShifterUp()
		{
			if(shifters.GetSpeedMode() < 6)
			{
				shifters.SetSpeedMode(shifters.GetSpeedMode()+1);
			}
		}
		public void SetShifterDown()
		{
			if (shifters.GetSpeedMode() > 1)
			{
				shifters.SetSpeedMode(shifters.GetSpeedMode() - 1);
			}
		}


	}
	class BrakingSystem 
		{
			private BrakeLevers brakeLevers;
			private Brakes frontBrakes;
			private Brakes rearBrakes;
			private Pads pads;
			//ropes

			public BrakingSystem()
			{
				brakeLevers = new BrakeLevers();
				//ropes = new Ropes();
				frontBrakes = new Brakes();
				rearBrakes = new Brakes();
				pads = new Pads();
			}

			public double SoftBrake(double speed)
			{
				if (speed > 0)
				{
					Random r = new Random();
					int range = 2;
					double rDouble = r.NextDouble() * range; //for doubles
					while (speed - rDouble < 0)
					{
						rDouble = r.NextDouble() * range; //for doubles
					}
					speed -= rDouble;
					speed = Math.Round(speed, 2);
				}
				return speed;
			}

			public double HardBrake(double speed)
			{
			if (speed > 0)
			{
				//	if (speed < 2)
				//	{
				//		speed = 0;
				//	}
				//	else
				//	{
				//		Random r = new Random();
				//		int range = 20;
				//		double rDouble = r.NextDouble() * range; //for doubles
				//		while (speed - rDouble < 0)
				//		{
				//			rDouble = r.NextDouble() * range; //for doubles
				//		}
				//		speed -= rDouble;
				//		speed = Math.Round(speed, 2);
				//	}
				speed = 0;
				}
				return speed;
			}
		}
	
}

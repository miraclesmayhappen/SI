using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycle
{
	class Chain
	{
		private bool state;
		private int length;

		internal SpeedAdjustment SpeedAdjustment
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }

		public bool GetState() { return state; }

		public Chain()
		{
			state = true;
			length = 110;
		}

		public Chain(int l)
		{
			state = true;
			length = l;
		}


	}

	class Stars
	{
		private bool state;
		private int rounds;

		internal SpeedAdjustment SpeedAdjustment
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }

		public bool GetState() { return state; }

		public Stars()
		{
			state = true;
			rounds = 7;
		}
		public Stars(int r)
		{
			state = true;
			rounds = r;
		}

	}

	class Pedals
	{
		private string size;
		private bool state;

		internal SpeedAdjustment SpeedAdjustment
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }

		public bool GetState() { return state; }

		public Pedals()
		{
			state = true;
			size = "M14-0.1";
		}
		public Pedals(string s)
		{
			state = true;
			size = s;
		}
	}

	class Wheel
	{
		//private string material_tire;
		//private string size_tire;
		//private string material_cord;
		//private string size_tube;
		//private int length_nippel;
		private bool state;
	
		internal MovementSystem MovementSystem
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }

		public bool GetState() { return state; }

		public Wheel()
		{
			state = true;
		}
	}

	class Ropes 
	{
		private int length_front;
		private int length_rear;
		private bool state;

		internal bicycle.SpeedAdjustment SpeedAdjustment
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public Ropes() 
		{
			state = true;
		}
	}

	class Shifters
	{

		private bool state;
		private int speedmode { get; set; }

		internal SpeedAdjustment SpeedAdjustment
		{
			get => default;
			set
			{
			}
		}

		public int GetSpeedMode() { return speedmode; }

		public void SetSpeedMode(int m) 
		{
			if(m<=6 && m>=1)
			speedmode = m; 
		} 

		public void SetState(bool b) { state = b; }

		public bool GetState() { return state; }

		public Shifters()
		{
			state = true;
			speedmode = 3;
		}
		public Shifters(int s)
		{
			state = true;
			speedmode = s;
		}

	}

	class Brakes
	{
		private int radius;
		private bool state;

		internal BrakingSystem BrakingSystem
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public Brakes()
		{
			state = true;
			radius = 5; //TBD
		}

		public Brakes(int r)
		{
			state = true;
			radius = r; 
		}
	}

	class BrakeLevers
	{
		//private Brakes FrontBrake;
		//private Brakes RearBrake;

		protected bool state;

		internal BrakingSystem BrakingSystem
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public BrakeLevers()
		{
			//FrontBrake = new Brakes();
			//RearBrake = new Brakes();
			state = true;
		}
		//public BrakeLevers(int f, int r)
		//{
		//	//FrontBrake = new Brakes(f);
		//	//RearBrake = new Brakes(r);
		//	state = true;
		//}

	}

	class Pads
	{
		private string size;
		private bool state;

		internal BrakingSystem BrakingSystem
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public Pads()
		{
			state = true;
			size = ""; //TBD
		}

		public Pads(string s)
		{
			state = true;
			size = s; 
		}
	}

	class TireTube
	{
		public int pressure { get; set; }

		internal CustomizationSystem CustomizationSystem
		{
			get => default;
			set
			{
			}
		}

		private bool state;
		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public TireTube()
		{
			state = true;
			pressure = 30;
		}
		public TireTube(int p)
		{
			state = true;
			pressure = p;
		}
	}

	class Saddle
	{
		public int height { get; set; }

		internal CustomizationSystem CustomizationSystem
		{
			get => default;
			set
			{
			}
		}

		private bool state;
		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public Saddle()
		{
			state = true;
			height = 0;
		}
		public Saddle(int p)
		{
			state = true;
			height = p;
		}

	}

	class SteeringWheel
	{
		public int angle {get; set;}
		private bool state;

		internal CustomizationSystem CustomizationSystem
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }
		public int GetAngle() { return angle; }
		public SteeringWheel()
		{
			Random r = new Random();
			int rInt = r.Next(-20, 20); //for ints
			angle = rInt;
			state = true;
		}

	}
	class SteeringColumn
	{
		private string size;
		private bool state;

		internal ControlSystem ControlSystem
		{
			get => default;
			set
			{
			}
		}

		public void SetState(bool b) { state = b; }
		public bool GetState() { return state; }

		public SteeringColumn()
		{
			size = ""; //TBD
			state = true;
		}
	}
}

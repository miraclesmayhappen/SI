using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycle
{
	class Bicycle
	{
		public SpeedAdjustment speedAdjustment;
		public BrakingSystem brakingSystem;
		public CustomizationSystem customizationSystem;
		public ControlSystem controlSystem;
		public MovementSystem movementSystem;

		public bool stateup { get; set; }

		public Bicycle()
		{
			speedAdjustment = new SpeedAdjustment();
			brakingSystem = new BrakingSystem();
			customizationSystem = new CustomizationSystem();
			controlSystem = new ControlSystem();
			movementSystem = new MovementSystem();

			stateup = false;
		}

		
	}
}

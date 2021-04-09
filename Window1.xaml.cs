using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bicycle
{
	/// <summary>
	/// Логика взаимодействия для Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		Cyclist cyclist;
	
		public Window1()
		{
			InitializeComponent();
			cyclist = new Cyclist();
			UpdateFields();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    HomeBorder.Visibility = Visibility.Visible;
                    SettingBorder.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    HomeBorder.Visibility = Visibility.Hidden;
                    SettingBorder.Visibility = Visibility.Visible;
                    break;
            }
        }

		private void PowerOffClick(object sender, RoutedEventArgs e)
		{
            App.Current.Shutdown();
		}

		private void TakeBikeButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.TakeBike();
			UpdateFields();
		}

		private void PutBikeButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() > 0)
			{
				AlertBlock.Text = "You can't put bike when it's moving";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else if (cyclist.GetOnBike() == true)
			{
				AlertBlock.Text = "You can't put bike when rider is on it";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				cyclist.SetBikeState(false);
				UpdateFields();
			}
		}

		private void PushBikeButton_Click(object sender, RoutedEventArgs e)
		{
			if (!cyclist.GetBikeState())
			{
				AlertBlock.Text = "You can't push bike when it's down";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				if (cyclist.GetBikeSpeed() > 6)
				{
					AlertBlock.Text = "You can't push bike when it's moving so fast";
					AlertBlock.Visibility = Visibility.Visible;
				}
				else
				{
					if (cyclist.GetBikeSpeed() == 6)
					{
						AlertBlock.Text = "You can't speed up more";
						AlertBlock.Visibility = Visibility.Visible;
					}
					else
					{
						cyclist.PushBike();
						UpdateFields();
					}
				}
			}
		}

		private void SitOnButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() > 0)
			{
				AlertBlock.Text = "You can't sit on bike when it's moving";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else if (!cyclist.GetBikeState())
			{
				AlertBlock.Text = "You can't sit on bike when it's down";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				cyclist.CommandSitStand(true);
				UpdateFields();
			}
		}

		private void StadOffButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() > 0)
			{
				AlertBlock.Text = "You can't stand off bike when it's moving";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				cyclist.CommandSitStand(false);
				UpdateFields();
			}
		}

		private void TurnRightButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.ChangeDir("r");
			UpdateFields();
		}

		private void GoStaightButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.ChangeDir("s");
			UpdateFields();
		}

		private void TurnLeftButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.ChangeDir("l");
			UpdateFields();
		}

		private void PedalButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeState() == false)
			{
				AlertBlock.Text = "You can't pedal bike when it's down";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				if (cyclist.GetOnBike() == false)
				{
					AlertBlock.Text = "You can't pedal bike while you are not on it";
					AlertBlock.Visibility = Visibility.Visible;
				}
					else 
					{
					if (cyclist.GetBikeSpeed() >= cyclist.GetMaxSpeed())
							{
								AlertBlock.Text = "You can't speedup more";
								AlertBlock.Visibility = Visibility.Visible;
							}
							else
							{
								cyclist.PedalBike();
								UpdateFields();
							} 
					}
			}
		}

		private void GentleBrakeButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() == 0)
			{
				AlertBlock.Text = "Bike is not moving";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				cyclist.GentleSlow();
				UpdateFields();
			}
		}

		private void HardBrakeButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() == 0)
			{
				AlertBlock.Text = "Bike is not moving";
				AlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				cyclist.HardSlow();
				UpdateFields();
			}
		}

		private void CyclistNameChangeButton_Click(object sender, RoutedEventArgs e)
		{
			string newname = CyclistNameChange.Text;
			cyclist.SetName(newname);
			CyclistNameBlock.Text = cyclist.GetName();
			CyclistNameChange.Text = "";
			UpdateFields();
			
		}

		private void SaddleDownButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.SaddleDown();
			UpdateFields();
		}

		private void SaddleUpButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.SaddleUp();
			UpdateFields();
		}

		private void SteeringWheelLeftButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.SWAngleLeft();
			UpdateFields();
		}

		private void SteeringWheelRightButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.SWAngleRight();
			UpdateFields();
		}

		private void TirePressureDownButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.TirePressureDown();
			UpdateFields();
		}

		private void TirePressureUpButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.TirePressureUp();
			UpdateFields();
		}

		private void TurnLeverButtonUp_Click(object sender, RoutedEventArgs e)
		{
			cyclist.ShifterUp();
			UpdateFields();
		}

		private void TurnLeverButtonDown_Click(object sender, RoutedEventArgs e)
		{
			cyclist.ShifterDown();
			UpdateFields();
		}

		private void UpdateFields()
		{
			AlertBlock.Visibility = Visibility.Hidden;


			CyclistNameBlock.Text = cyclist.GetName();
			if (cyclist.GetOnBike() == true)
			{
				RiderState.Text = "On bike";
			}
			else RiderState.Text = "Off bike";


			if (cyclist.GetBikeSpeed() == 0)
			{
				BicycleState.Text = "Not moving";
			}
			else if (cyclist.GetBikeSpeed() > 0)
			{
				BicycleState.Text = "Moving";
			}

			if (cyclist.GetBikeState() == false)
			{
				BicycleUpDown.Text = "Down";
			}
			else if (cyclist.GetBikeState() == true)
			{
				BicycleUpDown.Text = "Up";
			}

			SpeedBlock.Text = cyclist.GetBikeSpeed().ToString();

			DirectionBlock.Text = cyclist.GetBikeDirection();

			SaddleHeightBlock.Text = cyclist.GetSaddleHeight().ToString();

			SteeringWheelAngleBlock.Text = cyclist.GetSWAngle().ToString();

			TirePressureBlock.Text = cyclist.GetTirePressure().ToString();

			ShifterModeBlock.Text = cyclist.GetShifterMode().ToString();

			WelcomeNameBlock.Text = cyclist.GetName();

		}


	}
}

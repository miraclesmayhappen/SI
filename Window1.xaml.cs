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
			if (cyclist.GetBikeSpeed() == 0)
			{
				cyclist.SaddleDown();
				UpdateFields();
			}
			else
			{
				SettingAlertBlock.Visibility = Visibility.Visible;
			}
		}

		private void SaddleUpButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() == 0)
			{
				cyclist.SaddleUp();
				UpdateFields();
			}
			else
			{
				SettingAlertBlock.Visibility = Visibility.Visible;
			}
			}

		private void SteeringWheelLeftButton_Click(object sender, RoutedEventArgs e)
		{


			if (cyclist.GetBikeSpeed() == 0)
			{
				cyclist.SWAngleLeft();
				UpdateFields();
			}
			else
			{
				SettingAlertBlock.Visibility = Visibility.Visible;
			}
		}

		private void SteeringWheelRightButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() == 0)
			{
				cyclist.SWAngleRight();
				UpdateFields();
			}
			else
			{
				SettingAlertBlock.Visibility = Visibility.Visible;
			}

		}

		private void TirePressureDownButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() == 0)
			{
				cyclist.TirePressureDown();
				UpdateFields();
			}
			else
			{
				SettingAlertBlock.Visibility = Visibility.Visible;
			}

		}

		private void TirePressureUpButton_Click(object sender, RoutedEventArgs e)
		{
			if (cyclist.GetBikeSpeed() == 0)
			{
				cyclist.TirePressureUp();
				UpdateFields();
			}
			else
			{
				SettingAlertBlock.Visibility = Visibility.Visible;
			}

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

			if (cyclist.GetTirePressure() < 20)
			{
				SWAlertBlock.Text = "Please check your tire pressure";
				SWAlertBlock.Visibility = Visibility.Visible;
			}
			else
			{
				SWAlertBlock.Visibility = Visibility.Collapsed;
			}

			if (cyclist.GetSWAngle() <-10 || cyclist.GetSWAngle() > 10)
			{
				SWAlertBlock.Text = "Please check your steering wheel angle";
				SWAlertBlock.Visibility = Visibility.Visible;
				
			}
			else
			{
				SWAlertBlock.Visibility = Visibility.Collapsed;
			}

			cyclist.SWAndleMaxSpeed();
			SettingAlertBlock.Visibility = Visibility.Hidden;
		}

		private void BikeCyclistStateSpoilerButton_Click(object sender, RoutedEventArgs e)
		{
			if (BikeCyclistStateButtons.Visibility == Visibility.Visible)
			{
				BikeCyclistStateButtons.Visibility = Visibility.Collapsed;
			} else
			if (BikeCyclistStateButtons.Visibility == Visibility.Collapsed)
			{
				BikeCyclistStateButtons.Visibility = Visibility.Visible;
			}
		}

		private void DirectionSpoilerButton_Click(object sender, RoutedEventArgs e)
		{
			if (DirectionButtons.Visibility == Visibility.Visible)
			{
				DirectionButtons.Visibility = Visibility.Collapsed;
			}
			else
			if (DirectionButtons.Visibility == Visibility.Collapsed)
			{
				DirectionButtons.Visibility = Visibility.Visible;
			}
		}

		private void VelocitySpoilerButton_Click(object sender, RoutedEventArgs e)
		{
			if (VelocityButtons.Visibility == Visibility.Visible)
			{
				VelocityButtons.Visibility = Visibility.Collapsed;
			}
			else
			if (VelocityButtons.Visibility == Visibility.Collapsed)
			{
				VelocityButtons.Visibility = Visibility.Visible;
			}
		}

		private void SpeedSettingButton_Click(object sender, RoutedEventArgs e)
		{
			if (SpeedSettingButtons.Visibility == Visibility.Visible)
			{
				SpeedSettingButtons.Visibility = Visibility.Collapsed;
			}
			else
			if (SpeedSettingButtons.Visibility == Visibility.Collapsed)
			{
				SpeedSettingButtons.Visibility = Visibility.Visible;
			}
		}

		private void LeanRightButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.Lean("r");
			UpdateFields();
		}

		private void AlignStaighButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.Lean("s");
			UpdateFields();
		}

		private void LeanLeftButton_Click(object sender, RoutedEventArgs e)
		{
			cyclist.Lean("l");
			UpdateFields();
		}
	}
}

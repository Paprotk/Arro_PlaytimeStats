using System;
using Sims3.Gameplay;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using Sims3.UI.Hud;
using OneShotFunctionTask = Sims3.Gameplay.OneShotFunctionTask;
using System.Collections.Generic;
using System.Text;

namespace Arro
{
	public class Command
	{
		public static void ShowDialogSessionTime()
		{
			try
			{
				NotificationSystem.ShowSessionTime();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ShowDialogSessionTime");
			}
		}

		public static void ShowDialogTotalTime()
		{
			try
			{
				NotificationSystem.ShowTotalNotification();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ShowDialogTotalTime");
			}
		}

		public static void AddSessionToTotalNow()
		{
			try
			{
				TimerMaths.UpdateSessionTimes();
				TimerMaths.CalculateTotalTimes();
				ShowDialogTotalTime();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "AddSessionToTotalNow");
			}
		}
		public static void SetTotalTime()
		{
			try
			{
				bool Continue = TwoButtonDialog.Show(LS.settotaltimewarning, LS.yes, LS.no);
				if (Continue)
				{
					Command.ResetStats();
				
				
				string titleText = LS.settotaltime;
				string[] promptText = new string[]
				{
					LS.setlivemodeseconds,
					LS.setbbmodeseconds,
					LS.setcasseconds
				};
				string[] defaultEntryText = new string[]
				{
					"",
					"",
					""
				};
				bool numbersOnly = true; 

				
				string[] result = ThreeStringInputDialog.Show(titleText, promptText, defaultEntryText, numbersOnly);
				
				int LiveResult = string.IsNullOrEmpty(result[0]) ? 0 : int.TryParse(result[0], out LiveResult) ? LiveResult : 0;
				TimeStats.LiveTotalSeconds = LiveResult;

				int BBResult = string.IsNullOrEmpty(result[1]) ? 0 : int.TryParse(result[1], out BBResult) ? BBResult : 0;
				TimeStats.BBTotalSeconds = BBResult;
				
				int CASResult = string.IsNullOrEmpty(result[2]) ? 0 : int.TryParse(result[2], out CASResult) ? CASResult : 0;
				TimeStats.CASTotalSeconds = CASResult;

				AllTimers.BBtimer.SetElapsedTime(0);
				AllTimers.Livetimer.SetElapsedTime(0);
				TimeStats.TotalSeconds = LiveResult + BBResult + CASResult;
				TimerMaths.CalculateTotalTimes();

				AllTimers.Livetimer.Reset();
				AllTimers.BBtimer.Reset();
				AllTimers.Livetimer.Start();

				NotificationSystem.ShowTotalNotification();
				}		
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "SetTotalTime");
			}
		}


		public static void ResetStats()
		{
			try
			{
				TimerMaths.ClearAlereadyAddedSessionSeconds();
				TimerMaths.ClearElapsedSeconds();
				TimerMaths.ClearSessionSeconds();
				TimerMaths.ClearTotalTimes();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ResetStats");
			}
		}

		public static void OnSave()
		{
			try
			{
				TimerMaths.UpdateSessionTimes();
				TimerMaths.CalculateTotalTimes();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "OnSave");
			}
		}
		public static void TriggerArtificialException()
		{
			try
			{
				// Artificially create a null reference exception
				object obj = null;
				obj.ToString();
			}
			catch (Exception ex)
			{
				// Handle the exception using the ExceptionHandler class
				ExceptionHandler.HandleException(ex, "TriggerArtificialException");
			}
		}
	}
}
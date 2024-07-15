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
	public class TimerMaths
	{

		public static float AlereadyAddedSessionSeconds = 0;

		public static float AlereadyAddedLiveSessionSeconds = 0;

		public static float AlereadyAddedBBSessionSeconds = 0;

		public static float AlereadyAddedCASSessionSeconds = 0;
		

		public static void UpdateSessionTimes()
		{
			try
			{
				AllTimers.LiveSessionSeconds = (int)AllTimers.Livetimer.GetElapsedTimeFloat();
				AllTimers.BBSessionSeconds = (int)AllTimers.BBtimer.GetElapsedTimeFloat();
				AllTimers.CASSessionSeconds = (int)AllTimers.CAStimer.GetElapsedTimeFloat();
				AllTimers.SessionSeconds = AllTimers.LiveSessionSeconds + AllTimers.BBSessionSeconds + AllTimers.CASSessionSeconds;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "UpdateSessionTimes");
			}
		}

		public static void ConvertSessionTimes()
		{
			try
			{
				ConvertLiveSessionSeconds();
				ConvertBBSessionSeconds();
				ConvertCASSessionSeconds();
				ConvertSessionSeconds();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertSessionTimes");
			}
		}

		public static string ConvertLiveSessionSeconds()
		{
			try
			{
				int Lhours = (int)AllTimers.LiveSessionSeconds / 3600;
				int Lminutes = (int)(AllTimers.LiveSessionSeconds % 3600) / 60;
				int Lseconds = (int)AllTimers.LiveSessionSeconds % 60;

				string result = "";
				if (Lhours > 0)
				{
					result += Lhours.ToString() + "h ";
				}
				if (Lminutes > 0 || Lhours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += Lminutes.ToString() + "m ";
				}
				result += Lseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertLiveSessionSeconds");
				return "Error";
			}
		}

		public static string ConvertBBSessionSeconds()
		{
			try
			{
				int Bhours = (int)AllTimers.BBSessionSeconds / 3600;
				int Bminutes = (int)(AllTimers.BBSessionSeconds % 3600) / 60;
				int Bseconds = (int)AllTimers.BBSessionSeconds % 60;

				string result = "";
				if (Bhours > 0)
				{
					result += Bhours.ToString() + "h ";
				}
				if (Bminutes > 0 || Bhours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += Bminutes.ToString() + "m ";
				}
				result += Bseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertBBSessionSeconds");
				return "Error";
			}
		}
		
		public static string ConvertCASSessionSeconds()
		{
			try
			{
				int Chours = (int)AllTimers.CASSessionSeconds / 3600;
				int Cminutes = (int)(AllTimers.CASSessionSeconds % 3600) / 60;
				int Cseconds = (int)AllTimers.CASSessionSeconds % 60;

				string result = "";
				if (Chours > 0)
				{
					result += Chours.ToString() + "h ";
				}
				if (Cminutes > 0 || Chours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += Cminutes.ToString() + "m ";
				}
				result += Cseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertCASSessionSeconds");
				return "Error";
			}
		}

		public static string ConvertSessionSeconds()
		{
			try
			{
				int Shours = (int)AllTimers.SessionSeconds / 3600;
				int Sminutes = (int)(AllTimers.SessionSeconds % 3600) / 60;
				int Sseconds = (int)AllTimers.SessionSeconds % 60;

				string result = "";
				if (Shours > 0)
				{
					result += Shours.ToString() + "h ";
				}
				if (Sminutes > 0 || Shours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += Sminutes.ToString() + "m ";
				}
				result += Sseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertSessionSeconds");
				return "Error";
			}
		}

		public static void CalculateTotalTimes()
		{
			try
			{
				TimeStats.LiveTotalSeconds += AllTimers.LiveSessionSeconds - (int)AlereadyAddedLiveSessionSeconds;
				AlereadyAddedLiveSessionSeconds = AllTimers.LiveSessionSeconds;

				TimeStats.BBTotalSeconds += AllTimers.BBSessionSeconds - (int)AlereadyAddedBBSessionSeconds;
				AlereadyAddedBBSessionSeconds = AllTimers.BBSessionSeconds;
				
				TimeStats.CASTotalSeconds += AllTimers.CASSessionSeconds - (int)AlereadyAddedCASSessionSeconds;
				AlereadyAddedCASSessionSeconds = AllTimers.CASSessionSeconds;

				TimeStats.TotalSeconds += AllTimers.SessionSeconds - (int)AlereadyAddedSessionSeconds;
				AlereadyAddedSessionSeconds = AllTimers.SessionSeconds;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "CalculateTotalTimes");
			}
		}

		public static void ConvertTotalTimes()
		{
			try
			{
				ConvertLiveTotalSeconds();
				ConvertBBTotalSeconds();
				ConvertTotalSeconds();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertTotalTimes");
			}
		}

		public static string ConvertLiveTotalSeconds()
		{
			try
			{
				int LThours = (int)TimeStats.LiveTotalSeconds / 3600;
				int LTminutes = (int)(TimeStats.LiveTotalSeconds % 3600) / 60;
				int LTseconds = (int)TimeStats.LiveTotalSeconds % 60;

				string result = "";
				if (LThours > 0)
				{
					result += LThours.ToString() + "h ";
				}
				if (LTminutes > 0 || LThours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += LTminutes.ToString() + "m ";
				}
				result += LTseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertLiveTotalSeconds");
				return "Error";
			}
		}

		public static string ConvertBBTotalSeconds()
		{
			try
			{
				int BThours = (int)TimeStats.BBTotalSeconds / 3600;
				int BTminutes = (int)(TimeStats.BBTotalSeconds % 3600) / 60;
				int BTseconds = (int)TimeStats.BBTotalSeconds % 60;

				string result = "";
				if (BThours > 0)
				{
					result += BThours.ToString() + "h ";
				}
				if (BTminutes > 0 || BThours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += BTminutes.ToString() + "m ";
				}
				result += BTseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertBBTotalSeconds");
				return "Error";
			}
		}
		
		public static string ConvertCASTotalSeconds()
		{
			try
			{
				int CThours = (int)TimeStats.CASTotalSeconds / 3600;
				int CTminutes = (int)(TimeStats.CASTotalSeconds % 3600) / 60;
				int CTseconds = (int)TimeStats.CASTotalSeconds % 60;

				string result = "";
				if (CThours > 0)
				{
					result += CThours.ToString() + "h ";
				}
				if (CTminutes > 0 || CThours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += CTminutes.ToString() + "m ";
				}
				result += CTseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertCASTotalSeconds");
				return "Error";
			}
		}

		public static string ConvertTotalSeconds()
		{
			try
			{
				int SThours = (int)TimeStats.TotalSeconds / 3600;
				int STminutes = (int)(TimeStats.TotalSeconds % 3600) / 60;
				int STseconds = (int)TimeStats.TotalSeconds % 60;

				string result = "";
				if (SThours > 0)
				{
					result += SThours.ToString() + "h ";
				}
				if (STminutes > 0 || SThours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += STminutes.ToString() + "m ";
				}
				result += STseconds.ToString() + "s";

				return result.Trim();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertTotalSeconds");
				return "Error";
			}
		}

		public static string ConvertTotalPlaycount()
		{
			try
			{
				int TotalPlaycount = (int)TimeStats.TotalPlaycount;
				string newline = "\n";
				newline += TotalPlaycount.ToString();
				return newline;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertTotalPlaycount");
				return "Error";
			}
		}

		public static void ClearTotalTimes()
		{
			try
			{
				TimeStats.LiveTotalSeconds = 0;
				TimeStats.BBTotalSeconds = 0;
				TimeStats.CASTotalSeconds = 0;
				TimeStats.TotalSeconds = 0;
				AlereadyAddedLiveSessionSeconds = 0;
				AlereadyAddedBBSessionSeconds = 0;
				AlereadyAddedCASSessionSeconds = 0;
				AlereadyAddedSessionSeconds = 0;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ClearTotalTimes");
			}
		}

		public static void ClearAlereadyAddedSessionSeconds()
		{
			try
			{
				AlereadyAddedLiveSessionSeconds = 0;
				AlereadyAddedBBSessionSeconds = 0;
				AlereadyAddedCASSessionSeconds = 0;
				AlereadyAddedSessionSeconds = 0;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ClearAlereadyAddedSessionSeconds");
			}
		}

		public static void ClearSessionSeconds()
		{
			try
			{
				AllTimers.LiveSessionSeconds = 0;
				AllTimers.BBSessionSeconds = 0;
				AllTimers.CASSessionSeconds = 0;
				AllTimers.SessionSeconds = 0;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ClearSessionSeconds");
			}
		}

		public static void ClearElapsedSeconds()
		{
			try
			{
				AllTimers.BBtimer.SetElapsedTimeFloat(0);
				AllTimers.Livetimer.SetElapsedTimeFloat(0);
				AllTimers.CAStimer.SetElapsedTimeFloat(0);
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ClearElapsedSeconds");
			}
		}
		
		public static string ConvertAverageLiveSeconds()
		{
			try
			{
				if (TimeStats.LiveCount > 0)
				{
				int AVLhours = (int)TimeStats.LiveTotalSeconds / TimeStats.LiveCount / 3600;
				int AVLminutes = (int)TimeStats.LiveTotalSeconds / TimeStats.LiveCount % 3600 / 60;
				int AVLseconds = (int)TimeStats.LiveTotalSeconds / TimeStats.LiveCount % 60;

				string result = "";
				if (AVLhours > 0)
				{
					result += AVLhours.ToString() + "h ";
				}
				if (AVLminutes > 0 || AVLhours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += AVLminutes.ToString() + "m ";
				}
				result += AVLseconds.ToString() + "s";

				return result.Trim();	
				}
				string resultNA = "N/A";
				return resultNA.Trim();

			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertAverageLiveSeconds");
				return "Error";
			}
		}
		public static string ConvertAverageBBSeconds()
		{
			try
			{
				if (TimeStats.BBCount > 0)
				{
				int AVBBhours = (int)TimeStats.BBTotalSeconds / TimeStats.BBCount / 3600;
				int AVBBminutes = (int)TimeStats.BBTotalSeconds / TimeStats.BBCount % 3600 / 60;
				int AVBBseconds = (int)TimeStats.BBTotalSeconds / TimeStats.BBCount % 60;

				string result = "";
				if (AVBBhours > 0)
				{
					result += AVBBhours.ToString() + "h ";
				}
				if (AVBBminutes > 0 || AVBBhours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += AVBBminutes.ToString() + "m ";
				}
				result += AVBBseconds.ToString() + "s";

				return result.Trim();
				}
				string resultNA = "N/A";
				return resultNA.Trim();

			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertAverageBBSeconds");
				return "Error";
			}
		}
		public static string ConvertAverageCASSeconds()
		{
			try
			{
				if (TimeStats.CASCount > 0)
				{
				int AVCAShours = (int)TimeStats.CASTotalSeconds / TimeStats.CASCount / 3600;
				int AVCASminutes = (int)TimeStats.CASTotalSeconds / TimeStats.CASCount % 3600 / 60;
				int AVCASseconds = (int)TimeStats.CASTotalSeconds / TimeStats.CASCount % 60;

				string result = "";
				if (AVCAShours > 0)
				{
					result += AVCAShours.ToString() + "h ";
				}
				if (AVCASminutes > 0 || AVCAShours > 0) // Show minutes if hours are shown, even if minutes are 0
				{
					result += AVCASminutes.ToString() + "m ";
				}
				result += AVCASseconds.ToString() + "s";

				return result.Trim();
				}
				string resultNA = "N/A";
				return resultNA.Trim();
			}

			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ConvertAverageCASSeconds");
				return "Error";
			}
		}
			
		public static void AddTravelCount()
		{
			if (!TimeStats.HasAddedTravelCount)
			{
			TimeStats.TravelCount += 1;
			TimeStats.HasAddedTravelCount = true;
			}
		}
	}
}

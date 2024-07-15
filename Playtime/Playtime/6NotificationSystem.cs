using System;
using Sims3.Gameplay;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using Sims3.UI.Hud;
using Sims3.Gameplay.UI;
using OneShotFunctionTask = Sims3.Gameplay.OneShotFunctionTask;
using System.Collections.Generic;
using System.Text;

namespace Arro
{
	public class NotificationSystem
	{
		public static void ShowTotalNotification()
		{
			try
			{
				TimerMaths.ConvertSessionTimes();
				TimerMaths.ConvertTotalPlaycount();
				string convertedTotalLiveSeconds = TimerMaths.ConvertLiveTotalSeconds();
				string convertedTotalBBSeconds = TimerMaths.ConvertBBTotalSeconds();
				string convertedTotalCASSeconds = TimerMaths.ConvertCASTotalSeconds();
				string convertedTotalSeconds = TimerMaths.ConvertTotalSeconds();
				string convertedPlaycount = TimerMaths.ConvertTotalPlaycount();

				string TotalPlaytimeString = LS.playtime + "\n";

				TotalPlaytimeString += convertedTotalSeconds + " " + LS.intotal;


				if (TimeStats.ShowLiveStats)
				{
					TotalPlaytimeString += "\n" + convertedTotalLiveSeconds + " " + LS.inlivemode;
				}
				if (TimeStats.ShowBBStats)
				{
					TotalPlaytimeString += "\n" + convertedTotalBBSeconds + " " + LS.inbbmode;
				}
				if (TimeStats.ShowCASStats)
				{
					TotalPlaytimeString += "\n" + convertedTotalCASSeconds + " " + LS.incas;
				}
				if (TimeStats.ShowPlaycount)
				{
					string playcounttext = "\n";
					if (TimeStats.TotalPlaycount < 2)
					{
						playcounttext += String.Format(LS.youveplayed + " {0} " + LS.once, TimeStats.TotalPlaycount);
					}
					else
					{
						playcounttext += String.Format(LS.youveplayed + " {0} " + LS.times, TimeStats.TotalPlaycount);
					}
					TotalPlaytimeString += playcounttext;
				}

				if (TimeStats.TotalSeconds > 0)
				{
					StyledNotification.Format format = new StyledNotification.Format(TotalPlaytimeString, StyledNotification.NotificationStyle.kGameMessagePositive);
					StyledNotification.Show(format, "arro_playtime_icon");
				}
				else
				{
					if (!TimeStats.HasRunSetup) // Show initial setup only once, when total seconds are 0
					{
						SimpleMessageDialog.Show(LS.playtimestatstitle, LS.noplaytimestats);
						Simulator.AddObject(new OneShotFunctionTask(NotificationSystem.SetupLive, StopWatch.TickStyles.Seconds, 1f));
						TimeStats.HasRunSetup = true;
					}
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ShowTotalNotification");
			}
		}

		public static void SetupLive()
		{
			try
			{
				bool ShowLiveStatsTrue = TwoButtonDialog.Show(LS.doyouwanttoshowlivestats, LS.yes, LS.no);
				if (ShowLiveStatsTrue)
				{
					TimeStats.ShowLiveStats = true;
				}
				else
				{
					TimeStats.ShowLiveStats = false;
				}
				SetupBB();
				return;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "SetupLive");
			}

		}
		public static void SetupBB()
		{
			try
			{
				bool ShowBBStatsTrue = TwoButtonDialog.Show(LS.doyouwanttoshowbbstats, LS.yes, LS.no);
				if (ShowBBStatsTrue)
				{
					TimeStats.ShowBBStats = true;
				}
				else
				{
					TimeStats.ShowBBStats = false;
				}
				SetupCAS();
				return;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "SetupBB");
			}

		}
		public static void SetupCAS()
		{
			try
			{
				bool ShowCASStatsTrue = TwoButtonDialog.Show(LS.doyouwanttoshowcasstats, LS.yes, LS.no);
				if (ShowCASStatsTrue)
				{
					TimeStats.ShowCASStats = true;
				}
				else
				{
					TimeStats.ShowCASStats = false;
				}
				SetupShowPlaycount();
				return;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "SetupCAS");
			}

		}

		public static void SetupShowPlaycount()
		{
			try
			{
				bool ShowPlaycountTrue = TwoButtonDialog.Show(LS.showplaycount, LS.yes, LS.no);
				if (ShowPlaycountTrue)
				{
					TimeStats.ShowPlaycount = true;
				}
				else
				{
					TimeStats.ShowPlaycount = false;
				}
				ReportCurrentSettings();
				return;
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "SetupShowPlaycount");
			}
		}

		public static void ReportCurrentSettings()
		{
			try
			{
				string currentSettings = String.Format(
					"{0}\n{1} = {2}\n{3} = {4}\n{5} = {6}\n{7} = {8}",
					LS.currentsettings,
					LS.livestats, TimeStats.ShowLiveStats,
					LS.bbstats, TimeStats.ShowBBStats,
					LS.casstats, TimeStats.ShowCASStats,
					LS.playcount, TimeStats.ShowPlaycount
				);

				StyledNotification.Format format = new StyledNotification.Format(
					currentSettings,
					StyledNotification.NotificationStyle.kGameMessagePositive
				);

				StyledNotification.Show(format, "arro_settings_icon");
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ReportCurrentSettings");
			}
		}


		public static void ShowSessionTime()
		{
			try
			{
				// Update and convert session times
				TimerMaths.UpdateSessionTimes();
				TimerMaths.ConvertSessionTimes();

				// Retrieve converted session times
				string convertedLiveSession = TimerMaths.ConvertLiveSessionSeconds();
				string convertedBBSession = TimerMaths.ConvertBBSessionSeconds();
				string convertedCASSession = TimerMaths.ConvertCASSessionSeconds();
				string convertedSession = TimerMaths.ConvertSessionSeconds();

				// Format the notification string
				string sessionnotif = string.Format(
					"{0}:\n{1} {2}\n{3} {4}\n{5} {6}\n{7} {8}",
					LS.sessionplaytime,
					convertedSession, LS.inthissession,
					convertedLiveSession, LS.inlivemode,
					convertedBBSession, LS.inbbmode,
					convertedCASSession, LS.incas
				);

				// Create and show the notification
				StyledNotification.Format format = new StyledNotification.Format(
					sessionnotif,
					StyledNotification.NotificationStyle.kGameMessagePositive
				);
				StyledNotification.Show(format, "arro_playtime_icon");
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ShowSessionTime");
			}
		}


		public static void ShowComprehensiveStats()
		{
			try
			{
				// Update and convert times
				TimerMaths.UpdateSessionTimes();
				TimerMaths.ConvertSessionTimes();
				TimerMaths.ConvertTotalPlaycount();

				
				float livePercentage = (TimeStats.LiveTotalSeconds / TimeStats.TotalSeconds) * 100;
				float bbPercentage = (TimeStats.BBTotalSeconds / TimeStats.TotalSeconds) * 100;
				float casPercentage = (TimeStats.CASTotalSeconds / TimeStats.TotalSeconds) * 100;
				float liveSessionPercentage = (AllTimers.LiveSessionSeconds / AllTimers.SessionSeconds) * 100;
				float bbSessionPercentage = (AllTimers.BBSessionSeconds / AllTimers.SessionSeconds) * 100;
				float casSessionPercentage = (AllTimers.CASSessionSeconds / AllTimers.SessionSeconds) * 100;

				
				string convertedTotalLiveSeconds = TimerMaths.ConvertLiveTotalSeconds();
				string convertedTotalBBSeconds = TimerMaths.ConvertBBTotalSeconds();
				string convertedTotalCASSeconds = TimerMaths.ConvertCASTotalSeconds();
				string convertedTotalSeconds = TimerMaths.ConvertTotalSeconds();
				
				
				string convertedPlaycount = TimerMaths.ConvertTotalPlaycount();
				
				
				string convertedLiveSession = TimerMaths.ConvertLiveSessionSeconds();
				string convertedBBSession = TimerMaths.ConvertBBSessionSeconds();
				string convertedCASSession = TimerMaths.ConvertCASSessionSeconds();
				string convertedSession = TimerMaths.ConvertSessionSeconds();
				
				
				string convertedAverageLiveTime = TimerMaths.ConvertAverageLiveSeconds();
				string convertedAverageBBTime = TimerMaths.ConvertAverageBBSeconds();
				string convertedAverageCASTime = TimerMaths.ConvertAverageCASSeconds();

				string totals = string.Format("{0} {1}\n{2} {3}\n{4} {5}\n{6} {7}\n",
				                              convertedTotalSeconds, LS.intotal,
				                              convertedTotalLiveSeconds, LS.inlivemode,
				                              convertedTotalBBSeconds, LS.inbbmode,
				                              convertedTotalCASSeconds, LS.incas);
				
				string totalPercentages = string.Format("{3}\n {0:F1}% {1:F1}% {2:F1}% \n\n",
				                                        livePercentage,
				                                        bbPercentage,
				                                        casPercentage,
				                                        LS.totallivebuildcas);

				string thisSession = string.Format("{0} {1}\n{2} {3}\n{4} {5}\n{6} {7}\n",
				                                   convertedSession, LS.inthissession,
				                                   convertedLiveSession, LS.inlivemode,
				                                   convertedBBSession, LS.inbbmode,
				                                   convertedCASSession, LS.incas);

				string sessionPercentages = string.Format("{3}\n {0:F1}% {1:F1}% {2:F1}% \n",
				                                          liveSessionPercentage,
				                                          bbSessionPercentage,
				                                          casSessionPercentage,
				                                          LS.sessionlivebuildcas);

				string playCountText;
				if (TimeStats.TotalPlaycount < 2)
				{
					playCountText = string.Format("{0} {1} {2}", LS.youveplayed, TimeStats.TotalPlaycount, LS.once);
				}
				else
				{
					playCountText = string.Format("{0} {1} {2}", LS.youveplayed, TimeStats.TotalPlaycount, LS.times);
				}
				
				string averageTimes = string.Format("{0} {1}: {2}\n{3} {4}: {5}\n{6} {7}: {8}\n",
				                                    LS.averagetimespent, LS.inlivemode, convertedAverageLiveTime,
				                                    LS.averagetimespent, LS.inbbmode, convertedAverageBBTime,
				                                    LS.averagetimespent, LS.incas, convertedAverageCASTime);
				
				string travelCountText = "";
				string newlineTC = "";
				if (TimeStats.TravelCount == 0)
				{
					travelCountText += string.Format("");
					newlineTC += string.Format("\n");				
				}
				
				if (TimeStats.TravelCount == 1)
				{
					travelCountText += string.Format("\n{0} {1} {2}\n", LS.youvetraveled, TimeStats.TravelCount, LS.once);
				}
				if (TimeStats.TravelCount > 1)
				{
					travelCountText += string.Format("\n{0} {1} {2}\n", LS.youvetraveled, TimeStats.TravelCount, LS.times);
				}
				
				string divider = "--------------------------------------------------------------\n";
				
				// Combine all stats into one comprehensive string
				string comprehensiveStats = divider + totals + "\n" + totalPercentages + averageTimes + divider + thisSession + "\n" + sessionPercentages + divider +  playCountText + newlineTC + travelCountText + divider;

				// Deprecated
				//SimpleMessageDialog.Show(LS.showcomprehensivestats, comprehensiveStats);
				
				//Show modal
				Comprehensive comprehensiveInstance = new Comprehensive();
				comprehensiveInstance.dialog = new TwoButtonDialog(
					comprehensiveStats,  // Set dialog text
					"",
					Localization.LocalizeString("Ui/Caption/Global:Ok", new object[0]),
					true,
					true,
					new Vector2(0f, 0f),
					true
				);

				comprehensiveInstance.text = comprehensiveInstance.dialog.ModalDialogWindow.GetChildByID(1U, false) as Text;
				(comprehensiveInstance.dialog.ModalDialogWindow.GetChildByID(2U, false) as Button).Visible = false;
				comprehensiveInstance.dialog.StartModal(true);
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "ShowComprehensiveStats");
			}
		}

		public class Comprehensive
		{
			public TwoButtonDialog dialog;
			public Text text;
		}

	}

}


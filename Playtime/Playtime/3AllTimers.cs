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
	public class AllTimers
	{

		public static float SessionSeconds = 0;

		public static float LiveSessionSeconds = 0;

		public static float BBSessionSeconds = 0;

		public static float CASSessionSeconds = 0;

		public static bool HasShownTotalPlaytime = false;
		public static bool HasCreatedTimer = false;
		public static StopWatch Livetimer;
		public static StopWatch BBtimer;
		public static StopWatch CAStimer;

		internal static void OnGameStateChanged(Sims3.UI.Responder.GameSubState previousState, Sims3.UI.Responder.GameSubState newState)
		{
			try
			{
				//BB
				if (newState == Sims3.UI.Responder.GameSubState.BuildMode || newState == Sims3.UI.Responder.GameSubState.BuyMode)
				{

					if (Livetimer.IsRunning())
					{
						Livetimer.Stop();
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("Stopped live timer.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}
					if (CAStimer.IsRunning())
					{
						CAStimer.Stop();
					}

					if (!BBtimer.IsRunning())
					{
						BBtimer.Start();
						TimeStats.BBCount += 1;
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("BB timer running.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}
				}
				//Live
				if (newState == Sims3.UI.Responder.GameSubState.LiveMode)
				{
					if (BBtimer.IsRunning())
					{
						BBtimer.Stop();
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("Stopped bb timer.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}
					if (CAStimer.IsRunning())
					{
						CAStimer.Stop();
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("Stopped CAS timer.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}

					if (!Livetimer.IsRunning())
					{
						Livetimer.Start();
						TimeStats.LiveCount += 1;
						if (!HasShownTotalPlaytime)
						{
							Simulator.AddObject(new OneShotFunctionTask(Arro.NotificationSystem.ShowTotalNotification, StopWatch.TickStyles.Seconds, 10f));
							HasShownTotalPlaytime = true;
						}
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("Live timer running.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}
				}
				//CAS
				if (newState == Sims3.UI.Responder.GameSubState.CASFullMode || newState == Sims3.UI.Responder.GameSubState.CASMirrorMode || newState == Sims3.UI.Responder.GameSubState.CASTackMode || newState == Sims3.UI.Responder.GameSubState.CASDresserMode ||newState == Sims3.UI.Responder.GameSubState.CASTattooMode || newState == Sims3.UI.Responder.GameSubState.CASStylistMode || newState == Sims3.UI.Responder.GameSubState.CASCollarMode || newState == Sims3.UI.Responder.GameSubState.CASSurgeryFaceMode || newState == Sims3.UI.Responder.GameSubState.CASSurgeryBodyMode)
				{
					if (BBtimer.IsRunning())
					{
						BBtimer.Stop();
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("Stopped bb timer.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}
					if (Livetimer.IsRunning())
					{
						Livetimer.Stop();
						if (PlayTime.Debugging)
						{
							StyledNotification.Format format = new StyledNotification.Format("Stopped live timer.", StyledNotification.NotificationStyle.kGameMessagePositive);
							StyledNotification.Show(format, "arro_debug");
						}
					}
					CAStimer.Start();
					if (PlayTime.Debugging)
					{
						StyledNotification.Format format = new StyledNotification.Format("CAS timer running.", StyledNotification.NotificationStyle.kGameMessagePositive);
						StyledNotification.Show(format, "arro_debug");
					}
					TimeStats.CASCount += 1;
					
				}
				//Edit Town
				if (newState == Sims3.UI.Responder.GameSubState.EditTown)
				{
					if (Livetimer.IsRunning())
					{
						Livetimer.Stop();
					}
					if (BBtimer.IsRunning())
					{
						BBtimer.Stop();
					}
					if (CAStimer.IsRunning())
					{
						CAStimer.Stop();
					}
					if (PlayTime.Debugging)
					{
					StyledNotification.Format format = new StyledNotification.Format("Stopped all timers.", StyledNotification.NotificationStyle.kGameMessagePositive);
					StyledNotification.Show(format, "arro_debug");	
					}
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "OnGameStateChanged");
			}
		}

		internal static void InitTimers()
		{
			try
			{
				if (!HasCreatedTimer) // assuming new save/load instance and not travel
				{
					Livetimer = StopWatch.Create(StopWatch.TickStyles.Seconds);
					BBtimer = StopWatch.Create(StopWatch.TickStyles.Seconds);
					CAStimer = StopWatch.Create(StopWatch.TickStyles.Seconds);
					HasCreatedTimer = true;
					TimeStats.TotalPlaycount += 1;
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "InitTimers");
			}
		}

		internal static void DisposeTimers()
		{
			try
			{
				Livetimer.Dispose();
				BBtimer.Dispose();
				CAStimer.Dispose();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "DisposeTimers");
			}
		}

		internal static void StopTimers()
		{
			try
			{
				Livetimer.Stop();
				BBtimer.Stop();
				CAStimer.Stop();
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "StopTimers");
			}
		}
	}
}

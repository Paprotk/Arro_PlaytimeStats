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
    public class PlayTime
    {
        [Tunable]
        public static bool kInstantiator = false;
        [Tunable]
        public static bool Debugging = false;

        static PlayTime()
        {
            World.sOnWorldLoadFinishedEventHandler += new EventHandler(OnWorldLoadFinished);
            World.sOnStartupAppEventHandler += new EventHandler(OnStartupApp);
            World.sOnWorldQuitEventHandler += new EventHandler(OnWorldQuit);
            World.sOnWorldLoadStartedEventHandler += new EventHandler(OnWorldLoadStarted);
            LoadSaveManager.ObjectGroupSaving += core_OnSave;
        }

        private static void OnStartupApp(object sender, EventArgs e)
        {
            try
            {
                Commands.sGameCommands.Register("stt", "Usage: show total time.", Commands.CommandType.General, new CommandHandler(core_ShowDialogTotalTime));
                Commands.sGameCommands.Register("tae", "Triggers artificial exception.", Commands.CommandType.General, new CommandHandler(core_TriggerArtificialException));
                Commands.sGameCommands.Register("sst", "Usage: show session.", Commands.CommandType.General, new CommandHandler(core_ShowDialogSessionTime));
                Commands.sGameCommands.Register("SetTotalTime", "Usage: Allows user to set total time.", Commands.CommandType.General, new CommandHandler(core_SetTotalTime));
                Commands.sGameCommands.Register("astt", "Usage: adds current session time to total.", Commands.CommandType.General, new CommandHandler(core_AddSessionToTotalNow));
                Commands.sGameCommands.Register("sds", "Usage: setup detailed stats.", Commands.CommandType.General, new CommandHandler(core_SetupDetailedStats));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "OnStartupApp");
            }
        }

        private static void OnWorldLoadFinished(object sender, EventArgs e)
        {
            try
            {
                bool flag = Sims3.Gameplay.UI.Responder.Instance != null;
                if (flag)
                {
                    Sims3.Gameplay.UI.Responder instance = Sims3.Gameplay.UI.Responder.Instance;
                    instance.GameStateChanging = (GameStateChangingDelegate)Delegate.Remove(instance.GameStateChanging, new GameStateChangingDelegate(AllTimers.OnGameStateChanged));
                    Sims3.Gameplay.UI.Responder instance2 = Sims3.Gameplay.UI.Responder.Instance;
                    instance2.GameStateChanging = (GameStateChangingDelegate)Delegate.Combine(instance2.GameStateChanging, new GameStateChangingDelegate(AllTimers.OnGameStateChanged));
                }
                core_TimerInit();
                Simulator.AddObject(new OneShotFunctionTask(core_WorldChecker, StopWatch.TickStyles.Seconds, 1f)); 
                new MailboxInteraction();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "OnWorldLoadFinished");
            }
        }

        private static void OnWorldQuit(object sender, EventArgs e)
        {
            try
            {
                if (!GameStates.IsTravelling) // if not traveling clear 
                {
                    AllTimers.DisposeTimers();
                    TimerMaths.ClearTotalTimes();
                    AllTimers.HasCreatedTimer = false;
                    AllTimers.HasShownTotalPlaytime = false;
                    TimeStats.HasRunSetup = false;
                    TimeStats.HasAddedTravelCount = false;
                    TimeStats.TotalPlaycount = 0;
                    TimeStats.LiveCount = 0;
                    TimeStats.BBCount = 0;
                    TimeStats.CASCount = 0;
                    TimeStats.TravelCount = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "OnWorldQuit");
            }
        }

        private static void OnWorldLoadStarted(object sender, EventArgs e)
        {
            try
            {
                if (GameStates.IsTravelling)
                {
                    AllTimers.StopTimers();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "OnWorldLoadStarted");
            }
        }
        
        private static void core_TravelChecker()
        {
            try
            {
            	if (GameUtils.IsUniversityWorld() || GameUtils.IsUniversityWorld() || GameUtils.IsOnVacation())
                {
                   Simulator.AddObject(new OneShotFunctionTask(TimerMaths.AddTravelCount, StopWatch.TickStyles.Seconds, 1f)); 
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_TravelChecker");
            }
        }
        private static void core_WorldChecker()
        {
            try
            {
				if (GameUtils.IsAnyTravelBasedWorld())
                {
				core_TravelChecker();	
                }
                else
                {
                	TimeStats.HasAddedTravelCount = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_WorldChecker");
            }
        }
        
        private static int core_ShowDialogTotalTime(object[] parameters)
        {
            try
            {
                Arro.Command.ShowDialogTotalTime();
                return 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_ShowDialogTotalTime");
                return 0;
            }
        }

        private static int core_ShowDialogSessionTime(object[] parameters)
        {
            try
            {
                Arro.Command.ShowDialogSessionTime();
                return 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_ShowDialogSessionTime");
                return 0;
            }
        }

        private static int core_AddSessionToTotalNow(object[] parameters)
        {
            try
            {
                Arro.Command.AddSessionToTotalNow();
                return 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_AddSessionToTotalNow");
                return 0;
            }
        }

        private static int core_SetTotalTime(object[] parameters)
        {
            try
            {
                Simulator.AddObject(new OneShotFunctionTask(Command.SetTotalTime, StopWatch.TickStyles.Seconds, 1f));
                return 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_SetTotalTime");
                return 0;
            }
        }

        private static int core_SetupDetailedStats(object[] parameters)
        {
            try
            {
                Simulator.AddObject(new OneShotFunctionTask(NotificationSystem.SetupLive, StopWatch.TickStyles.Seconds, 1f));
                return 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_SetupDetailedStats");
                return 0;
            }
        }

        private static int core_TriggerArtificialException(object[] parameters)
        {
            try
            {
                Arro.Command.TriggerArtificialException();
                return 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_TriggerArtificialException");
                return 0;
            }
        }

        private static void core_TimerInit()
        {
            try
            {
                Arro.AllTimers.InitTimers();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_TimerInit");
            }
        }

        private static void core_OnSave(IScriptObjectGroup group)
        {
            try
            {
                Arro.Command.OnSave();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "core_OnSave");
            }
        }
    }
}

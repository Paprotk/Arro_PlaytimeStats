using System;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.SimIFace;
using Sims3.Gameplay.Objects.Miscellaneous; // Needed for the Mailbox class
using System.Collections.Generic;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.ActiveCareer;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Utilities;
using Sims3.UI;
using OneShotFunctionTask = Sims3.Gameplay.OneShotFunctionTask;

namespace Arro
{
    public class MailboxInteraction
    {
        // Constructor or initializer to add interactions to all mailbox objects
        public MailboxInteraction()
        {
            foreach (Mailbox obj in Sims3.Gameplay.Queries.GetObjects<Mailbox>())
            {
                AddInteraction(obj);
            }
        }

        // Method to add interaction to a GameObject
        public static void AddInteraction(GameObject obj)
        {
        	if (obj == null)
			{
				return;
			}
        	try{
        	obj.AddInteraction(MailboxSetupInteraction.Singleton);
            obj.AddInteraction(MailboxSessionInteraction.Singleton);
            obj.AddInteraction(MailboxTotalInteraction.Singleton);
            obj.AddInteraction(MailboxComprehensiveInteraction.Singleton);
            obj.AddInteraction(MailboxSetTotalInteraction.Singleton);
        	}
        	catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex, "AddInteraction");
			}

        }

        // Sealed class representing the mailbox interaction
        public sealed class MailboxSetupInteraction : ImmediateInteraction<Sim, GameObject>
        {
            // Definition class for the interaction
            public sealed class Definition : InteractionDefinition<Sim, GameObject, MailboxSetupInteraction>
            {
                // Test method to determine if the interaction can be performed
                public override bool Test(Sim actor, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                        return true;
                }

                // Method to get the interaction name
                public override string GetInteractionName(Sim actor, GameObject target, InteractionObjectPair iop)
                {
                    return LS.mailboxsetup;
                }

                // Method to get the interaction path
                public override string[] GetPath(bool isFemale)
                {
                	return new string[1] { "Playtime" };
                }
            }

            // Singleton instance of the interaction definition
            public static readonly InteractionDefinition Singleton = new Definition();

            // Override Run method for the interaction behavior
            public override bool Run()
            {
                NotificationSystem.SetupLive();
                return true;
            }
        }
        
        public sealed class MailboxSessionInteraction : ImmediateInteraction<Sim, GameObject>
        {
            // Definition class for the interaction
            public sealed class Definition : InteractionDefinition<Sim, GameObject, MailboxSessionInteraction>
            {
                // Test method to determine if the interaction can be performed
                public override bool Test(Sim actor, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                        return true;
                }

                // Method to get the interaction name
                public override string GetInteractionName(Sim actor, GameObject target, InteractionObjectPair iop)
                {
                	return LS.showsessiontime;
                }

                // Method to get the interaction path
                public override string[] GetPath(bool isFemale)
                {
                	return new string[2] { "Playtime" , LS.showdotdotdot };
                }
            }

            // Singleton instance of the interaction definition
            public static readonly InteractionDefinition Singleton = new Definition();

            // Override Run method for the interaction behavior
            public override bool Run()
            { 
            	Simulator.AddObject(new OneShotFunctionTask(NotificationSystem.ShowSessionTime, StopWatch.TickStyles.Seconds, 1f));
                return true;
            }
        }
        
        public sealed class MailboxTotalInteraction : ImmediateInteraction<Sim, GameObject>
        {
            // Definition class for the interaction
            public sealed class Definition : InteractionDefinition<Sim, GameObject, MailboxTotalInteraction>
            {
                // Test method to determine if the interaction can be performed
                public override bool Test(Sim actor, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                        return true;
                }

                // Method to get the interaction name
                public override string GetInteractionName(Sim actor, GameObject target, InteractionObjectPair iop)
                {
                	return LS.showtotaltime;
                }

                // Method to get the interaction path
                public override string[] GetPath(bool isFemale)
                {
                	return new string[2] { "Playtime" , LS.showdotdotdot };
                }
            }

            // Singleton instance of the interaction definition
            public static readonly InteractionDefinition Singleton = new Definition();

            // Override Run method for the interaction behavior
            public override bool Run()
            { 
            	Command.OnSave();
            	Simulator.AddObject(new OneShotFunctionTask(NotificationSystem.ShowTotalNotification, StopWatch.TickStyles.Seconds, 1f));
                return true;
            }
        }
        public sealed class MailboxComprehensiveInteraction : ImmediateInteraction<Sim, GameObject>
        {
            // Definition class for the interaction
            public sealed class Definition : InteractionDefinition<Sim, GameObject, MailboxComprehensiveInteraction>
            {
                // Test method to determine if the interaction can be performed
                public override bool Test(Sim actor, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                        return true;
                }

                // Method to get the interaction name
                public override string GetInteractionName(Sim actor, GameObject target, InteractionObjectPair iop)
                {
                	return LS.showcomprehensivestats;
                }

                // Method to get the interaction path
                public override string[] GetPath(bool isFemale)
                {
                	return new string[2] { "Playtime" , LS.showdotdotdot };
                }
            }

            // Singleton instance of the interaction definition
            public static readonly InteractionDefinition Singleton = new Definition();

            // Override Run method for the interaction behavior
            public override bool Run()
            { 
            	Command.OnSave();
            	Simulator.AddObject(new OneShotFunctionTask(NotificationSystem.ShowComprehensiveStats, StopWatch.TickStyles.Seconds, 1f));
                return true;
            }
        }
        public sealed class MailboxSetTotalInteraction : ImmediateInteraction<Sim, GameObject>
        {
            // Definition class for the interaction
            public sealed class Definition : InteractionDefinition<Sim, GameObject, MailboxSetTotalInteraction>
            {
                // Test method to determine if the interaction can be performed
                public override bool Test(Sim actor, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                        return true;
                }

                // Method to get the interaction name
                public override string GetInteractionName(Sim actor, GameObject target, InteractionObjectPair iop)
                {
                	return LS.settotaltime;
                }

                // Method to get the interaction path
                public override string[] GetPath(bool isFemale)
                {
                	return new string[1] { "Playtime" };
                }
            }

            // Singleton instance of the interaction definition
            public static readonly InteractionDefinition Singleton = new Definition();

            // Override Run method for the interaction behavior
            public override bool Run()
            { 
            	Simulator.AddObject(new OneShotFunctionTask(Command.SetTotalTime, StopWatch.TickStyles.Seconds, 1f));
                return true;
            }
        }   
    }
}
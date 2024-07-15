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

	public class LS
	{
		//Basic
        public static string yes = Localization.LocalizeString(false, "Arro/PlayTime/Local:yes", new object[0]);
        public static string no = Localization.LocalizeString(false, "Arro/PlayTime/Local:no", new object[0]);
        public static string and = Localization.LocalizeString(false, "Arro/PlayTime/Local:and", new object[0]);
        //modes
        public static string playtime = Localization.LocalizeString(false, "Arro/PlayTime/Local:playtime", new object[0]);
        public static string intotal = Localization.LocalizeString(false, "Arro/PlayTime/Local:intotal", new object[0]);
        public static string inlivemode = Localization.LocalizeString(false, "Arro/PlayTime/Local:inlivemode", new object[0]);
        public static string inbbmode = Localization.LocalizeString(false, "Arro/PlayTime/Local:inbbmode", new object[0]);
        public static string incas = Localization.LocalizeString(false, "Arro/PlayTime/Local:incas", new object[0]);
        //Infos
        public static string playtimestatstitle = Localization.LocalizeString(false, "Arro/PlayTime/Local:playtimestatstitle", new object[0]);
        public static string noplaytimestats = Localization.LocalizeString(false, "Arro/PlayTime/Local:noplaytimestats", new object[0]);
        //Setup
        public static string doyouwanttoshowlivestats = Localization.LocalizeString(false, "Arro/PlayTime/Local:doyouwanttoshowlivestats", new object[0]);
        public static string doyouwanttoshowbbstats = Localization.LocalizeString(false, "Arro/PlayTime/Local:doyouwanttoshowbbstats", new object[0]);
        public static string doyouwanttoshowcasstats = Localization.LocalizeString(false, "Arro/PlayTime/Local:doyouwanttoshowcasstats", new object[0]);
        public static string showplaycount = Localization.LocalizeString(false, "Arro/PlayTime/Local:showplaycount", new object[0]);
        //Current settings
        public static string currentsettings = Localization.LocalizeString(false, "Arro/PlayTime/Local:currentsettings", new object[0]);
        public static string livestats = Localization.LocalizeString(false, "Arro/PlayTime/Local:livestats", new object[0]);
        public static string bbstats = Localization.LocalizeString(false, "Arro/PlayTime/Local:bbstats", new object[0]);
        public static string casstats = Localization.LocalizeString(false, "Arro/PlayTime/Local:casstats", new object[0]);
        public static string playcount = Localization.LocalizeString(false, "Arro/PlayTime/Local:playcount", new object[0]);
        //Current session
        public static string sessionplaytime = Localization.LocalizeString(false, "Arro/PlayTime/Local:sessionplaytime", new object[0]);  
		public static string inthissession = Localization.LocalizeString(false, "Arro/PlayTime/Local:inthissession", new object[0]);
		//interaction name
		public static string mailboxsetup = Localization.LocalizeString(false, "Arro/PlayTime/Local:mailboxsetup", new object[0]);
		public static string showdotdotdot = Localization.LocalizeString(false, "Arro/PlayTime/Local:showdotdotdot", new object[0]);
		public static string showsessiontime = Localization.LocalizeString(false, "Arro/PlayTime/Local:showsessiontime", new object[0]);
		public static string showtotaltime = Localization.LocalizeString(false, "Arro/PlayTime/Local:showtotaltime", new object[0]);
		public static string settotaltime = Localization.LocalizeString(false, "Arro/PlayTime/Local:settotaltime", new object[0]);
		public static string showcomprehensivestats = Localization.LocalizeString(false, "Arro/PlayTime/Local:showcomprehensivestats", new object[0]);
		//comprehensive stats
		public static string totaltimespentingame = Localization.LocalizeString(false, "Arro/PlayTime/Local:totaltimespentingame", new object[0]);
		public static string fromtotaltime = Localization.LocalizeString(false, "Arro/PlayTime/Local:fromtotaltime", new object[0]);
		public static string fromsessiontime = Localization.LocalizeString(false, "Arro/PlayTime/Local:fromsessiontime", new object[0]);
		public static string inlivemode2 = Localization.LocalizeString(false, "Arro/PlayTime/Local:inlivemode2", new object[0]);
        public static string inbbmode2 = Localization.LocalizeString(false, "Arro/PlayTime/Local:inbbmode2", new object[0]);
        public static string youveplayed = Localization.LocalizeString(false, "Arro/PlayTime/Local:youveplayed", new object[0]);
        public static string youvetraveled = Localization.LocalizeString(false, "Arro/PlayTime/Local:youvetraveled", new object[0]);
        public static string once = Localization.LocalizeString(false, "Arro/PlayTime/Local:once", new object[0]);
        public static string averagetimespent = Localization.LocalizeString(false, "Arro/PlayTime/Local:averagetimespent", new object[0]);
        public static string times = Localization.LocalizeString(false, "Arro/PlayTime/Local:times", new object[0]);
        public static string totallivebuildcas = Localization.LocalizeString(false, "Arro/PlayTime/Local:totallivebuildcas", new object[0]);
        public static string sessionlivebuildcas = Localization.LocalizeString(false, "Arro/PlayTime/Local:sessionlivebuildcas", new object[0]);
        //Set total seconds
        public static string settotaltimewarning = Localization.LocalizeString(false, "Arro/PlayTime/Local:settotaltimewarning", new object[0]);
        public static string setlivemodeseconds = Localization.LocalizeString(false, "Arro/PlayTime/Local:setlivemodeseconds", new object[0]);
		public static string setbbmodeseconds = Localization.LocalizeString(false, "Arro/PlayTime/Local:setbbmodeseconds", new object[0]);
		public static string setcasseconds = Localization.LocalizeString(false, "Arro/PlayTime/Local:setcasseconds", new object[0]);
	}
}

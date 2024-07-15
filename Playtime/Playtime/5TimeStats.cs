using Sims3.SimIFace;

namespace Arro
{
	public class TimeStats
	{
		[PersistableStatic(true)]
		public static float TotalSeconds = 0;
		
		[PersistableStatic(true)]
		public static float LiveTotalSeconds = 0;
		
		[PersistableStatic(true)]
		public static float  BBTotalSeconds = 0;
		
		[PersistableStatic(true)]
		public static float  CASTotalSeconds = 0;
		
		[PersistableStatic(true)]
		public static float  TotalPlaycount = 0;
		
		[PersistableStatic(true)]
		public static int LiveCount = 0;
		
		[PersistableStatic(true)]
		public static int BBCount = 0;
		
		[PersistableStatic(true)]
		public static int CASCount = 0;
		
		[PersistableStatic(true)]
		public static int TravelCount = 0;
		
		[PersistableStatic(true)]
		public static bool  ShowLiveStats = true;
		
		[PersistableStatic(true)]
		public static bool  ShowCASStats = true;
		
		[PersistableStatic(true)]
		public static bool  ShowBBStats = true;
		
		[PersistableStatic(true)]
		public static bool  ShowPlaycount = true;	
	
		[PersistableStatic(true)]
		public static bool  HasRunSetup = false;
		
		[PersistableStatic(true)]
		public static bool  HasAddedTravelCount = false;			
		
	}
}


using UnityEngine;
using System;
using System.Collections;

namespace InfiniEngine {

	public delegate void WorldTickEventHandler(object sender, EventArgs e); // Fired every tick
	public delegate void WorldTimeChangeEventHandler(object sender, EventArgs e); // Fired every 60 ticks

	public class World {

		//STATICS
		private static World currentWorld; //The currently active instance of World

		//EVENTS
		public event WorldTickEventHandler OnTick;
		public event WorldTimeChangeEventHandler OnTimeChange;

		//PUBLIC


		//PRIVATE
		private ulong gameTicks;
		private string worldName;

		//METHODS

		public World(string name, ulong ticks){
			
			worldName = name;
			gameTicks = ticks;

            InfiniManager.activeManager.OnCycle += new GameCycleEventHandler(activeManager_OnCycle);
			
		}

        void activeManager_OnCycle(object sender, EventArgs e) {

            Tick();

        }

		public World(string name, GameTime time){

			worldName = name;
			gameTicks = time.ToTicks();
			
		}

		public static void LoadWorld(World worldToLoad){
			
			currentWorld = worldToLoad;
			
		}
		
		public static World GetActiveWorld(){
			
			return currentWorld;
			
		}

		private void Tick(){

            gameTicks++;
			if(OnTick != null)OnTick(this, EventArgs.Empty);
            if ((gameTicks % 60) == 0) {
                if (OnTimeChange != null) OnTimeChange(this, EventArgs.Empty);
            }

		}

		/// <summary>
		/// Returns the number of ticks that have elapsed since the creation of the world
		/// </summary>
		public ulong GetElapsedTicks(){

			return gameTicks;

		}

		/// <summary>
		/// Returns a GameTime struct representing the ingame time
		/// </summary>
		public GameTime GetTime(){

            byte gMinutes;
            uint gMinutesTR;

            byte gHours;
            uint gHoursTR;

            ushort gDays;
            uint gDaysTR;

            uint gYears;
            uint gYearsTR;

            gYearsTR = (uint)(gameTicks % 31536000);
            gYears = (uint)((gameTicks - gYearsTR) / 31536000);

            gDaysTR = (uint)(gYearsTR % 86400);
            gDays = (ushort)((gYearsTR - gDaysTR) / 86400);

            gHoursTR = (uint)(gDaysTR % 3600);
            gHours = (byte)((gDaysTR - gHoursTR) / 3600);

            gMinutesTR = (uint)(gHoursTR % 60);
            gMinutes = (byte)((gHoursTR - gMinutesTR) / 60);

            return new GameTime(gMinutes, gHours, gDays, gYears);

		}

        ~World() {

            InfiniManager.activeManager.OnCycle -= activeManager_OnCycle;

        }

	}

}


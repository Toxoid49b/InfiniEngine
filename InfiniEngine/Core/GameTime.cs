using System;

namespace InfiniEngine {

    /// <summary>
    /// Represents an ingame time value
    /// </summary>
	public struct GameTime {

		public enum TimeOfDay {

			Morning = 0,
			Noon = 1,
			Evening = 2,
			Night = 3,
			Unknown = 4

		}

		public byte gameMinutes, gameHours;
		public ushort gameDay;
		public uint gameYear;

		public GameTime(byte minutes, byte hours, ushort day, uint year){

			gameMinutes = minutes;
			gameHours = hours;
			gameDay = day;
			gameYear = year;

		}

		public static GameTime operator +(GameTime timeOne, GameTime timeTwo){

			byte newMinutes, newHours = 0;
			ushort newDay = 0;
			uint newYear = 0;

			newMinutes = (byte)(timeOne.gameMinutes + timeTwo.gameMinutes);
			if(newMinutes > 59) newMinutes = (byte)(newMinutes % 60); newHours++;
			newHours = (byte)(newHours + timeOne.gameHours + timeTwo.gameHours);
			if(newHours > 23) newHours = (byte)(newHours % 24); newDay++;
			newDay = (ushort)(newDay + timeOne.gameDay + timeTwo.gameDay);
			if(newDay > 364) newDay = (ushort)(newDay % 365); newYear++;
			newYear = (uint)(newYear + timeOne.gameYear + timeTwo.gameYear);

			return new GameTime(newMinutes, newHours, newDay, newYear);

		}

		/// <summary>
		/// Returns the number of ticks represented by this GameTime
		/// </summary>
		public ulong ToTicks(){

			ulong tickValue = (ulong)(60 * (gameMinutes + (gameHours * 60) + (gameDay * 1440) + (gameYear * 525600)));
			return tickValue;

		}

		/// <summary>
		/// Returns the TimeOfDay represented by this GameTime
		/// </summary>
		public TimeOfDay ToTOD(){

			if(gameHours > 5 && gameHours < 12){

				return TimeOfDay.Morning;

			} else if (gameHours > 11 && gameHours < 16) {

				return TimeOfDay.Noon;

			} else if (gameHours > 15 && gameHours < 21) {

				return TimeOfDay.Evening;

			} else if (gameHours > 20 && gameHours < 25) {

				return TimeOfDay.Night;

			} else if (gameHours >= 0 && gameHours < 6){

				return TimeOfDay.Night;

			}

			return TimeOfDay.Unknown;

		}

        /// <summary>
        /// Returns a string representation of this GameTime
        /// </summary>
        public string ToTimeString() {

            return gameHours + ":" + gameMinutes + " " + gameDay + "/" + gameYear;

        }

        /// <summary>
        /// Returns a formated string representation of this GameTime
        /// </summary>
        public string ToTimeStringDecorated() {

            string gameMinutesString = gameMinutes.ToString();
            string gameYearString = gameYear.ToString();

            if (gameMinutes < 10) {

                gameMinutesString = "0" + gameMinutes;

            }

            return gameHours + ":" + gameMinutesString + "\n" + gameDay + "/" + gameYear;

        }

	}

}


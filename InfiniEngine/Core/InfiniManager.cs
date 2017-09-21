using System;

namespace InfiniEngine {

    public delegate void GameCycleEventHandler(object sender, EventArgs e); // Fired every cycle

	public class InfiniManager {

        public static readonly InfiniManager activeManager = new InfiniManager();
        
        public event GameCycleEventHandler OnCycle;

        public InfiniManager() {



        }

        public void Cycle() {

            OnCycle?.Invoke(this, EventArgs.Empty);

        }

	}

}


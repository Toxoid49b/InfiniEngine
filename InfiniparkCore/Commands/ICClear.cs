using System;
using InfiniEngine;
using InfiniEngine.InfiniScript;

namespace InfiniparkCore.Commands {

    public class ICClear : IInfiniCommand {

        public string commandName {
            get {
                return "clear";
            }
            set{
            
            }
        }

        public bool Execute(string[] cmdArgs) {

            Logger.ClearBuffer();
            return true;

        }

    }

}

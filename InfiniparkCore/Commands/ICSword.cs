using System;
using InfiniEngine;
using InfiniEngine.InfiniScript;

namespace InfiniparkCore {

    public class ICSword : IInfiniCommand {

        public string commandName {
            get {
                return "sword";
            }
            set { }
        }

        public bool Execute(string[] cmdArgs) {
            
            Logger.Put("      /|________________\n");
            Logger.Put("O|===|*|________________>\n");
            Logger.Put("      \\|\n");


            return true;

        }

    }

}

using System;
using InfiniEngine;
using InfiniEngine.InfiniScript;
using InfiniEngine.Managers;

namespace InfiniparkCore.Commands {

    public class ICDeclare : IInfiniCommand {

        public string commandName {

            get {

                return "declare";

            }

            set { }

        }

        public bool Execute(string[] cmdArgs) {

            if (cmdArgs.Length == 3) {

                EngineVar newVar = new EngineVar();

                string varType = cmdArgs[0];

                switch (varType) {

                    case "int":
                        if (!CommandManager.DeclareVar(VarType.Integer, cmdArgs[1], cmdArgs[2])) return false;
                        break;
                    case "string":
                        if (!CommandManager.DeclareVar(VarType.String, cmdArgs[1], cmdArgs[2])) return false;
                        break;
                    case "bool":
                        if (!CommandManager.DeclareVar(VarType.Boolean, cmdArgs[1], cmdArgs[2])) return false;
                        break;

                }

                if (newVar.type == VarType.String) {

                    Logger.PutLine("Created new var $" + cmdArgs[1] + " with value \"" + cmdArgs[2] + "\"!");

                } else {

                    Logger.PutLine("Created new var $" + cmdArgs[1] + " with value " + cmdArgs[2] + "!");

                }

                return true;

            }

            return false;

        }

    }

}
